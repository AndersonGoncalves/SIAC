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

namespace SiacWeb.Controllers
{
    [Authorize(Roles = Perfil.Admin + ", " + Perfil.Diretor + ", " + Perfil.Supervisor + ", " + Perfil.Gerente + ", " + Perfil.Comprador)]
    public class FornecedoresController : BaseController
    {
        private readonly FornecedorService _fornecedorService;
        private readonly EmpresaService _empresaService;

        public FornecedoresController(FornecedorService fornecedorService, EmpresaService empresaService)
        {
            _fornecedorService = fornecedorService;
            _empresaService = empresaService;
        }

        public async Task<IActionResult> Index(int? pagina, string consulta)
        {
            int page = pagina ?? 1;
            ViewData["Consulta"] = consulta;
            if (consulta == null)
            {
                var List = await _fornecedorService.FindAllAsync(page, EmpresaId);
                return View(List);
            }
            else
            {
                var List = await _fornecedorService.FindAsync(page, EmpresaId, consulta);
                return View(List);
            }
        }

        public async Task<IActionResult> Create()
        {
            var empresas = await _empresaService.FindAllAsync();
            FornecedorFormViewModel viewModel = new FornecedorFormViewModel { Empresas = empresas };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Fornecedor fornecedor)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new FornecedorFormViewModel();
                return View(viewModel);
            }
            fornecedor.EmpresaId = int.Parse(EmpresaId);
            await _fornecedorService.InsertAsync(fornecedor);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Error), new { message = "Id não informado!" });

            var obj = await _fornecedorService.FindByIdAsync(EmpresaId, id.Value);
            if (obj == null)
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });

            FornecedorFormViewModel viewModel = new FornecedorFormViewModel { Fornecedor = obj };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _fornecedorService.RemoveAsync(id);
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

            var obj = await _fornecedorService.FindByIdAsync(EmpresaId, id.Value);
            if (obj == null)
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });

            FornecedorFormViewModel viewModel = new FornecedorFormViewModel { Fornecedor = obj };
            return View(viewModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não informado!" });
            }
            var obj = await _fornecedorService.FindByIdAsync(EmpresaId, id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });
            }

            var empresas = await _empresaService.FindAllAsync();
            FornecedorFormViewModel viewModel = new FornecedorFormViewModel { Fornecedor = obj, Empresas = empresas };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Fornecedor fornecedor)
        {
            if (!ModelState.IsValid)
            {
                FornecedorFormViewModel viewModel = new FornecedorFormViewModel { Fornecedor = fornecedor };
                return View(viewModel);
            }
            if (id != fornecedor.Id)
            {
                return BadRequest();
            }
            try
            {
                fornecedor.EmpresaId = int.Parse(EmpresaId);
                await _fornecedorService.UpdateAsync(fornecedor);
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