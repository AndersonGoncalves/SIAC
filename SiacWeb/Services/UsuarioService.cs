using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SiacWeb.Models;
using SiacWeb.Comum;
using SiacWeb.Models.Interface;
using SiacWeb.Services.Exceptions;
using X.PagedList;
using Microsoft.AspNetCore.Identity;

namespace SiacWeb.Services
{
    public class UsuarioService
    {
        private readonly SiacWebIdentityContext _context;

        public UsuarioService(SiacWebIdentityContext context)
        {
            _context = context;
        }

        public async Task<IdentityUser> FindByIdAsync(string id)
        {
            return await _context.Users.FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task<IPagedList<IdentityUser>> FindAllAsync(int pagina)
        {
            return await _context.Users.OrderBy(obj => obj.Id).ToPagedListAsync(pagina, Constantes.QuantidadeRegistrosPorPagina);
        }

        public async Task<IPagedList<IdentityUser>> FindAsync(int pagina, string consulta)
        {
            var result = from obj in _context.Users select obj;
            result = result.Where(x => x.UserName.Contains(consulta));

            return await result.OrderBy(x => x.Id).ToPagedListAsync(pagina, Constantes.QuantidadeRegistrosPorPagina);
        }

        public async Task InsertAsync(IdentityUser obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(string id)
        {
            try
            {
                var obj = await _context.Users.FindAsync(id);
                _context.Users.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException(e.Message);
            }
        }

        public async Task UpdateAsync(IdentityUser obj)
        {
            bool TemAlgum = await _context.Users.AnyAsync(x => x.Id == obj.Id);
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