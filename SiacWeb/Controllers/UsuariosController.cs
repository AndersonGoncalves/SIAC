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
using System.Collections.Generic;

namespace SiacWeb.Controllers
{
    [Authorize(Roles = Perfil.Admin + ", " + Perfil.Diretor + ", " + Perfil.Supervisor + ", " + Perfil.Gerente)]
    public class UsuariosController : BaseController
    {
        private readonly UsuarioService _usuarioService;
        private readonly RoleService _roleService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        //[BindProperty]
        //public List<string> ListaRoles { get; set; }

        public UsuariosController(UsuarioService usuarioService, RoleService roleService, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _usuarioService = usuarioService;
            _roleService = roleService;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index(int? pagina, string consulta)
        {
            int page = pagina ?? 1;
            ViewData["Consulta"] = consulta;
            if (consulta == null)
            {
                var List = await _usuarioService.FindAllAsync(page);
                return View(List);
            }
            else
            {
                var List = await _usuarioService.FindAsync(page, consulta);
                return View(List);
            }
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
                return RedirectToAction(nameof(Error), new { message = "Id não informado!" });

            var obj = await _usuarioService.FindByIdAsync(id);
            if (obj == null)
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });

            var roles = await _roleService.FindAllAsync();
            var userRoles = await _userManager.GetRolesAsync(obj);
            UsuarioFormViewModel viewModel = new UsuarioFormViewModel { Usuario = obj, Roles = roles, UserRoles = userRoles };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePost(string id)
        {
            try
            {
                await _usuarioService.RemoveAsync(id);
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

            var obj = await _usuarioService.FindByIdAsync(id);
            if (obj == null)
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });

            var roles = await _roleService.FindAllAsync();
            var userRoles = await _userManager.GetRolesAsync(obj);
            UsuarioFormViewModel viewModel = new UsuarioFormViewModel { Usuario = obj, Roles = roles, UserRoles = userRoles };
            return View(viewModel);
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

        public async Task<IActionResult> Permissoes(string id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não informado!" });
            }
            var obj = await _usuarioService.FindByIdAsync(id);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });
            }
            
            var roles = await _roleService.FindAllAsync();
            var userRoles = await _userManager.GetRolesAsync(obj);
            UsuarioFormViewModel viewModel = new UsuarioFormViewModel { Usuario = obj, Roles = roles, UserRoles = userRoles };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Permissoes(string id, List<string> listaRoles)
        {
            try
            {
                var user = await _usuarioService.FindByIdAsync(id);

                //Excluindo todas as roles do usuário
                var rol = await _roleService.FindAllAsync();
                foreach (var item in rol)
                {
                    await _userManager.RemoveFromRoleAsync(user, item.Name);
                }                

                //Adiciona as roles listadas ao usuário
                foreach (var item in listaRoles)
                {
                    var applicationRole = await _roleManager.FindByNameAsync(item);
                    if (applicationRole != null)
                    {
                        await _userManager.AddToRoleAsync(user, applicationRole.Name);
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch (IntegrityException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }
    }
}