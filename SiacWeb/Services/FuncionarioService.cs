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
    public class FuncionarioService : BaseService
    {
        public FuncionarioService(SiacWebContext context, IUser user, AuditoriaService auditoriaService) : base(context, user, auditoriaService) { }

        public async Task<Funcionario> FindByIdAsync(string empresaId, int id)
        {
            return await _context.Funcionario.FirstOrDefaultAsync(obj => obj.EmpresaId == int.Parse(empresaId) && obj.Id == id);
        }

        public async Task<IPagedList<Funcionario>> FindAllAsync(int pagina, string empresaId)
        {
            return await _context.Funcionario.Where(obj => obj.EmpresaId == int.Parse(empresaId)).OrderBy(obj => obj.Id).ToPagedListAsync(pagina, Constantes.QuantidadeRegistrosPorPagina);
        }

        public async Task<List<Funcionario>> FindAllAsync(string empresaId)
        {
            return await _context.Funcionario
                .Where(obj => obj.EmpresaId == int.Parse(empresaId))
                .OrderBy(obj => obj.Id)
                .ToListAsync();
        }

        public async Task<IPagedList<Funcionario>> FindAsync(int pagina, string empresaId, string consulta)
        {
            var result = from obj in _context.Funcionario select obj;

            if (consulta.All(char.IsDigit))
                result = result.Where(x => x.Id == int.Parse(consulta));
            else
                result = result.Where(x => x.Nome.Contains(consulta));

            return await result.Where(obj => obj.EmpresaId == int.Parse(empresaId)).OrderBy(x => x.Id).ToPagedListAsync(pagina, Constantes.QuantidadeRegistrosPorPagina);
        }

        public async Task InsertAsync(Funcionario obj)
        {
            obj.Usuario = _user.Name;
            _context.Add(obj);
            await _context.SaveChangesAsync();
            await Auditoria(obj.EmpresaId,
                Modulo.Gerencia,
                SubModulo.Funcionario,
                Operacao.Inclusao,
                "TODO");
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
                obj.DataAlteracao = DateTime.Now;
                obj.Usuario = _user.Name;
                _context.Update(obj);
                await _context.SaveChangesAsync();
                await Auditoria(obj.EmpresaId,
                    Modulo.Gerencia,
                    SubModulo.Funcionario,
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
                var obj = await _context.Funcionario.FindAsync(id);
                _context.Funcionario.Remove(obj);
                await _context.SaveChangesAsync();
                await Auditoria(obj.EmpresaId,
                    Modulo.Gerencia,
                    SubModulo.Funcionario,
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