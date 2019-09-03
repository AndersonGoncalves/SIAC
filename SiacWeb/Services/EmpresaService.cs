using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SiacWeb.Services.Comum;
using SiacWeb.Models;
using SiacWeb.Comum;
using SiacWeb.Models.Interface;
using SiacWeb.Services.Exceptions;
using X.PagedList;
using SiacWeb.Enums;

namespace SiacWeb.Services
{
    public class EmpresaService : BaseService
    {
        public EmpresaService(SiacWebContext context, IUser user, AuditoriaService auditoriaService) : base(context, user, auditoriaService) { }

        public async Task<Empresa> FindByIdAsync(int id)
        {
            return await _context.Empresa.FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task<IPagedList<Empresa>> FindAllAsync(int pagina)
        {
            return await _context.Empresa.OrderBy(x => x.Id).ToPagedListAsync(pagina, Constantes.QuantidadeRegistrosPorPagina);
        }

        public async Task<List<Empresa>> FindAllAsync()
        {
            return await _context.Empresa.OrderBy(x => x.Id).ToListAsync();
        }

        public List<Empresa> ListarEmpresas()
        {
            return _context.Empresa.OrderBy(x => x.Id).ToList();
        }

        public async Task<IPagedList<Empresa>> FindAsync(int pagina, string consulta)
        {
            var result = from obj in _context.Empresa select obj;
            
            if (consulta.All(char.IsDigit))
                result = result.Where(x => x.Id == int.Parse(consulta));
            else
                result = result.Where(x => x.Descricao.Contains(consulta));

            return await result.OrderBy(x => x.Id).ToPagedListAsync(pagina, Constantes.QuantidadeRegistrosPorPagina);
        }

        public async Task InsertAsync(Empresa obj)
        {
            obj.Usuario = _user.Name;
            _context.Add(obj);
            await _context.SaveChangesAsync();
            await Auditoria(obj.Id,
                Modulo.Gerencia,
                SubModulo.Empresa,
                Operacao.Inclusao,
                "TODO");
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
                obj.DataAlteracao = DateTime.Now;
                obj.Usuario = _user.Name;
                _context.Update(obj);
                await _context.SaveChangesAsync();
                await Auditoria(obj.Id,
                    Modulo.Gerencia,
                    SubModulo.Empresa,
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
                var obj = await _context.Empresa.FindAsync(id);
                _context.Empresa.Remove(obj);
                await _context.SaveChangesAsync();
                await Auditoria(obj.Id,
                    Modulo.Gerencia,
                    SubModulo.Empresa,
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