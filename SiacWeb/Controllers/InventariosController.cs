using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SiacWeb.Controllers.Comum;
using SiacWeb.Services;
using SiacWeb.Models;
using SiacWeb.Comum;
using SiacWeb.Models.ViewModels;
using SiacWeb.Services.Exceptions;
using Microsoft.AspNetCore.Authorization;
using SiacWeb.Enums;

namespace SiacWeb.Controllers
{
    [Authorize(Roles = Perfil.Admin + ", " + Perfil.Diretor + ", " + Perfil.Supervisor + ", " + Perfil.Gerente + ", " + Perfil.Estoquista)]
    public class InventariosController : BaseController
    {
        private readonly InventarioService _inventarioService;
        private readonly InventarioItemService _inventarioItemService;
        private readonly CentroDeCustoService _centroDeCustoService;
        private readonly FuncionarioService _funcionarioService;

        public InventariosController(InventarioService inventarioService, InventarioItemService inventarioItemService, CentroDeCustoService centroDeCustoService, FuncionarioService funcionarioService)
        {
            _inventarioService = inventarioService;
            _inventarioItemService = inventarioItemService;
            _centroDeCustoService = centroDeCustoService;
            _funcionarioService = funcionarioService;
        }

        public async Task<IActionResult> Index(int? pagina, string consulta)
        {
            int page = pagina ?? 1;
            ViewData["Consulta"] = consulta;
            if (consulta == null)
            {
                var List = await _inventarioService.FindAllAsync(page, EmpresaId);
                return View(List);
            }
            else
            {
                var List = await _inventarioService.FindAsync(page, EmpresaId, consulta);
                return View(List);
            }
        }        
        
        public async Task<IActionResult> Create()
        {
            var centrosDeCustos = await _centroDeCustoService.FindAllAsync(EmpresaId);
            var funcionarios = await _funcionarioService.FindAllAsync(EmpresaId);
            var viewModel = new InventarioFormViewModel { CentrosDeCustos = centrosDeCustos, Funcionarios = funcionarios };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Inventario inventario)
        {
            if (!ModelState.IsValid)
            {
                var centrosDeCustos = await _centroDeCustoService.FindAllAsync(EmpresaId);
                var funcionarios = await _funcionarioService.FindAllAsync(EmpresaId);
                var viewModel = new InventarioFormViewModel { CentrosDeCustos = centrosDeCustos, Funcionarios = funcionarios, Inventario = inventario };
                return View(viewModel);
            }
            await _inventarioService.InsertAsync(inventario);
            return RedirectToAction(nameof(Create), "InventariosItens", new { inventarioId = inventario.Id });
        }
        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Error), new { message = "Id não informado!" });

            var obj = await _inventarioService.FindByIdAsync(EmpresaId, id.Value);
            if (obj == null)
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });

            if (obj.Status == StatusInventario.Processado)
                return RedirectToAction(nameof(Error), new { message = "Inventário já processado!" });

            var viewModel = new InventarioFormViewModel { Inventario = obj };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _inventarioService.RemoveAsync(id);
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

            var obj = await _inventarioService.FindByIdAsync(EmpresaId, id.Value);
            if (obj == null)
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });

            var inventarioItens = await _inventarioItemService.FindByInventarioIdAsync(EmpresaId, int.Parse(id.ToString()));
            var viewModel = new InventarioFormViewModel { Inventario = obj, InventarioItens = inventarioItens };
            return View(viewModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Error), new { message = "Id não informado!" });

            var obj = await _inventarioService.FindByIdAsync(EmpresaId, id.Value);
            if (obj == null)
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });

            if (obj.Status == StatusInventario.Processado)
                return RedirectToAction(nameof(Error), new { message = "Inventário já processado!" });

            var centrosDeCustos = await _centroDeCustoService.FindAllAsync(EmpresaId);
            var funcionarios = await _funcionarioService.FindAllAsync(EmpresaId);
            var viewModel = new InventarioFormViewModel { Inventario = obj, CentrosDeCustos = centrosDeCustos, Funcionarios = funcionarios };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Inventario inventario)
        {
            if (!ModelState.IsValid)
            {
                var centrosDeCustos = await _centroDeCustoService.FindAllAsync(EmpresaId);
                var funcionarios = await _funcionarioService.FindAllAsync(EmpresaId);
                var viewModel = new InventarioFormViewModel { Inventario = inventario, CentrosDeCustos = centrosDeCustos, Funcionarios = funcionarios };
                return View(viewModel);
            }
            if (id != inventario.Id)
            {
                return BadRequest();
            }
            try
            {
                await _inventarioService.UpdateAsync(inventario);
                return RedirectToAction(nameof(Create), "InventariosItens", new { inventarioId = inventario.Id });
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public async Task<IActionResult> Processar(int id)
        {
            //TODO
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Processar(int id, Inventario inventario)
        {
            //TODO
            return View();
        }
    }
}