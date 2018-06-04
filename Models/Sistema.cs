using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace P2HelpAPICore.Models
{
    public class Sistema
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Fabricante { get; set; }
    }
}
