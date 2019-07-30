using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SiacWeb.Services;
using SiacWeb.Models;
using SiacWeb.Models.ViewModels;
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
        public IActionResult Index()
        {
            var List = _empresaService.FindAll();
            return View(List);
        }
        public IActionResult Create()
        {
            var viewModel = new EmpresaFormViewModel();
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Empresa empresa)
        {
            _empresaService.Insert(empresa);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var obj = _empresaService.FindById(id.Value);
            if (obj == null)
                return NotFound();

            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _empresaService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            var obj = _empresaService.FindById(id.Value);
            if (obj == null)
                return NotFound();

            return View(obj);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _empresaService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            EmpresaFormViewModel viewModel = new EmpresaFormViewModel { Empresa = obj };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Empresa empresa)
        {
            if (id != empresa.Id)
            {
                return BadRequest();
            }
            try
            {
                _empresaService.Update(empresa);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (DbConcurrencyException)
            {
                return BadRequest();
            }
        }
    }
}