using P2HelpAPICore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2HelpAPICore.Data
{
    public class DBInitializer
    {
        public static void Initialize(P2HelpContext context)
        {
            context.Database.EnsureCreated();
            if (context.Categoria.Any())
            {
                return;   // DB has been seeded
            }
            var categorias = new Categoria[]
            {
                new Categoria{ Descricao="Curso"},
                new Categoria{ Descricao="Consultoria"},
                new Categoria{ Descricao="Mentoria"},
                new Categoria{ Descricao="Ajuda"}
            };

            foreach (Categoria c in categorias)
            {
                context.Categoria.Add(c);
            }

            context.SaveChanges();

        }
    }
}
