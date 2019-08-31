using Microsoft.AspNetCore.Mvc;
using SiacWeb.Comum;
using Microsoft.AspNetCore.Http;

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
    }
}