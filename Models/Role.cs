using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace P2HelpAPICore.Models
{
    public class Role
    {
        // para criar relação de muitos para muitos 
        /*public Role()
        {
            this.Usuarios = new HashSet<Usuario>();
        }*/

        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Permissao> Permissoes { get; set; }
    }
}
