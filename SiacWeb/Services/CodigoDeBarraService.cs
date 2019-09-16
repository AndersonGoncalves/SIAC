using System;
using System.Linq;
using System.Threading.Tasks;
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
    public class CodigoDeBarraService : BaseService
    {
        public CodigoDeBarraService(SiacWebContext context, IUser user, AuditoriaService auditoriaService) : base(context, user, auditoriaService) { }

        public async Task<CodigoDeBarra> FindByIdAsync(string empresaId, int id)
        {
            return await _context.CodigoDeBarra.FirstOrDefaultAsync(obj => obj.EmpresaId == int.Parse(empresaId) && obj.Id == id);
        }

        public async Task<IPagedList<CodigoDeBarra>> FindAllAsync(int pagina, string empresaId)
        {
            return await _context.CodigoDeBarra.Where(obj => obj.EmpresaId == int.Parse(empresaId)).OrderBy(obj => obj.Id).ToPagedListAsync(pagina, Constantes.QuantidadeRegistrosPorPagina);
        }
        


        public async Task<IPagedList<CodigoDeBarra>> FindByProdutoIdAsync(int pagina, string empresaId, int? produtoId)
        {
            return await _context.CodigoDeBarra
                .Where(obj => obj.EmpresaId == int.Parse(empresaId))
                .Where(obj => obj.ProdutoId == produtoId)
                .OrderBy(obj => obj.Id)
                .ToPagedListAsync(pagina, Constantes.QuantidadeRegistrosPorPagina);
        }

        public async Task<IPagedList<CodigoDeBarra>> FindAsync(int pagina, string empresaId, int? produtoId, string consulta)
        {
            var result = from obj in _context.CodigoDeBarra select obj;
            result = result.Where(x => x.CodigoBarras == consulta);
            return await result
                .Where(obj => obj.ProdutoId == produtoId)
                .Where(obj => obj.EmpresaId == int.Parse(empresaId))
                .OrderBy(x => x.Id)
                .ToPagedListAsync(pagina, Constantes.QuantidadeRegistrosPorPagina);
        }



        public async Task InsertAsync(CodigoDeBarra obj)
        {
            obj.Usuario = _user.Name;
            _context.Add(obj);
            await _context.SaveChangesAsync();
            await Auditoria(obj.EmpresaId,
                Modulo.Estoque,
                SubModulo.CodigoDeBarras,
                Operacao.Inclusao,
                "TODO");
        }

        public async Task UpdateAsync(CodigoDeBarra obj)
        {
            bool TemAlgum = await _context.CodigoDeBarra.AnyAsync(x => x.Id == obj.Id);
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
                    Modulo.Estoque,
                    SubModulo.CodigoDeBarras,
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
                var obj = await _context.CodigoDeBarra.FindAsync(id);
                _context.CodigoDeBarra.Remove(obj);
                await _context.SaveChangesAsync();
                await Auditoria(obj.EmpresaId,
                    Modulo.Estoque,
                    SubModulo.CodigoDeBarras,
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