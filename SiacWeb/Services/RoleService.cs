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
using System.Collections.Generic;

namespace SiacWeb.Services
{
    public class RoleService
    {
        private readonly SiacWebIdentityContext _context;

        public RoleService(SiacWebIdentityContext context)
        {
            _context = context;
        }

        public async Task<IdentityRole> FindByIdAsync(string id)
        {
            return await _context.Roles.FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task<IPagedList<IdentityRole>> FindAllAsync(int pagina)
        {
            return await _context.Roles.OrderBy(obj => obj.Name).ToPagedListAsync(pagina, Constantes.QuantidadeRegistrosPorPagina);
        }

        public async Task<List<IdentityRole>> FindAllAsync()
        {
            return await _context.Roles.OrderBy(x => x.Name).ToListAsync();
        }

        public async Task<List<IdentityRole>> ListarTudoMenosAdmin()
        {
            return await _context.Roles.Where(x => x.Name != Perfil.Admin).OrderBy(x => x.Name).ToListAsync();

        }

        public async Task<IPagedList<IdentityRole>> FindAsync(int pagina, string consulta)
        {
            var result = from obj in _context.Roles select obj;
            result = result.Where(x => x.Name.Contains(consulta));

            return await result.OrderBy(x => x.Name).ToPagedListAsync(pagina, Constantes.QuantidadeRegistrosPorPagina);
        }

        public async Task InsertAsync(IdentityRole obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(string id)
        {
            try
            {
                var obj = await _context.Roles.FindAsync(id);
                _context.Roles.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException(e.Message);
            }
        }

        public async Task UpdateAsync(IdentityRole obj)
        {
            bool TemAlgum = await _context.Roles.AnyAsync(x => x.Id == obj.Id);
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