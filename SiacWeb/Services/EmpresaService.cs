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

        public async Task InsertAsync(Empresa obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            var obj = await _context.Empresa.FindAsync(id);
            _context.Empresa.Remove(obj);
            await _context.SaveChangesAsync();
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