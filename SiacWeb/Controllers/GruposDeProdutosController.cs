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
    public class GruposDeProdutosController : BaseController
    {
        private readonly GrupoDeProdutoService _grupoDeProdutoService;
        private readonly EmpresaService _empresaService;

        public GruposDeProdutosController(GrupoDeProdutoService grupoDeProdutoService, EmpresaService empresaService)
        {
            _grupoDeProdutoService = grupoDeProdutoService;
            _empresaService = empresaService;
        }
        public async Task<IActionResult> Index(int? pagina, string consulta)
        {
            int page = pagina ?? 1;
            ViewData["Consulta"] = consulta;
            if (consulta == null)
            {
                var List = await _grupoDeProdutoService.FindAllAsync(page, EmpresaId);
                return View(List);
            }
            else
            {
                var List = await _grupoDeProdutoService.FindAsync(page, EmpresaId, consulta);
                return View(List);
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GrupoDeProduto grupoDeProduto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            grupoDeProduto.EmpresaId = int.Parse(EmpresaId);
            await _grupoDeProdutoService.InsertAsync(grupoDeProduto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Error), new { message = "Id não informado!" });

            var obj = await _grupoDeProdutoService.FindByIdAsync(EmpresaId, id.Value);
            if (obj == null)
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _grupoDeProdutoService.RemoveAsync(id);
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

            var obj = await _grupoDeProdutoService.FindByIdAsync(EmpresaId, id.Value);
            if (obj == null)
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });

            return View(obj);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não informado!" });
            }
            var obj = await _grupoDeProdutoService.FindByIdAsync(EmpresaId, id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, GrupoDeProduto grupoDeProduto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (id != grupoDeProduto.Id)
            {
                return BadRequest();
            }
            try
            {
                grupoDeProduto.EmpresaId = int.Parse(EmpresaId);
                await _grupoDeProdutoService.UpdateAsync(grupoDeProduto);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }
    }
}