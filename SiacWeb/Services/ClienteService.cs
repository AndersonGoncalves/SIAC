using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SiacWeb.Enums;
using SiacWeb.Services.Comum;
using SiacWeb.Models;
using SiacWeb.Comum;
using SiacWeb.Models.Interface;
using SiacWeb.Services.Exceptions;
using X.PagedList;

namespace SiacWeb.Services
{
    public class ClienteService : BaseService
    {
        public ClienteService(SiacWebContext context, IUser user, AuditoriaService auditoriaService) : base(context, user, auditoriaService) { }

        public async Task<Cliente> FindByIdAsync(string empresaId, int id)
        {
            return await _context.Cliente.FirstOrDefaultAsync(obj => obj.EmpresaId == int.Parse(empresaId) && obj.Id == id);
        }

        public async Task<IPagedList<Cliente>> FindAllAsync(int pagina, string empresaId)
        {
            return await _context.Cliente.Where(obj => obj.EmpresaId == int.Parse(empresaId)).OrderBy(obj => obj.Id).ToPagedListAsync(pagina, Constantes.QuantidadeRegistrosPorPagina);
        }

        public async Task<IPagedList<Cliente>> FindAsync(int pagina, string empresaId, string consulta)
        {
            var result = from obj in _context.Cliente select obj;

            if (consulta.All(char.IsDigit))
                result = result.Where(x => x.Id == int.Parse(consulta));
            else
                result = result.Where(x => x.RazaoSocial.Contains(consulta));

            return await result.Where(obj => obj.EmpresaId == int.Parse(empresaId)).OrderBy(x => x.Id).ToPagedListAsync(pagina, Constantes.QuantidadeRegistrosPorPagina);
        }

        public async Task InsertAsync(Cliente obj)
        {
            obj.Usuario = _user.Name;
            _context.Add(obj);
            await _context.SaveChangesAsync();
            await Auditoria(obj.EmpresaId,
                Modulo.Venda,
                SubModulo.Cliente,
                Operacao.Inclusao,
                "TODO");
        }
                
        public async Task UpdateAsync(Cliente obj)
        {
            bool TemAlgum = await _context.Cliente.AnyAsync(x => x.Id == obj.Id);
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
                    Modulo.Venda,
                    SubModulo.Cliente,
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
                var obj = await _context.Cliente.FindAsync(id);
                _context.Cliente.Remove(obj);
                await _context.SaveChangesAsync();
                await Auditoria(obj.EmpresaId,
                    Modulo.Venda,
                    SubModulo.Cliente,
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