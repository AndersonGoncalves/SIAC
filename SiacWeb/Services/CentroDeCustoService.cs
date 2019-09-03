using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SiacWeb.Enums;
using SiacWeb.Services.Comum;
using SiacWeb.Models;
using SiacWeb.Comum;
using SiacWeb.Models.Interface;
using SiacWeb.Services.Exceptions;
using X.PagedList;

namespace SiacWeb.Services
{
    public class CentroDeCustoService : BaseService
    {
        public CentroDeCustoService(SiacWebContext context, IUser user, AuditoriaService auditoriaService) : base(context, user, auditoriaService) { }

        public async Task<CentroDeCusto> FindByIdAsync(string empresaId, int id)
        {
            return await _context.CentroDeCusto.FirstOrDefaultAsync(obj => obj.EmpresaId == int.Parse(empresaId) && obj.Id == id);
        }

        public async Task<IPagedList<CentroDeCusto>> FindAllAsync(int pagina, string empresaId)
        {
            return await _context.CentroDeCusto.Where(obj => obj.EmpresaId == int.Parse(empresaId)).OrderBy(obj => obj.Id).ToPagedListAsync(pagina, Constantes.QuantidadeRegistrosPorPagina);
        }

        public async Task<List<CentroDeCusto>> FindAllAsync(string empresaId)
        {
            return await _context.CentroDeCusto.Where(obj => obj.EmpresaId == int.Parse(empresaId)).OrderBy(x => x.Id).ToListAsync();
        }

        public async Task<IPagedList<CentroDeCusto>> FindAsync(int pagina, string empresaId, string consulta)
        {
            var result = from obj in _context.CentroDeCusto select obj;

            if (consulta.All(char.IsDigit))
                result = result.Where(x => x.Id == int.Parse(consulta));
            else
                result = result.Where(x => x.RazaoSocial.Contains(consulta));

            return await result.Where(obj => obj.EmpresaId == int.Parse(empresaId)).OrderBy(x => x.Id).ToPagedListAsync(pagina, Constantes.QuantidadeRegistrosPorPagina);
        }

        public async Task InsertAsync(CentroDeCusto obj)
        {
            obj.Usuario = _user.Name;
            _context.Add(obj);
            await _context.SaveChangesAsync();
            await Auditoria(obj.EmpresaId,
                Modulo.Gerencia,
                SubModulo.CentroDeCusto,
                Operacao.Inclusao,
                "TODO");
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
                obj.DataAlteracao = DateTime.Now;
                obj.Usuario = _user.Name;
                _context.Update(obj);
                await _context.SaveChangesAsync();
                await Auditoria(obj.EmpresaId,
                    Modulo.Gerencia,
                    SubModulo.CentroDeCusto,
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
                var obj = await _context.CentroDeCusto.FindAsync(id);
                _context.CentroDeCusto.Remove(obj);
                await _context.SaveChangesAsync();
                await Auditoria(obj.EmpresaId,
                    Modulo.Gerencia,
                    SubModulo.CentroDeCusto,
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
