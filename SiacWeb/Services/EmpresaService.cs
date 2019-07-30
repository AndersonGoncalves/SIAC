using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SiacWeb.Models;
using SiacWeb.Services.Exceptions;

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
        public void Update(Empresa obj)
        {
            if (!_context.Empresa.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id não encontrado!");
            }

            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}