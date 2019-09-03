using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SiacWeb.Services.Comum;
using SiacWeb.Enums;
using SiacWeb.Models;
using SiacWeb.Comum;
using SiacWeb.Models.Interface;
using SiacWeb.Services.Exceptions;
using X.PagedList;

namespace SiacWeb.Services
{
    public class AutonomoService : BaseService
    {
        public AutonomoService(SiacWebContext context, IUser user, AuditoriaService auditoriaService) : base(context, user, auditoriaService) { }

        public async Task<Autonomo> FindByIdAsync(string empresaId, int id)
        {
            return await _context.Autonomo.FirstOrDefaultAsync(obj => obj.EmpresaId == int.Parse(empresaId) && obj.Id == id);
        }

        public async Task<IPagedList<Autonomo>> FindAllAsync(int pagina, string empresaId)
        {
            return await _context.Autonomo.Where(obj => obj.EmpresaId == int.Parse(empresaId)).OrderBy(obj => obj.Id).ToPagedListAsync(pagina, Constantes.QuantidadeRegistrosPorPagina);
        }

        public async Task<IPagedList<Autonomo>> FindAsync(int pagina, string empresaId, string consulta)
        {
            var result = from obj in _context.Autonomo select obj;

            if (consulta.All(char.IsDigit))
                result = result.Where(x => x.Id == int.Parse(consulta));
            else
                result = result.Where(x => x.RazaoSocial.Contains(consulta));

            return await result.Where(obj => obj.EmpresaId == int.Parse(empresaId)).OrderBy(x => x.Id).ToPagedListAsync(pagina, Constantes.QuantidadeRegistrosPorPagina);
        }

        public async Task InsertAsync(Autonomo obj)
        {
            obj.Usuario = _user.Name;
            _context.Add(obj);
            await _context.SaveChangesAsync();
            await Auditoria(obj.EmpresaId,
                Modulo.Gerencia,
                SubModulo.Autonomo,
                Operacao.Inclusao,
                "TODO");
        }
                
        public async Task UpdateAsync(Autonomo obj)
        {
            bool TemAlgum = await _context.Autonomo.AnyAsync(x => x.Id == obj.Id);
            if (!TemAlgum)
            {
                throw new NotFoundException("Id não encontrado!");
            }

            try
            {
                obj.DataAlteracao = DateTime.Now;
                obj.Usuario = _user.Name;
                _context.Update(obj);
                await _context.SaveChangesAsync();
                await Auditoria(obj.EmpresaId,
                    Modulo.Gerencia,
                    SubModulo.Autonomo,
                    Operacao.Alteracao,
                    "TODO");
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Autonomo.FindAsync(id);
                _context.Autonomo.Remove(obj);
                await _context.SaveChangesAsync();
                await Auditoria(obj.EmpresaId,
                    Modulo.Gerencia,
                    SubModulo.Autonomo,
                    Operacao.Exclusao,
                    "TODO");
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException(e.Message);
            }
        }
    }
}