using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EquiposDeFutbol.Models;

namespace MvcEquiposDeFutbol.Data
{
    public class MvcEquiposDeFutbolContext : DbContext
    {
        public MvcEquiposDeFutbolContext (DbContextOptions<MvcEquiposDeFutbolContext> options)
            : base(options)
        {
        }

        public DbSet<EquiposDeFutbol.Models.Equipo> Equipo { get; set; } = default!;

        public DbSet<EquiposDeFutbol.Models.Liga> Liga { get; set; } = default!;

           protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             modelBuilder.Entity<Equipo>()
            .HasOne<Liga>(e => e.Liga)
            .WithMany(l => l.Equipos)
            .HasForeignKey(e => e.LigaId)
            .OnDelete(DeleteBehavior.Cascade);

        base.OnModelCreating(modelBuilder);
        }
    }
}
