using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SiacWeb.Controllers.Comum;
using SiacWeb.Services;
using SiacWeb.Comum;
using SiacWeb.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace SiacWeb.Controllers
{
    [Authorize(Roles = Perfil.Admin + ", " + Perfil.Diretor + ", " + Perfil.Supervisor + ", " + Perfil.Gerente)]
    public class AuditoriasController : BaseController
    {
        private readonly AuditoriaService _auditoriaService;

        public AuditoriasController(AuditoriaService auditoriaService)
        {
            _auditoriaService = auditoriaService;
        }

        public async Task<IActionResult> Index(int? pagina, string consulta)
        {
            int page = pagina ?? 1;
            ViewData["Consulta"] = consulta;
            if (consulta == null)
            {
                var List = await _auditoriaService.FindAllAsync(page, EmpresaId);
                return View(List);
            }
            else
            {
                var List = await _auditoriaService.FindAsync(page, EmpresaId, consulta);
                return View(List);
            }
        }
    }
}