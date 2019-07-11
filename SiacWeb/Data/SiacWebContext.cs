using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SiacWeb.Models
{
    public class SiacWebContext : DbContext
    {
        public SiacWebContext (DbContextOptions<SiacWebContext> options)
            : base(options)
        {
        }

        public DbSet<SiacWeb.Models.Perfil> Perfil { get; set; }
    }
}
