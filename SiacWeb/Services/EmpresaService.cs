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
        public void Insert(Empresa obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
        public Empresa FindById(int id)
        {
            return _context.Empresa.FirstOrDefault(obj => obj.Id == id);
        }
        public void Remove(int id)
        {
            var obj = _context.Empresa.Find(id);
            _context.Empresa.Remove(obj);
            _context.SaveChanges();
        }
    }
}