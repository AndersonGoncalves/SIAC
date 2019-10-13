using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SiacWeb.Enums;
using SiacWeb.Services.Comum;
using SiacWeb.Models;
using SiacWeb.Models.Interface;
using SiacWeb.Services.Exceptions;
using X.PagedList;
using System.Collections.Generic;

namespace SiacWeb.Services
{
    public class InventarioItemService : BaseService
    {
        public InventarioItemService(SiacWebContext context, IUser user, AuditoriaService auditoriaService) : base(context, user, auditoriaService) { }

        public async Task<InventarioItem> FindByIdAsync(string empresaId, int id)
        {
            return await _context.InventarioItem
                .Include(obj => obj.Inventario)
                .Include(obj => obj.Inventario.CentroDeCusto)
                .Include(obj => obj.Produto)
                .FirstOrDefaultAsync(obj => obj.Inventario.CentroDeCusto.EmpresaId == int.Parse(empresaId) && obj.Id == id);
        }

        public async Task<List<InventarioItem>> FindByInventarioIdAsync(string empresaId, int inventarioId)
        {
            return await _context.InventarioItem
                .Include(obj => obj.Inventario)
                .Include(obj => obj.Inventario.CentroDeCusto)
                .Include(obj => obj.Produto)
                .Where(obj => obj.Inventario.CentroDeCusto.EmpresaId == int.Parse(empresaId))
                .Where(obj => obj.InventarioId == inventarioId)
                .OrderBy(obj => obj.Id)
                .ToListAsync();
        }

        public async Task<InventarioItem> FindByProdutoIdAsync(string empresaId, int inventarioId, int produtoId)
        {
            return await _context.InventarioItem
                .Include(obj => obj.Inventario)
                .Include(obj => obj.Inventario.CentroDeCusto)
                .Include(obj => obj.Produto)
                .Where(obj => obj.Inventario.CentroDeCusto.EmpresaId == int.Parse(empresaId))
                .Where(obj => obj.InventarioId == inventarioId)
                .FirstOrDefaultAsync(obj => obj.ProdutoId == produtoId);
        }

        public async Task InsertAsync(InventarioItem obj)
        {
            obj.Usuario = _user.Name;
            _context.Add(obj);
            await _context.SaveChangesAsync();
            await Auditoria(obj.Inventario.CentroDeCusto.EmpresaId,
                Modulo.Estoque,
                SubModulo.Inventario,
                Operacao.Inclusao,
                "TODO");
        }

        public async Task UpdateAsync(InventarioItem obj)
        {
            bool TemAlgum = await _context.InventarioItem.AnyAsync(x => x.Id == obj.Id);
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
                await Auditoria(obj.Inventario.CentroDeCusto.EmpresaId,
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
                InventarioItem obj = await _context.InventarioItem
                    .Include(x => x.Inventario)
                    .Include(x => x.Inventario.CentroDeCusto)
                    .FirstOrDefaultAsync(x => x.Id == id);

                _context.InventarioItem.Remove(obj);
                await _context.SaveChangesAsync();
                await Auditoria(obj.Inventario.CentroDeCusto.EmpresaId,
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