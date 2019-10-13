using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SiacWeb.Controllers.Comum;
using SiacWeb.Services;
using SiacWeb.Models;
using SiacWeb.Models.ViewModels;
using SiacWeb.Services.Exceptions;

namespace SiacWeb.Controllers
{
    public class ProdutosController : BaseController
    {
        private readonly ProdutoService _produtoService;
        private readonly EmpresaService _empresaService;
        private readonly FornecedorService _fornecedorService;
        private readonly GrupoDeProdutoService _grupoDeProdutoService;
        private readonly SubGrupoDeProdutoService _subGrupoDeProdutoService;

        public ProdutosController(ProdutoService produtoService, FornecedorService fornecedorService, GrupoDeProdutoService grupoDeProdutoService, SubGrupoDeProdutoService subGrupoDeProdutoService, EmpresaService empresaService)
        {
            _produtoService = produtoService;
            _fornecedorService = fornecedorService;
            _grupoDeProdutoService = grupoDeProdutoService;
            _subGrupoDeProdutoService = subGrupoDeProdutoService;
            _empresaService = empresaService;
        }

        public async Task<IActionResult> Index(int? pagina, string consulta)
        {
            int page = pagina ?? 1;
            ViewData["Consulta"] = consulta;
            if (consulta == null)
            {
                var List = await _produtoService.FindAllAsync(page, EmpresaId);
                return View(List);
            }
            else
            {
                var List = await _produtoService.FindAsync(page, EmpresaId, consulta);
                return View(List);
            }
        }

        public async Task<IActionResult> Create()
        {
            var empresas = await _empresaService.FindAllAsync();
            var fornecedores = await _fornecedorService.FindAllAsync(EmpresaId);
            var gruposDeProdutos = await _grupoDeProdutoService.FindAllAsync(EmpresaId);
            var subGruposDeProdutos = await _subGrupoDeProdutoService.FindAllAsync(EmpresaId);

            var viewModel = new ProdutoFormViewModel
            {
                Empresas = empresas,
                Fornecedores = fornecedores,
                GruposDeProdutos = gruposDeProdutos,
                SubGruposDeProdutos = subGruposDeProdutos
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Produto produto)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ProdutoFormViewModel();
                return View(viewModel);
            }
            produto.EmpresaId = int.Parse(EmpresaId);
            await _produtoService.InsertAsync(produto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Error), new { message = "Id não informado!" });

            var obj = await _produtoService.FindByIdAsync(EmpresaId, id.Value);
            if (obj == null)
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });

            var viewModel = new ProdutoFormViewModel { Produto = obj };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _produtoService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (IntegrityException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Error), new { message = "Id não infomado!" });

            var obj = await _produtoService.FindByIdAsync(EmpresaId, id.Value);
            if (obj == null)
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });

            var viewModel = new ProdutoFormViewModel { Produto = obj };
            return View(viewModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não informado!" });
            }
            var obj = await _produtoService.FindByIdAsync(EmpresaId, id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });
            }

            var empresas = await _empresaService.FindAllAsync();
            var fornecedores = await _fornecedorService.FindAllAsync(EmpresaId);
            var gruposDeProdutos = await _grupoDeProdutoService.FindAllAsync(EmpresaId);
            var subGruposDeProdutos = await _subGrupoDeProdutoService.FindAllAsync(EmpresaId);

            var viewModel = new ProdutoFormViewModel
            {
                Empresas = empresas,
                Produto = obj,
                Fornecedores = fornecedores,
                GruposDeProdutos = gruposDeProdutos,
                SubGruposDeProdutos = subGruposDeProdutos
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Produto produto)
        {
            if (!ModelState.IsValid)
            {
                var empresas = await _empresaService.FindAllAsync();
                var fornecedores = await _fornecedorService.FindAllAsync(EmpresaId);
                var gruposDeProdutos = await _grupoDeProdutoService.FindAllAsync(EmpresaId);
                var subGruposDeProdutos = await _subGrupoDeProdutoService.FindAllAsync(EmpresaId);

                var viewModel = new ProdutoFormViewModel
                {
                    Empresas = empresas,
                    Produto = produto,
                    Fornecedores = fornecedores,
                    GruposDeProdutos = gruposDeProdutos,
                    SubGruposDeProdutos = subGruposDeProdutos
                };
                return View(viewModel);
            }
            if (id != produto.Id)
            {
                return BadRequest();
            }
            try
            {
                produto.EmpresaId = int.Parse(EmpresaId);
                await _produtoService.UpdateAsync(produto);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }
    }
}