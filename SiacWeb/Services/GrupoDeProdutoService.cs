﻿using System;
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
using System.Collections.Generic;

namespace SiacWeb.Services
{
    public class GrupoDeProdutoService : BaseService
    {
        public GrupoDeProdutoService(SiacWebContext context, IUser user, AuditoriaService auditoriaService) : base(context, user, auditoriaService) { }

        public async Task<GrupoDeProduto> FindByIdAsync(string empresaId, int id)
        {
            return await _context.GrupoDeProduto.FirstOrDefaultAsync(obj => obj.EmpresaId == int.Parse(empresaId) && obj.Id == id);
        }

        public async Task<IPagedList<GrupoDeProduto>> FindAllAsync(int pagina, string empresaId)
        {
            return await _context.GrupoDeProduto.Where(obj => obj.EmpresaId == int.Parse(empresaId)).OrderBy(obj => obj.Id).ToPagedListAsync(pagina, Constantes.QuantidadeRegistrosPorPagina);
        }

        public async Task<List<GrupoDeProduto>> FindAllAsync(string empresaId)
        {
            return await _context.GrupoDeProduto.Where(x => x.EmpresaId == int.Parse(empresaId)).OrderBy(x => x.Descricao).ToListAsync();
        }

        public async Task<IPagedList<GrupoDeProduto>> FindAsync(int pagina, string empresaId, string consulta)
        {
            var result = from obj in _context.GrupoDeProduto select obj;

            if (consulta.All(char.IsDigit))
                result = result.Where(x => x.Id == int.Parse(consulta));
            else
                result = result.Where(x => x.Descricao.Contains(consulta));

            return await result.Where(obj => obj.EmpresaId == int.Parse(empresaId)).OrderBy(x => x.Id).ToPagedListAsync(pagina, Constantes.QuantidadeRegistrosPorPagina);
        }

        public async Task InsertAsync(GrupoDeProduto obj)
        {
            obj.Usuario = _user.Name;
            _context.Add(obj);
            await _context.SaveChangesAsync();
            await Auditoria(obj.EmpresaId,
                Modulo.Estoque,
                SubModulo.GrupoDeProduto,
                Operacao.Inclusao,
                "TODO");
        }

        public async Task UpdateAsync(GrupoDeProduto obj)
        {
            bool TemAlgum = await _context.GrupoDeProduto.AnyAsync(x => x.Id == obj.Id);
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
                    Modulo.Estoque,
                    SubModulo.GrupoDeProduto,
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
                var obj = await _context.GrupoDeProduto.FindAsync(id);
                _context.GrupoDeProduto.Remove(obj);
                await _context.SaveChangesAsync();
                await Auditoria(obj.EmpresaId,
                    Modulo.Estoque,
                    SubModulo.GrupoDeProduto,
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