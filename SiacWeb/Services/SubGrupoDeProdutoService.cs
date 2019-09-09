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
    public class SubGrupoDeProdutoService : BaseService
    {
        public SubGrupoDeProdutoService(SiacWebContext context, IUser user, AuditoriaService auditoriaService) : base(context, user, auditoriaService) { }

        public async Task<SubGrupoDeProduto> FindByIdAsync(string empresaId, int id)
        {
            return await _context.SubGrupoDeProduto
                .Include(obj => obj.GrupoDeProduto)
                .FirstOrDefaultAsync(obj => obj.EmpresaId == int.Parse(empresaId) && obj.Id == id);
        }

        public async Task<IPagedList<SubGrupoDeProduto>> FindAllAsync(int pagina, string empresaId)
        {
            return await _context.SubGrupoDeProduto
                .Include(obj => obj.GrupoDeProduto)
                .Where(obj => obj.EmpresaId == int.Parse(empresaId)).OrderBy(obj => obj.Id).ToPagedListAsync(pagina, Constantes.QuantidadeRegistrosPorPagina);
        }

        public async Task<IPagedList<SubGrupoDeProduto>> FindAsync(int pagina, string empresaId, string consulta)
        {
            var result = from obj in _context.SubGrupoDeProduto select obj;

            if (consulta.All(char.IsDigit))
                result = result.Where(x => x.Id == int.Parse(consulta));
            else
                result = result.Where(x => x.Descricao.Contains(consulta));

            return await result
                .Include(obj => obj.GrupoDeProduto)
                .Where(obj => obj.EmpresaId == int.Parse(empresaId)).OrderBy(x => x.Id).ToPagedListAsync(pagina, Constantes.QuantidadeRegistrosPorPagina);
        }

        public async Task<IPagedList<SubGrupoDeProduto>> FindByGrupoIdAsync(int pagina, string empresaId, int grupoId)
        {
            return await _context.SubGrupoDeProduto
                .Where(obj => obj.EmpresaId == int.Parse(empresaId))
                .Where(obj => obj.GrupoDeProdutoId == grupoId)
                .OrderBy(obj => obj.Id)
                .Include(obj => obj.GrupoDeProduto)
                .ToPagedListAsync(pagina, Constantes.QuantidadeRegistrosPorPagina);
        }

        public async Task InsertAsync(SubGrupoDeProduto obj)
        {
            obj.Usuario = _user.Name;
            _context.Add(obj);
            await _context.SaveChangesAsync();
            await Auditoria(obj.EmpresaId,
                Modulo.Estoque,
                SubModulo.SubGrupoDeProduto,
                Operacao.Inclusao,
                "TODO");
        }

        public async Task UpdateAsync(SubGrupoDeProduto obj)
        {
            bool TemAlgum = await _context.SubGrupoDeProduto.AnyAsync(x => x.Id == obj.Id);
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
                    SubModulo.SubGrupoDeProduto,
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
                var obj = await _context.SubGrupoDeProduto.FindAsync(id);
                _context.SubGrupoDeProduto.Remove(obj);
                await _context.SaveChangesAsync();
                await Auditoria(obj.EmpresaId,
                    Modulo.Estoque,
                    SubModulo.SubGrupoDeProduto,
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