using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SiacWeb.Models;
using SiacWeb.Comum;
using SiacWeb.Models.Interface;
using SiacWeb.Services.Exceptions;
using X.PagedList;

namespace SiacWeb.Services
{
    public class FuncionarioService
    {
        private readonly SiacWebContext _context;
        private readonly IUser _user;

        public FuncionarioService(SiacWebContext context, IUser user)
        {
            _context = context;
            _user = user;
        }

        public async Task<Funcionario> FindByIdAsync(int id)
        {
            return await _context.Funcionario.FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task<IPagedList<Funcionario>> FindAllAsync(int pagina)
        {
            return await _context.Funcionario.OrderBy(obj => obj.Id).ToPagedListAsync(pagina, Constantes.QuantidadeRegistrosPorPagina);
        }

        public async Task<IPagedList<Funcionario>> FindAsync(int pagina, string consulta)
        {
            var result = from obj in _context.Funcionario select obj;

            if (consulta.All(char.IsDigit))
                result = result.Where(x => x.Id == int.Parse(consulta));
            else
                result = result.Where(x => x.Nome.Contains(consulta));

            return await result.OrderBy(x => x.Id).ToPagedListAsync(pagina, Constantes.QuantidadeRegistrosPorPagina);
        }

        public async Task InsertAsync(Funcionario obj)
        {
            obj.Usuario = _user.Name;
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Funcionario.FindAsync(id);
                _context.Funcionario.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException(e.Message);
            }
        }

        public async Task UpdateAsync(Funcionario obj)
        {
            bool TemAlgum = await _context.Funcionario.AnyAsync(x => x.Id == obj.Id);
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