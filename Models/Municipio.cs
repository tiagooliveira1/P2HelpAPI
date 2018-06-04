using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace P2HelpAPICore.Models
{
    public class Municipio
    {
        [Key]
        public int IdMunicipio { get; set; }
        public string Nome { get; set; }
        public string Uf { get; set; }

    }
}
