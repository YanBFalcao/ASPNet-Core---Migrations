using EFCore.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.WebAPI.Data
{
    public class HeroiContext : DbContext
    {
        public DbSet<Heroi> Herois { get; set; }
        public DbSet<Arma> Armas { get; set; }
        public DbSet<Batalha> Batalhas { get; set; }

        public HeroiContext(DbContextOptions<HeroiContext> options)
            : base(options)
        {            
        }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // String de Conexão
        {
            optionsBuilder.UseSqlServer("Password=paranoia13;Persist Security Info=True;User ID=sa;Initial Catalog=HeroApp;Data Source=DESKTOP-T9A7732");
        }
    }
}