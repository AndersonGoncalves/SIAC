using Microsoft.EntityFrameworkCore;

namespace SiacWeb.Models
{
    public class SiacWebContext : DbContext
    {
        public SiacWebContext (DbContextOptions<SiacWebContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<CentroDeCusto> CentroDeCusto { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Fornecedor> Fornecedor { get; set; }
        public DbSet<Transportadora> Transportadora { get; set; }
        public DbSet<Autonomo> Autonomo { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Auditoria> Auditoria { get; set; }
        public DbSet<GrupoDeProduto> GrupoDeProduto { get; set; }
    }
}