﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite("Data Source=P2Help_db.db");
            //optionsBuilder.UseSqlServer("DefaultConnection");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>().ToTable("Categoria");
            
        }
    }
}