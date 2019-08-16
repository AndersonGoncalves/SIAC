﻿using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SiacWeb.Models;
using SiacWeb.Comum;
using SiacWeb.Services.Exceptions;
using X.PagedList;

namespace SiacWeb.Services
{
    public class FornecedorService
    {
        private readonly SiacWebContext _context;

        public FornecedorService(SiacWebContext context)
        {
            _context = context;
        }

        public async Task<Fornecedor> FindByIdAsync(int id)
        {
            return await _context.Fornecedor.FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task<IPagedList<Fornecedor>> FindAllAsync(int pagina)
        {
            return await _context.Fornecedor.OrderBy(obj => obj.Id).ToPagedListAsync(pagina, Constantes.QuantidadeRegistrosPorPagina);
        }

        public async Task<IPagedList<Fornecedor>> FindAsync(int pagina, string consulta)
        {
            var result = from obj in _context.Fornecedor select obj;

            if (consulta.All(char.IsDigit))
                result = result.Where(x => x.Id == int.Parse(consulta));
            else
                result = result.Where(x => x.RazaoSocial.Contains(consulta));

            return await result.OrderBy(x => x.Id).ToPagedListAsync(pagina, Constantes.QuantidadeRegistrosPorPagina);
        }

        public async Task InsertAsync(Fornecedor obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Fornecedor.FindAsync(id);
                _context.Fornecedor.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException(e.Message);
            }
        }

        public async Task UpdateAsync(Fornecedor obj)
        {
            bool TemAlgum = await _context.Fornecedor.AnyAsync(x => x.Id == obj.Id);
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