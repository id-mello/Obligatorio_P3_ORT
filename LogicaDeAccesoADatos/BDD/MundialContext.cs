using LogicaDeNegocio.EntidadesNegocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaDeAccesoADatos.BDD
{
    public class MundialContext: DbContext
    {
        public DbSet<Region>Regiones { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Seleccion> Selecciones { get; set; }
        public DbSet<Partido> Partidos { get; set; }
        public DbSet<PartidoDeGrupo> Grupos { get; set; }
  


        public MundialContext(DbContextOptions<MundialContext> opciones) :base(opciones)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<Pais>().HasAlternateKey(p => p.IdRegion);
            modelBuilder.Entity<Seleccion>().HasAlternateKey(s => s.IdPais);
            modelBuilder.Entity<Pais>().HasIndex(p => p.IsoAlfa3).IsUnique();
            //modelBuilder.Entity<Partido>().HasMany<PartidoSeleccion>(p => p.partidosSeleccion).WithOne(s => s.partido);
            //modelBuilder.Entity<Seleccion>().HasMany<PartidoSeleccion>(s => s.partidosSeleccion).WithOne(p => p.seleccion);
            //modelBuilder.Entity<PartidoSeleccion>().HasKey(p => new { p.idPartido, p.idSeleccion });
            base.OnModelCreating(modelBuilder);
        }
    }
}
