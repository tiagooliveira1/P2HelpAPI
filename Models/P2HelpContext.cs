using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using P2HelpAPICore.Models;

namespace P2HelpAPICore.Models
{
    public class P2HelpContext: DbContext
    {
        public P2HelpContext()
        {

        }

        public P2HelpContext(DbContextOptions<P2HelpContext> options)
            : base(options)
        {

        }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Municipio> Municipio { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Sistema> Sistema { get; set; }
        public DbSet<Permissao> Permissao { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite("Data Source=P2Help_db.db");
            //optionsBuilder.UseSqlServer("DefaultConnection");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>().ToTable("Categoria");
            modelBuilder.Entity<Usuario>()
                .ToTable("Usuario")
                .HasMany(c => c.Permissoes)
                .WithOne(p => p.UsuarioRole);

            modelBuilder.Entity<Municipio>().ToTable("Municipio");
            modelBuilder.Entity<Role>().ToTable("Role");
            modelBuilder.Entity<Sistema>().ToTable("Sistema");
            modelBuilder.Entity<Permissao>()
                .ToTable("Permissao")
                .HasOne(c => c.UsuarioRole)
                .WithMany(u => u.Permissoes);
            /*.HasKey(c => new { c.IdRole, c.UsuarioRole } );*/



            /*modelBuilder.Entity<Usuario>()primary key, use fluent API.
                .HasMany(u => u.Roles)
                .WithMany(u => u.Usuarios)
                .Map(); */

        }


    }
}
