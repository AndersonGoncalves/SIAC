using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SiacWeb.Models;
using SiacWeb.Comum;
using SiacWeb.Models.Interface;
using SiacWeb.Services.Exceptions;
using X.PagedList;

namespace SiacWeb.Services
{
    public class CentroDeCustoService
    {
        private readonly SiacWebContext _context;
        private readonly IUser _user;

        public CentroDeCustoService(SiacWebContext context, IUser user)
        {
            _context = context;
            _user = user;
        }

        public async Task<CentroDeCusto> FindByIdAsync(int id)
        {
            return await _context.CentroDeCusto.FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task<IPagedList<CentroDeCusto>> FindAllAsync(int pagina)
        {
            return await _context.CentroDeCusto.OrderBy(obj => obj.Id).ToPagedListAsync(pagina, Constantes.QuantidadeRegistrosPorPagina);
        }

        public async Task<List<CentroDeCusto>> FindAllAsync()
        {
            return await _context.CentroDeCusto.OrderBy(x => x.Id).ToListAsync();
        }

        public async Task<IPagedList<CentroDeCusto>> FindAsync(int pagina, string consulta)
        {
            var result = from obj in _context.CentroDeCusto select obj;

            if (consulta.All(char.IsDigit))
                result = result.Where(x => x.Id == int.Parse(consulta));
            else
                result = result.Where(x => x.RazaoSocial.Contains(consulta));

            return await result.OrderBy(x => x.Id).ToPagedListAsync(pagina, Constantes.QuantidadeRegistrosPorPagina);
        }

        public async Task InsertAsync(CentroDeCusto obj)
        {
            obj.Usuario = _user.Name;
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.CentroDeCusto.FindAsync(id);
                _context.CentroDeCusto.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException(e.Message);
            }
        }

        public async Task UpdateAsync(CentroDeCusto obj)
        {
            bool TemAlgum = await _context.CentroDeCusto.AnyAsync(x => x.Id == obj.Id);
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
