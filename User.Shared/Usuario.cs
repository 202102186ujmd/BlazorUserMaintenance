using System.ComponentModel.DataAnnotations;

namespace User.Shared
{
    public class Usuario
    {
        [Key]
        [Required(ErrorMessage = "Nombre de usuario Es obligatorio")]
        [EmailAddress(ErrorMessage = "El email no es valido")]
        public string Email { get; set; }
        //agregamos la contraseña con tipo de datos varbinary
        [Required(ErrorMessage = "Contraseña Es obligatorio")]
        [MinLength(8)] //minimo 8 caracteres
        public byte[] Contrasena { get; set; }
        [Required]
        //agregamos la restricion de tipo de usuario 1: administrador, 2: Becario
        [StringLength(1)]
        public int TipodeUsuario { get; set; }
    }
}
