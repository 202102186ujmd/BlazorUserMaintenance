using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Shared
{
    public class Login
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Nombre de usuario Es obligatorio")]
        [StringLength(20)]
        public string? UserLogin { get; set; }
        [Required(ErrorMessage = "Contraseña Es obligatorio")]
        [StringLength(70)]
        public string? Password { get; set; }

    }
}
