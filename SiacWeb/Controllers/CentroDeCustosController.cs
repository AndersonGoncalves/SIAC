using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SiacWeb.Services;
using SiacWeb.Models;
using SiacWeb.Models.ViewModels;
using SiacWeb.Services.Exceptions;

namespace SiacWeb.Controllers
{
    public class CentroDeCustosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}