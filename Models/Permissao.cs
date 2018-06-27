using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace P2HelpAPICore.Models
{
    public class Permissao
    {
        /* Por ser chave composta, precisei definir a chave primaria no P2HelpContext */
        [Key]
        public int IdPermissao { get; set; }
        public int IdUsuario { get; set; }

        [ForeignKey("IdUsuario")]
        public virtual Usuario UsuarioRole { get; set; }
        [ForeignKey("IdRole")]
        public int IdRole { get; set; }
        public virtual Role RoleUsuario { get; set; }
    }
}
