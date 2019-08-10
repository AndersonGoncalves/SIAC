using Microsoft.EntityFrameworkCore;

namespace SiacWeb.Models
{
    public class SiacWebContext : DbContext
    {
        public SiacWebContext (DbContextOptions<SiacWebContext> options)
            : base(options)
        {
        }

        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<CentroDeCusto> CentroDeCusto { get; set; }
    }
}
