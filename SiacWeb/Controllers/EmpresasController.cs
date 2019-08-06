using System;
using Microsoft.AspNetCore.Mvc;
using SiacWeb.Services;
using SiacWeb.Models;
using SiacWeb.Models.ViewModels;
using System.Diagnostics;
using System.Threading.Tasks;
using SiacWeb.Services.Exceptions;

namespace SiacWeb.Controllers
{
    public class EmpresasController : Controller
    {
        private readonly EmpresaService _empresaService;

        public EmpresasController(EmpresaService empresaService)
        {
            _empresaService = empresaService;
        }

        public async Task<IActionResult> Index(string consulta)
        {
            ViewData["Consulta"] = consulta;
            if (consulta == null)
            {
                var List = await _empresaService.FindAllAsync();
                return View(List);
            }
            else
            {
                var List = await _empresaService.FindAsync(consulta);
                return View(List);
            }
        }

        public async Task<IActionResult> Create()
        {
            var viewModel = new EmpresaFormViewModel();
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Empresa empresa)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new EmpresaFormViewModel();
                return View(viewModel);
            }
            await _empresaService.InsertAsync(empresa);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Error), new { message = "Id não informado!" });

            var obj = await _empresaService.FindByIdAsync(id.Value);
            if (obj == null)
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });

            EmpresaFormViewModel viewModel = new EmpresaFormViewModel { Empresa = obj };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _empresaService.RemoveAsync(id);
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

            var obj = await _empresaService.FindByIdAsync(id.Value);
            if (obj == null)
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });

            EmpresaFormViewModel viewModel = new EmpresaFormViewModel { Empresa = obj };
            return View(viewModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não informado!" });
            }
            var obj = await _empresaService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });
            }

            EmpresaFormViewModel viewModel = new EmpresaFormViewModel { Empresa = obj };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Empresa empresa)
        {
            if (!ModelState.IsValid)
            {
                EmpresaFormViewModel viewModel = new EmpresaFormViewModel { Empresa = empresa };
                View(viewModel);
            }
            if (id != empresa.Id)
            {
                return BadRequest();
            }
            try
            {
                await _empresaService.UpdateAsync(empresa);
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