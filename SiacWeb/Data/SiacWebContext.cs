using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SiacWeb.Models;

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
