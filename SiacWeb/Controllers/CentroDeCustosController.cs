﻿using System;
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
    [Authorize(Roles = Perfil.Admin + ", " + Perfil.Diretor)]
    public class CentroDeCustosController : BaseController
    {
        private readonly CentroDeCustoService _centroDeCustoService;
        private readonly EmpresaService _empresaService;        

        public CentroDeCustosController(CentroDeCustoService centroDeCustoService, EmpresaService empresaService)
        {
            _centroDeCustoService = centroDeCustoService;
            _empresaService = empresaService;
        }
        public async Task<IActionResult> Index(int? pagina, string consulta)
        {
            int page = pagina ?? 1;
            ViewData["Consulta"] = consulta;
            if (consulta == null)
            {
                var List = await _centroDeCustoService.FindAllAsync(page, EmpresaId);
                return View(List);
            }
            else
            {
                var List = await _centroDeCustoService.FindAsync(page, EmpresaId, consulta);
                return View(List);
            }
        }

        public async Task<IActionResult> Create()
        {
            var empresas = await _empresaService.FindAllAsync();
            CentroDeCustoFormViewModel viewModel = new CentroDeCustoFormViewModel { Empresas = empresas};

            ViewBag.EmpresaId = EmpresaId;
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CentroDeCusto centroDeCusto)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CentroDeCustoFormViewModel();
                return View(viewModel);
            }
            centroDeCusto.EmpresaId = int.Parse(EmpresaId);
            await _centroDeCustoService.InsertAsync(centroDeCusto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Error), new { message = "Id não informado!" });

            var obj = await _centroDeCustoService.FindByIdAsync(EmpresaId, id.Value);
            if (obj == null)
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });
            
            CentroDeCustoFormViewModel viewModel = new CentroDeCustoFormViewModel { CentroDeCusto = obj };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _centroDeCustoService.RemoveAsync(id);
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

            var obj = await _centroDeCustoService.FindByIdAsync(EmpresaId, id.Value);
            if (obj == null)
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });

            CentroDeCustoFormViewModel viewModel = new CentroDeCustoFormViewModel { CentroDeCusto = obj };
            return View(viewModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não informado!" });
            }
            var obj = await _centroDeCustoService.FindByIdAsync(EmpresaId, id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });
            }

            var empresas = await _empresaService.FindAllAsync();
            CentroDeCustoFormViewModel viewModel = new CentroDeCustoFormViewModel { CentroDeCusto = obj, Empresas = empresas };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CentroDeCusto centroDeCusto)
        {
            if (!ModelState.IsValid)
            {
                CentroDeCustoFormViewModel viewModel = new CentroDeCustoFormViewModel { CentroDeCusto = centroDeCusto };
                return View(viewModel);
            }
            if (id != centroDeCusto.Id)
            {
                return BadRequest();
            }
            try
            {
                centroDeCusto.EmpresaId = int.Parse(EmpresaId);
                await _centroDeCustoService.UpdateAsync(centroDeCusto);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }
    }
}