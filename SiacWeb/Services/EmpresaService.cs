using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SiacWeb.Models;

namespace SiacWeb.Services
{
    public class EmpresaService
    {
        private readonly SiacWebContext _context;

        public EmpresaService(SiacWebContext context)
        {
            _context = context;
        }
        public List<Empresa> FindAll()
        {
            return _context.Empresa.ToList();
        }
    }
}
