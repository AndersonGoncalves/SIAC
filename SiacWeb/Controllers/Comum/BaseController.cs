using Microsoft.AspNetCore.Mvc;
using SiacWeb.Comum;
using Microsoft.AspNetCore.Http;
using SiacWeb.Models.ViewModels;
using System.Diagnostics;

namespace SiacWeb.Controllers.Comum
{
    public abstract class BaseController : Controller
    {
        internal string EmpresaId
        {
            get
            {
                return HttpContext.Session.GetString(Constantes.EmpresaId);
            }
        }

        internal IActionResult Error(string message)
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