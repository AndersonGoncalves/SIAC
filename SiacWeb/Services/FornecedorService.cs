using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SiacWeb.Services.Comum;
using SiacWeb.Enums;
using SiacWeb.Models;
using SiacWeb.Comum;
using SiacWeb.Models.Interface;
using SiacWeb.Services.Exceptions;
using X.PagedList;

namespace SiacWeb.Services
{
    public class FornecedorService : BaseService
    {
        public FornecedorService(SiacWebContext context, IUser user, AuditoriaService auditoriaService) : base(context, user, auditoriaService) { }

        public async Task<Fornecedor> FindByIdAsync(string empresaId, int id)
        {
            return await _context.Fornecedor.FirstOrDefaultAsync(obj => obj.EmpresaId == int.Parse(empresaId) && obj.Id == id);
        }

        public async Task<IPagedList<Fornecedor>> FindAllAsync(int pagina, string empresaId)
        {
            return await _context.Fornecedor.Where(obj => obj.EmpresaId == int.Parse(empresaId)).OrderBy(obj => obj.Id).ToPagedListAsync(pagina, Constantes.QuantidadeRegistrosPorPagina);
        }

        public async Task<IPagedList<Fornecedor>> FindAsync(int pagina, string empresaId, string consulta)
        {
            var result = from obj in _context.Fornecedor select obj;

            if (consulta.All(char.IsDigit))
                result = result.Where(x => x.Id == int.Parse(consulta));
            else
                result = result.Where(x => x.RazaoSocial.Contains(consulta));

            return await result.Where(obj => obj.EmpresaId == int.Parse(empresaId)).OrderBy(x => x.Id).ToPagedListAsync(pagina, Constantes.QuantidadeRegistrosPorPagina);
        }

        public async Task InsertAsync(Fornecedor obj)
        {
            obj.Usuario = _user.Name;
            _context.Add(obj);
            await _context.SaveChangesAsync();
            await Auditoria(obj.EmpresaId,
                Modulo.Compra,
                SubModulo.Fornecedor,
                Operacao.Inclusao,
                "TODO");
        }
                
        public async Task UpdateAsync(Fornecedor obj)
        {
            bool TemAlgum = await _context.Fornecedor.AnyAsync(x => x.Id == obj.Id);
            if (!TemAlgum)
            {
                throw new NotFoundException("Id não encontrado!");
            }

            try
            {
                obj.DataAlteracao = DateTime.Now;
                obj.Usuario = _user.Name;
                _context.Update(obj);
                await _context.SaveChangesAsync();
                await Auditoria(obj.EmpresaId,
                    Modulo.Compra,
                    SubModulo.Fornecedor,
                    Operacao.Alteracao,
                    "TODO");
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Fornecedor.FindAsync(id);
                _context.Fornecedor.Remove(obj);
                await _context.SaveChangesAsync();
                await Auditoria(obj.EmpresaId,
                    Modulo.Compra,
                    SubModulo.Fornecedor,
                    Operacao.Exclusao,
                    "TODO");
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException(e.Message);
            }
        }
    }
}
