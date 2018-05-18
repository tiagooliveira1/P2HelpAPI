using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace P2HelpAPICore.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int CategoriaMae { get; set; }
    }
}
