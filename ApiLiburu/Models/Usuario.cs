using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ApiLiburu.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("IdUsuario")]
        public int IdUsuario { get; set; }
        [Column("Nombre")]
        public String Nombre { get; set; }
        [Column("Apellido")]
        public String Apellido { get; set; }
        [Column("Login")]
        public String Login { get; set; }
        [Column("Password")]
        public String Password { get; set; }
        [Column("Email")]
        public String Email { get; set; }
        [Column("Rol")]
        public String Rol { get; set; }
        [Column("Foto")]
        public String Foto { get; set; }
    }
}