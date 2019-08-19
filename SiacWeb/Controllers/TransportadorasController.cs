using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SiacWeb.Services;
using SiacWeb.Models;
using SiacWeb.Comum;
using SiacWeb.Models.ViewModels;
using SiacWeb.Services.Exceptions;
using Microsoft.AspNetCore.Authorization;

namespace SiacWeb.Controllers
{
    [Authorize(Roles = Perfil.Admin + ", " + Perfil.Diretor + ", " + Perfil.Gerente)]
    public class TransportadorasController : Controller
    {
        private readonly TransportadoraService _transportadoraService;
        private readonly EmpresaService _empresaService;

        public TransportadorasController(TransportadoraService transportadoraService, EmpresaService empresaService)
        {
            _transportadoraService = transportadoraService;
            _empresaService = empresaService;
        }

        public async Task<IActionResult> Index(int? pagina, string consulta)
        {
            int page = pagina ?? 1;
            ViewData["Consulta"] = consulta;
            if (consulta == null)
            {
                var List = await _transportadoraService.FindAllAsync(page);
                return View(List);
            }
            else
            {
                var List = await _transportadoraService.FindAsync(page, consulta);
                return View(List);
            }
        }

        public async Task<IActionResult> Create()
        {
            var empresas = await _empresaService.FindAllAsync();
            TransportadoraFormViewModel viewModel = new TransportadoraFormViewModel { Empresas = empresas };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Transportadora transportadora)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new TransportadoraFormViewModel();
                return View(viewModel);
            }
            await _transportadoraService.InsertAsync(transportadora);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Error), new { message = "Id não informado!" });

            var obj = await _transportadoraService.FindByIdAsync(id.Value);
            if (obj == null)
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });

            TransportadoraFormViewModel viewModel = new TransportadoraFormViewModel { Transportadora = obj };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _transportadoraService.RemoveAsync(id);
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

            var obj = await _transportadoraService.FindByIdAsync(id.Value);
            if (obj == null)
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });

            TransportadoraFormViewModel viewModel = new TransportadoraFormViewModel { Transportadora = obj };
            return View(viewModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não informado!" });
            }
            var obj = await _transportadoraService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });
            }

            var empresas = await _empresaService.FindAllAsync();
            TransportadoraFormViewModel viewModel = new TransportadoraFormViewModel { Transportadora = obj, Empresas = empresas };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Transportadora transportadora)
        {
            if (!ModelState.IsValid)
            {
                TransportadoraFormViewModel viewModel = new TransportadoraFormViewModel { Transportadora = transportadora };
                return View(viewModel);
            }
            if (id != transportadora.Id)
            {
                return BadRequest();
            }
            try
            {
                await _transportadoraService.UpdateAsync(transportadora);
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