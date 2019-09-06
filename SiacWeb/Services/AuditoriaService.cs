using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SiacWeb.Models;
using SiacWeb.Comum;
using X.PagedList;
using SiacWeb.Enums;

namespace SiacWeb.Services
{
    public class AuditoriaService
    {
        private readonly SiacWebContext _context;

        public AuditoriaService(SiacWebContext context)
        {
            _context = context;
        }

        public async Task<Auditoria> FindByIdAsync(string empresaId, int id)
        {
            return await _context.Auditoria.FirstOrDefaultAsync(obj => obj.EmpresaId == int.Parse(empresaId) && obj.Id == id);
        }

        public async Task<IPagedList<Auditoria>> FindAllAsync(int pagina, string empresaId)
        {
            return await _context.Auditoria.Where(obj => obj.EmpresaId == int.Parse(empresaId)).OrderByDescending(obj => obj.Id).ToPagedListAsync(pagina, Constantes.QuantidadeRegistrosPorPagina);
        }

        public async Task<IPagedList<Auditoria>> FindAsync(int pagina, string empresaId, string consulta)
        {
            var result = from obj in _context.Auditoria select obj;
            //TODO
            /*if (consulta.All(char.IsDigit))
                result = result.Where(x => x.Modulo == int.Parse(consulta));
            else
                result = result.Where(x => x.Modulo.Contains(consulta));*/

            return await result.Where(obj => obj.EmpresaId == int.Parse(empresaId)).OrderByDescending(x => x.Id).ToPagedListAsync(pagina, Constantes.QuantidadeRegistrosPorPagina);
        }

        public async Task<Auditoria> FindByUsuarioAsync(string empresaId, string usuario)
        {
            return await _context.Auditoria.FirstOrDefaultAsync(obj => obj.EmpresaId == int.Parse(empresaId) && obj.Usuario.Contains(usuario));
        }

        public async Task<Auditoria> FindByDataCadastroAsync(string empresaId, DateTime dataCadastro)
        {
            return await _context.Auditoria.FirstOrDefaultAsync(obj => obj.EmpresaId == int.Parse(empresaId) && obj.DataCadastro == dataCadastro);
        }

        public async Task<Auditoria> FindByModuloAsync(string empresaId, Modulo modulo)
        {
            return await _context.Auditoria.FirstOrDefaultAsync(obj => obj.EmpresaId == int.Parse(empresaId) && obj.Modulo == modulo);
        }        

        public async Task InsertAsync(Auditoria obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }
    }
}