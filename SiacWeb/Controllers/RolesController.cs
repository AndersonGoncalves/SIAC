using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SiacWeb.Services;
using SiacWeb.Comum;
using SiacWeb.Models.ViewModels;
using SiacWeb.Services.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace SiacWeb.Controllers
{
    [Authorize(Roles = Perfil.Admin + ", " + Perfil.Diretor + ", " + Perfil.Gerente)]
    public class RolesController : Controller
    {
        private readonly RoleService _roleService;

        public RolesController(RoleService roleService)
        {
            _roleService = roleService;
        }
        public async Task<IActionResult> Index(int? pagina, string consulta)
        {
            int page = pagina ?? 1;
            ViewData["Consulta"] = consulta;
            if (consulta == null)
            {
                var List = await _roleService.FindAllAsync(page);
                return View(List);
            }
            else
            {
                var List = await _roleService.FindAsync(page, consulta);
                return View(List);
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IdentityRole role)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _roleService.InsertAsync(role);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
                return RedirectToAction(nameof(Error), new { message = "Id não informado!" });

            var obj = await _roleService.FindByIdAsync(id);
            if (obj == null)
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePost(string id)
        {
            try
            {
                await _roleService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (IntegrityException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
                return RedirectToAction(nameof(Error), new { message = "Id não infomado!" });

            var obj = await _roleService.FindByIdAsync(id);
            if (obj == null)
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });

            return View();
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não informado!" });
            }
            var obj = await _roleService.FindByIdAsync(id);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, IdentityRole role)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (id != role.Id)
            {
                return BadRequest();
            }
            try
            {
                await _roleService.UpdateAsync(role);
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