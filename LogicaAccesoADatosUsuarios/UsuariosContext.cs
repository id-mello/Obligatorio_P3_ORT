using LogicaDeNegocioUsuarios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAccesoADatosUsuarios.BDD
{
    public class UsuariosContext : DbContext
    {
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Roles> Roles { get; set; }
        


        public UsuariosContext(DbContextOptions<UsuariosContext> opciones) : base(opciones)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<Pais>().HasAlternateKey(p => p.IdRegion);
            //modelBuilder.Entity<Seleccion>().HasAlternateKey(s => s.IdPais);
            modelBuilder.Entity<Usuarios>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<Roles>().HasIndex(r => r.Nombre).IsUnique();



            base.OnModelCreating(modelBuilder);
        }
    }
}
