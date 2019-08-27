using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SiacWeb.Models;
using SiacWeb.Comum;
using SiacWeb.Services.Exceptions;
using X.PagedList;

namespace SiacWeb.Services
{
    public class UsuarioService
    {
        private readonly SiacWebIdentityContext _context;

        public UsuarioService(SiacWebIdentityContext context)
        {
            _context = context;
        }
        
        public async Task<Usuario> FindByIdAsync(string id)
        {
            return await _context.Usuario.FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task<IPagedList<Usuario>> FindAllAsync(int pagina)
        {
            return await _context.Usuario.OrderBy(obj => obj.Id).ToPagedListAsync(pagina, Constantes.QuantidadeRegistrosPorPagina);
        }

        public async Task<IPagedList<Usuario>> FindAsync(int pagina, string consulta)
        {
            var result = from obj in _context.Usuario select obj;
            result = result.Where(x => x.UserName.Contains(consulta));

            return await result.OrderBy(x => x.Id).ToPagedListAsync(pagina, Constantes.QuantidadeRegistrosPorPagina);
        }

        public async Task RemoveAsync(string id)
        {
            try
            {
                var obj = await _context.Usuario.FindAsync(id);
                _context.Usuario.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException(e.Message);
            }
        }

        public async Task RemoveRoleAsync(string roleName)
        {
            try
            {
                var objRoler = await _context.Roles.FirstOrDefaultAsync(x => x.Name == roleName);
                var obj = await _context.UserRoles.FirstOrDefaultAsync(x => x.RoleId == objRoler.Id);

                if (obj != null)
                {
                    _context.UserRoles.Remove(obj);
                    await _context.SaveChangesAsync();
                }
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException(e.Message);
            }
        }
    }
}