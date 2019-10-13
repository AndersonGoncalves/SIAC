using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SiacWeb.Controllers.Comum;
using SiacWeb.Services;
using SiacWeb.Models;
using SiacWeb.Models.ViewModels;
using SiacWeb.Services.Exceptions;

namespace SiacWeb.Controllers
{
    public class InventariosItensController : BaseController
    {
        private readonly InventarioService _inventarioService;
        private readonly InventarioItemService _inventarioItemService;
        private readonly ProdutoService _produtoService;

        public InventariosItensController(InventarioService inventarioService, InventarioItemService inventarioItemService, ProdutoService produtoService)
        {
            _inventarioService = inventarioService;
            _inventarioItemService = inventarioItemService;
            _produtoService = produtoService;
        }

        public async Task<IActionResult> Create(int inventarioId)
        {
            var inventario = await _inventarioService.FindByIdAsync(EmpresaId, inventarioId);
            var inventarioItens = await _inventarioItemService.FindByInventarioIdAsync(EmpresaId, inventarioId);
            var produtos = await _produtoService.FindAllAsync(EmpresaId);

            var viewModel = new InventarioItensFormViewModel
            {
                Inventario = inventario,
                InventarioItens = inventarioItens,
                Produtos = produtos
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InventarioItem inventarioItem, int inventarioId)
        {
            var inventario = await _inventarioService.FindByIdAsync(EmpresaId, inventarioId);
            inventarioItem.Inventario = inventario;
            InventarioItem item = await _inventarioItemService.FindByProdutoIdAsync(EmpresaId, inventarioId, int.Parse(inventarioItem.ProdutoId.ToString()));
            Produto produto = await _produtoService.FindByIdAsync(EmpresaId, int.Parse(inventarioItem.ProdutoId.ToString()));

            if (item is null)
            {
                inventarioItem.InventarioId = inventarioId;
                inventarioItem.PrecoCompra = produto.PrecoCompra;
                inventarioItem.PrecoCusto = produto.PrecoCusto;
                inventarioItem.PrecoVenda = produto.PrecoVenda;

                await _inventarioItemService.InsertAsync(inventarioItem);
            }
            else
            {
                item.QuantidadeInformada = inventarioItem.QuantidadeInformada + item.QuantidadeInformada;
                item.PrecoCompra = produto.PrecoCompra;
                item.PrecoCusto = produto.PrecoCusto;
                item.PrecoVenda = produto.PrecoVenda;

                if (item.QuantidadeInformada == 0)
                    await _inventarioItemService.RemoveAsync(item.Id);
                else
                    await _inventarioItemService.UpdateAsync(item);
            }

            var inventarioItens = await _inventarioItemService.FindByInventarioIdAsync(EmpresaId, inventarioId);
            var produtos = await _produtoService.FindAllAsync(EmpresaId);

            var viewModel = new InventarioItensFormViewModel
            {
                Inventario = inventario,
                InventarioItens = inventarioItens,
                Produtos = produtos
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Delete(int? id, int inventarioId)
        {
            if (id == null)
                return RedirectToAction(nameof(Error), new { message = "Id não informado!" });

            var obj = await _inventarioItemService.FindByIdAsync(EmpresaId, id.Value);
            if (obj == null)
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });

            var inventario = await _inventarioService.FindByIdAsync(EmpresaId, inventarioId);
            var inventarioItens = await _inventarioItemService.FindByInventarioIdAsync(EmpresaId, inventarioId);
            var produtos = await _produtoService.FindAllAsync(EmpresaId);

            var viewModel = new InventarioItensFormViewModel
            {
                InventarioItem = obj,
                Inventario = inventario,
                InventarioItens = inventarioItens,
                Produtos = produtos
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, int inventarioId)
        {
            try
            {
                await _inventarioItemService.RemoveAsync(id);
                return RedirectToAction(nameof(Create), new { inventarioId });
            }
            catch (IntegrityException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }
    }
}