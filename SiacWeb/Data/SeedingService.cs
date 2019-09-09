using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using SiacWeb.Comum;
using SiacWeb.Models;

namespace SiacWeb.Data
{
    public class SeedingService
    {
        private SiacWebContext _context;
        private SiacWebIdentityContext _contextIdentity;
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<IdentityUser> _userManager;

        public SeedingService(SiacWebContext context, SiacWebIdentityContext contextIdentity, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _contextIdentity = contextIdentity;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void Seed()
        {
            //Roles
            if (!_contextIdentity.Roles.Any())
            {
                string[] rolesNames = { Perfil.Admin,
                            Perfil.Diretor,
                            Perfil.Gerente,
                            Perfil.Vendedor,
                            Perfil.Comprador,
                            Perfil.Cobrador,
                            Perfil.Caixa,
                            Perfil.Financeiro,
                            Perfil.Estoquista,
                            Perfil.Supervisor};
                foreach (var item in rolesNames)
                {
                    IdentityRole role = new IdentityRole
                    {
                        Name = item,
                        NormalizedName = item.ToUpper()
                    };
                    _contextIdentity.AddRange(role);
                }
                _contextIdentity.SaveChanges();
            }

            //UserAdmin
            if (!_contextIdentity.Usuario.Any())
            {
                Usuario userAdmin = new Usuario
                {
                    UserName = "anndersonn.gonncalves@gmail.com",
                    NormalizedUserName = "ANNDERSONN.GONNCALVES@GMAIL.COM",
                    Email = "anndersonn.gonncalves@gmail.com",
                    NormalizedEmail = "ANNDERSONN.GONNCALVES@GMAIL.COM",
                    EmailConfirmed = false,
                    PasswordHash = "AQAAAAEAACcQAAAAEDBI0Wrtw0FBdbJ1cc3KMz4hVTHOV3PC0C5YXLbx5Izg8kwbW2frQFjfn2JD9Uuksg==",
                    SecurityStamp = "7RIZCETVFBVWBOYXHFSZKSRTQFLHYXWV",
                    ConcurrencyStamp = "7e2b48c6-2d6b-4070-9c99-994cf755650d",
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0,
                    Ativo = Enums.SimOuNao.Sim,
                    DataCadastro = DateTime.Now,
                    Nome = "Admin"
                };
                _contextIdentity.AddRange(userAdmin);
                _contextIdentity.SaveChanges();


                //UserAdminRoles
                var applicationRole = _roleManager.FindByNameAsync(Perfil.Admin);
                if (applicationRole != null)
                {
                    _userManager.AddToRoleAsync(userAdmin, Perfil.Admin);
                }
            }

            //Empresa e CentroDeCusto
            if (!_context.Empresa.Any() && (!_context.CentroDeCusto.Any()))
            {
                //Empresa
                Empresa empresaTeste = new Empresa
                {
                    RazaoSocial = "Teste Ltda",
                    NomeFantasia = "Teste",
                    Descricao = "Empresa para testes",
                    CnpjBase = "00000000"
                };
                _context.AddRange(empresaTeste);

                //Centro de custo
                CentroDeCusto centroDeCustoTeste = new CentroDeCusto
                {
                    RazaoSocial = "CNC Teste Ltda",
                    NomeFantasia = "CNC Teste",
                    CNPJ = "00000000000101",
                    Empresa = empresaTeste
                };
                _context.AddRange(centroDeCustoTeste);

                _context.SaveChanges();
            }

            #region Empresas da luciano ótica
            /*
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
            */
            #endregion
        }
    }
}