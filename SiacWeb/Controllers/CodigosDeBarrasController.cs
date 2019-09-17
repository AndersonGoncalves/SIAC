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
    public class CodigosDeBarrasController : BaseController
    {
        private readonly CodigoDeBarraService _codigoDeBarraService;
        private readonly ProdutoService _produtoService;       

        public CodigosDeBarrasController(CodigoDeBarraService codigoDeBarraService, ProdutoService produtoService)
        {
            _codigoDeBarraService = codigoDeBarraService;
            _produtoService = produtoService;
        }

        public async Task<IActionResult> Index(int? pagina, string consulta, int? produtoId)
        {
            int page = pagina ?? 1;
            ViewData["Consulta"] = consulta;
            ViewBag.ProdutoId = produtoId;

            ViewBag.ProdutoDescricao = null;
            if (produtoId != null)
            {
                int objId = produtoId ?? 0;
                var produtoDescricao = await _produtoService.FindByIdAsync(EmpresaId, objId);
                ViewBag.ProdutoDescricao = produtoDescricao.Descricao;
            }


            if (consulta == null)
            {
                var List = await _codigoDeBarraService.FindByProdutoIdAsync(page, EmpresaId, produtoId);
                return View(List);
            }
            else
            {
                var List = await _codigoDeBarraService.FindAsync(page, EmpresaId, produtoId, consulta);
                return View(List);
            }
        }

        public async Task<IActionResult> Create(int produtoId)
        {
            ViewBag.ProdutoId = produtoId;
            var produtoDescricao = await _produtoService.FindByIdAsync(EmpresaId, produtoId);
            ViewBag.ProdutoDescricao = produtoDescricao.Descricao;

            var produtos = await _produtoService.FindAllAsync(EmpresaId);
            var viewModel = new CodigoDeBarraFormViewModel
            {
                Produtos = produtos
            };            
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CodigoDeBarra codigoDeBarra, int produtoId)
        {
            ViewBag.ProdutoId = produtoId;
            var produtoDescricao = await _produtoService.FindByIdAsync(EmpresaId, produtoId);
            ViewBag.ProdutoDescricao = produtoDescricao.Descricao;

            if (!ModelState.IsValid)
            {
                var viewModel = new CodigoDeBarraFormViewModel();
                return View(viewModel);
            }
            codigoDeBarra.EmpresaId = int.Parse(EmpresaId);
            codigoDeBarra.ProdutoId = produtoId;
            await _codigoDeBarraService.InsertAsync(codigoDeBarra);
            return RedirectToAction(nameof(Index), new { produtoId });
        }

        public async Task<IActionResult> Delete(int? id, int produtoId)
        {
            ViewBag.ProdutoId = produtoId;
            var produtoDescricao = await _produtoService.FindByIdAsync(EmpresaId, produtoId);
            ViewBag.ProdutoDescricao = produtoDescricao.Descricao;

            if (id == null)
                return RedirectToAction(nameof(Error), new { message = "Id não informado!" });

            var obj = await _codigoDeBarraService.FindByIdAsync(EmpresaId, id.Value);
            if (obj == null)
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });

            var viewModel = new CodigoDeBarraFormViewModel { CodigoDeBarra = obj };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, int produtoId)
        {
            ViewBag.ProdutoId = produtoId;
            var produtoDescricao = await _produtoService.FindByIdAsync(EmpresaId, produtoId);
            ViewBag.ProdutoDescricao = produtoDescricao.Descricao;

            try
            {
                await _codigoDeBarraService.RemoveAsync(id);
                return RedirectToAction(nameof(Index), new { produtoId });
            }
            catch (IntegrityException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public async Task<IActionResult> Details(int? id, int produtoId)
        {
            ViewBag.ProdutoId = produtoId;
            var produtoDescricao = await _produtoService.FindByIdAsync(EmpresaId, produtoId);
            ViewBag.ProdutoDescricao = produtoDescricao.Descricao;

            if (id == null)
                return RedirectToAction(nameof(Error), new { message = "Id não infomado!" });

            var obj = await _codigoDeBarraService.FindByIdAsync(EmpresaId, id.Value);
            if (obj == null)
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });

            var viewModel = new CodigoDeBarraFormViewModel { CodigoDeBarra = obj };
            return View(viewModel);
        }

        public async Task<IActionResult> Edit(int? id, int produtoId)
        {
            ViewBag.ProdutoId = produtoId;
            var produtoDescricao = await _produtoService.FindByIdAsync(EmpresaId, produtoId);
            ViewBag.ProdutoDescricao = produtoDescricao.Descricao;

            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não informado!" });
            }
            var obj = await _codigoDeBarraService.FindByIdAsync(EmpresaId, id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });
            }

            var produtos = await _produtoService.FindAllAsync(EmpresaId);
            var viewModel = new CodigoDeBarraFormViewModel
            {
                CodigoDeBarra = obj,
                Produtos = produtos
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CodigoDeBarra codigoDeBarra, int produtoId)
        {
            ViewBag.ProdutoId = produtoId;
            var produtoDescricao = await _produtoService.FindByIdAsync(EmpresaId, produtoId);
            ViewBag.ProdutoDescricao = produtoDescricao.Descricao;

            if (!ModelState.IsValid)
            {
                var produtos = await _produtoService.FindAllAsync(EmpresaId);
                var viewModel = new CodigoDeBarraFormViewModel
                {
                    CodigoDeBarra = codigoDeBarra,
                    Produtos = produtos
                };
                return View(viewModel);
            }
            if (id != codigoDeBarra.Id)
            {
                return BadRequest();
            }
            try
            {
                codigoDeBarra.EmpresaId = int.Parse(EmpresaId);
                codigoDeBarra.ProdutoId = produtoId;
                await _codigoDeBarraService.UpdateAsync(codigoDeBarra);
                return RedirectToAction(nameof(Index), new { produtoId });
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}