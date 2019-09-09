using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SiacWeb.Controllers.Comum;
using SiacWeb.Services;
using SiacWeb.Models;
using SiacWeb.Comum;
using SiacWeb.Models.ViewModels;
using SiacWeb.Services.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace SiacWeb.Controllers
{
    [Authorize(Roles = Perfil.Admin + ", " + Perfil.Diretor + ", " + Perfil.Supervisor + ", " + Perfil.Gerente + ", " + Perfil.Estoquista)]
    public class SubGruposDeProdutosController : BaseController
    {
        private readonly SubGrupoDeProdutoService _subGrupoDeProdutoService;
        private readonly EmpresaService _empresaService;
        private readonly GrupoDeProdutoService _grupoDeProdutoService;

        public SubGruposDeProdutosController(SubGrupoDeProdutoService subGrupoDeProdutoService, EmpresaService empresaService, GrupoDeProdutoService grupoDeProdutoService)
        {
            _subGrupoDeProdutoService = subGrupoDeProdutoService;
            _empresaService = empresaService;
            _grupoDeProdutoService = grupoDeProdutoService;
        }

        public async Task<IActionResult> Index(int? pagina, string consulta)
        {
            int page = pagina ?? 1;
            ViewData["Consulta"] = consulta;
            if (consulta == null)
            {
                var List = await _subGrupoDeProdutoService.FindAllAsync(page, EmpresaId);
                return View(List);
            }
            else
            {
                var List = await _subGrupoDeProdutoService.FindAsync(page, EmpresaId, consulta);
                return View(List);
            }
        }

        public async Task<IActionResult> Create()
        {
            var empresas = await _empresaService.FindAllAsync();
            var grupoDeProduto = await _grupoDeProdutoService.FindAllAsync(EmpresaId);
            var viewModel = new SubGrupoDeProdutoFormViewModel { Empresas = empresas, GruposDeProdutos = grupoDeProduto };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SubGrupoDeProduto subGrupoDeProduto)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new SubGrupoDeProdutoFormViewModel();
                return View(viewModel);
            }
            subGrupoDeProduto.EmpresaId = int.Parse(EmpresaId);
            await _subGrupoDeProdutoService.InsertAsync(subGrupoDeProduto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Error), new { message = "Id não informado!" });

            var obj = await _subGrupoDeProdutoService.FindByIdAsync(EmpresaId, id.Value);
            if (obj == null)
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });

            var viewModel = new SubGrupoDeProdutoFormViewModel { SubGrupoDeProduto = obj };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _subGrupoDeProdutoService.RemoveAsync(id);
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

            var obj = await _subGrupoDeProdutoService.FindByIdAsync(EmpresaId, id.Value);
            if (obj == null)
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });

            var viewModel = new SubGrupoDeProdutoFormViewModel { SubGrupoDeProduto = obj };
            return View(viewModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não informado!" });
            }
            var obj = await _subGrupoDeProdutoService.FindByIdAsync(EmpresaId, id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });
            }

            var empresas = await _empresaService.FindAllAsync();
            var grupoDeProduto = await _grupoDeProdutoService.FindAllAsync(EmpresaId);
            var viewModel = new SubGrupoDeProdutoFormViewModel { Empresas = empresas, SubGrupoDeProduto = obj, GruposDeProdutos = grupoDeProduto };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SubGrupoDeProduto subGrupoDeProduto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (id != subGrupoDeProduto.Id)
            {
                return BadRequest();
            }
            try
            {
                subGrupoDeProduto.EmpresaId = int.Parse(EmpresaId);
                await _subGrupoDeProdutoService.UpdateAsync(subGrupoDeProduto);
                return RedirectToAction(nameof(Index));
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