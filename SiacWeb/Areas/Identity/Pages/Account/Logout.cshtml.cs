using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SiacWeb.Comum;

namespace SiacWeb.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<LogoutModel> _logger;

        public LogoutModel(SignInManager<IdentityUser> signInManager, ILogger<LogoutModel> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
        }

        public void OnGet()
        {
        }

        //public async Task<IActionResult> OnPost(string returnUrl = null)
        public async Task<IActionResult> OnPost(string returnUrl)
        {
            //Limpando a Session atual
            HttpContext.Session.Remove(Constantes.EmpresaId);
            HttpContext.Session.Clear();

            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");

            //Redirecionando sempre para o home quando sair do sistema
            returnUrl = "/Home";

            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return Page();
            }
        }
    }
}