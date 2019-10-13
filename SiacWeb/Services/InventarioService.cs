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
    public class InventarioService : BaseService
    {
        public InventarioService(SiacWebContext context, IUser user, AuditoriaService auditoriaService) : base(context, user, auditoriaService) { }

        private int GetEmpresaId(int centroDeCustoId)
        {
            return _context.CentroDeCusto.FirstOrDefault(x => x.Id == centroDeCustoId).EmpresaId;
        }

        public async Task<Inventario> FindByIdAsync(string empresaId, int id)
        {
            return await _context.Inventario
                .Include(obj => obj.CentroDeCusto)
                .Include(obj => obj.InventarioItens)
                .Include(obj => obj.Funcionario)
                .FirstOrDefaultAsync(obj => obj.CentroDeCusto.EmpresaId == int.Parse(empresaId) && obj.Id == id);
        }

        public async Task<IPagedList<Inventario>> FindAllAsync(int pagina, string empresaId)
        {
            return await _context.Inventario
                .Include(obj => obj.CentroDeCusto)
                .Include(obj => obj.InventarioItens)
                .Include(obj => obj.Funcionario)
                .Where(obj => obj.CentroDeCusto.EmpresaId == int.Parse(empresaId))                
                .OrderBy(obj => obj.Id)
                .ToPagedListAsync(pagina, Constantes.QuantidadeRegistrosPorPagina);
        }

        public async Task<IPagedList<Inventario>> FindAsync(int pagina, string empresaId, string consulta)
        {
            var result = from obj in _context.Inventario select obj;

            if (consulta.All(char.IsDigit))
                result = result.Where(x => x.Id == int.Parse(consulta));
            else
                result = result.Where(x => x.Descricao.Contains(consulta));

            return await result
                .Include(obj => obj.CentroDeCusto)
                .Include(obj => obj.InventarioItens)
                .Include(obj => obj.Funcionario)
                .Where(obj => obj.CentroDeCusto.EmpresaId == int.Parse(empresaId))
                .OrderBy(x => x.Id)
                .ToPagedListAsync(pagina, Constantes.QuantidadeRegistrosPorPagina);
        }

        public async Task InsertAsync(Inventario obj)
        {
            obj.Usuario = _user.Name;
            obj.Status = StatusInventario.Pendente;
            _context.Add(obj);
            await _context.SaveChangesAsync();
            await Auditoria(GetEmpresaId(obj.CentroDeCustoId),
                Modulo.Estoque,
                SubModulo.Inventario,
                Operacao.Inclusao,
                "TODO");
        }

        public async Task UpdateAsync(Inventario obj)
        {
            bool TemAlgum = await _context.Inventario.AnyAsync(x => x.Id == obj.Id);
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
                await Auditoria(GetEmpresaId(obj.CentroDeCustoId),
                    Modulo.Estoque,
                    SubModulo.Inventario,
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
                var obj = await _context.Inventario.FindAsync(id);
                _context.Inventario.Remove(obj);
                await _context.SaveChangesAsync();
                await Auditoria(GetEmpresaId(obj.CentroDeCustoId),
                    Modulo.Estoque,
                    SubModulo.Inventario,
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