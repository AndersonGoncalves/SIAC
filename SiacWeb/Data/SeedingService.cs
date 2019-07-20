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
            if (_context.Empresa.Any())
                return;

            Empresa empresa01 = new Empresa
            {
                RazaoSocial = "RUSSAS",
                NomeFantasia = "RUSSAS",
                Descricao = "RUSSAS",
                CnpjBase = "03868142"
            };
            Empresa empresa02 = new Empresa
            {
                RazaoSocial = "ARACATI",
                NomeFantasia = "ARACATI",
                Descricao = "ARACATI",
                CnpjBase = "00192058"
            };
            Empresa empresa03 = new Empresa
            {
                RazaoSocial = "ASSU",
                NomeFantasia = "ASSU",
                Descricao = "ASSU",
                CnpjBase = "03228342"
            };
            Empresa empresa04 = new Empresa
            {
                RazaoSocial = "MILLA",
                NomeFantasia = "MILLA",
                Descricao = "MILLA",
                CnpjBase = "04951928"
            };
            Empresa empresa05 = new Empresa
            {
                RazaoSocial = "JAGUARIBARA",
                NomeFantasia = "JAGUARIBARA",
                Descricao = "JAGUARIBARA",
                CnpjBase = "04980758"
            };
            Empresa empresa06 = new Empresa
            {
                RazaoSocial = "IRACEMA",
                NomeFantasia = "IRACEMA",
                Descricao = "IRACEMA",
                CnpjBase = "05380221"
            };
            Empresa empresa07 = new Empresa
            {
                RazaoSocial = "MORADA NOVA",
                NomeFantasia = "MORADA NOVA",
                Descricao = "MORADA NOVA",
                CnpjBase = "05532783"
            };
            Empresa empresa08 = new Empresa
            {
                RazaoSocial = "ITAPIPOCA",
                NomeFantasia = "ITAPIPOCA",
                Descricao = "ITAPIPOCA",
                CnpjBase = "05632288"
            };
            Empresa empresa09 = new Empresa
            {
                RazaoSocial = "MOSSORÓ",
                NomeFantasia = "MOSSORÓ",
                Descricao = "MOSSORÓ",
                CnpjBase = "07003415"
            };
            Empresa empresa10 = new Empresa
            {
                RazaoSocial = "LIMOEIRO",
                NomeFantasia = "LIMOEIRO",
                Descricao = "LIMOEIRO",
                CnpjBase = "07456684"
            };

            _context.AddRange(empresa01, empresa02, empresa03, empresa04, empresa05, empresa06, empresa07, empresa08, empresa09, empresa10);

            _context.SaveChanges();
        }
    }
}