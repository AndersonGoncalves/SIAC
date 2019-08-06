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

        public async Task<List<Empresa>> FindAllAsync()
        {
            return await _context.Empresa.ToListAsync();
        }

        public async Task<Empresa> FindByIdAsync(int id)
        {
            return await _context.Empresa.FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task<List<Empresa>> FindAsync(string consulta)
        {
            var result = from obj in _context.Empresa select obj;
            
            if (consulta.All(char.IsDigit))
                result = result.Where(x => x.Id == int.Parse(consulta));
            else
                result = result.Where(x => x.Descricao.Contains(consulta));

            return await result.ToListAsync();
        }

        public async Task InsertAsync(Empresa obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Empresa.FindAsync(id);
                _context.Empresa.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException(e.Message);
            }
        }

        public async Task UpdateAsync(Empresa obj)
        {
            bool TemAlgum = await _context.Empresa.AnyAsync(x => x.Id == obj.Id);
            if (!TemAlgum)
            {
                throw new NotFoundException("Id não encontrado!");
            }

            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}