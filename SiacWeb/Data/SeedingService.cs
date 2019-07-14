using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SiacWeb.Models;

namespace SiacWeb.Data
{
    public class SeedingService
    {
        private SiacWebContext _context;

        public SeedingService(SiacWebContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Perfil.Any())
                return;

            Perfil perfil01 = new Perfil { Descricao = "Administrador" };
            Perfil perfil02 = new Perfil { Descricao = "Gerente" };
            Perfil perfil03 = new Perfil { Descricao = "Financeiro" };
            Perfil perfil04 = new Perfil { Descricao = "Caixa" };
            Perfil perfil05 = new Perfil { Descricao = "Vendedor" };
            _context.AddRange(perfil01, perfil02, perfil03, perfil04, perfil05);

            _context.SaveChanges();
        }
    }
}