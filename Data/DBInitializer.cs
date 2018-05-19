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

            if (context.Usuario.Any())
            {
                return;   // DB has been seeded
            }
            var usuarios = new Usuario[]
            {
                new Usuario{ Nome="Tiago", Login="1", Pass="1", HashAuth = Guid.NewGuid().ToString()},
                new Usuario{ Nome="Henrique", Login="2", Pass="2", HashAuth = Guid.NewGuid().ToString()},
                new Usuario{ Nome="Jose", Login="3", Pass="3", HashAuth = Guid.NewGuid().ToString()},

            };

            foreach (Usuario u in usuarios)
            {
                context.Usuario.Add(u);
            }

            context.SaveChanges();

        }
    }
}
