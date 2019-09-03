﻿using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SiacWeb.Controllers.Comum;
using SiacWeb.Services;
using SiacWeb.Comum;
using SiacWeb.Models.ViewModels;
using SiacWeb.Services.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace SiacWeb.Controllers
{
    [Authorize(Roles = Perfil.Admin)]
    public class RolesController : BaseController
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