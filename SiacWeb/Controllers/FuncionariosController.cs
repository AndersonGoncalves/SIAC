﻿using System;
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
    [Authorize(Roles = Perfil.Admin + ", " + Perfil.Diretor + ", " + Perfil.Supervisor + ", " + Perfil.Gerente)]
    public class FuncionariosController : BaseController
    {
        private readonly FuncionarioService _funcionarioService;
        private readonly EmpresaService _empresaService;
        private readonly CentroDeCustoService _centroDeCustoService;

        public FuncionariosController(FuncionarioService funcionarioService, EmpresaService empresaService, CentroDeCustoService centroDeCustoService)
        {
            _funcionarioService = funcionarioService;
            _empresaService = empresaService;
            _centroDeCustoService = centroDeCustoService;
        }
        public async Task<IActionResult> Index(int? pagina, string consulta)
        {
            int page = pagina ?? 1;
            ViewData["Consulta"] = consulta;
            if (consulta == null)
            {
                var List = await _funcionarioService.FindAllAsync(page, EmpresaId);
                return View(List);
            }
            else
            {
                var List = await _funcionarioService.FindAsync(page, EmpresaId, consulta);
                return View(List);
            }
        }

        public async Task<IActionResult> Create()
        {
            var empresas = await _empresaService.FindAllAsync();
            var centroDeCustos = await _centroDeCustoService.FindAllAsync(EmpresaId);
            FuncionarioFormViewModel viewModel = new FuncionarioFormViewModel { Empresas = empresas, CentrosDeCustos = centroDeCustos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Funcionario funcionario)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new FuncionarioFormViewModel();
                return View(viewModel);
            }
            funcionario.EmpresaId = int.Parse(EmpresaId);
            await _funcionarioService.InsertAsync(funcionario);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Error), new { message = "Id não informado!" });

            var obj = await _funcionarioService.FindByIdAsync(EmpresaId, id.Value);
            if (obj == null)
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });

            FuncionarioFormViewModel viewModel = new FuncionarioFormViewModel { Funcionario = obj };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _funcionarioService.RemoveAsync(id);
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

            var obj = await _funcionarioService.FindByIdAsync(EmpresaId, id.Value);
            if (obj == null)
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });

            FuncionarioFormViewModel viewModel = new FuncionarioFormViewModel { Funcionario = obj };
            return View(viewModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não informado!" });
            }
            var obj = await _funcionarioService.FindByIdAsync(EmpresaId, id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });
            }

            var empresas = await _empresaService.FindAllAsync();
            var centroDeCustos = await _centroDeCustoService.FindAllAsync(EmpresaId);
            FuncionarioFormViewModel viewModel = new FuncionarioFormViewModel { Funcionario = obj, Empresas = empresas, CentrosDeCustos = centroDeCustos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Funcionario funcionario)
        {
            if (!ModelState.IsValid)
            {
                FuncionarioFormViewModel viewModel = new FuncionarioFormViewModel { Funcionario = funcionario };
                return View(viewModel);
            }
            if (id != funcionario.Id)
            {
                return BadRequest();
            }
            try
            {
                funcionario.EmpresaId = int.Parse(EmpresaId);
                await _funcionarioService.UpdateAsync(funcionario);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }
    }
}