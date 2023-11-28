using System.ComponentModel.DataAnnotations;

namespace User.Shared
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Nombre de usuario Es obligatorio")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Direccion Es obligatorio")]
        public string? Address { get; set; }
        public string? CellNumber { get; set; }

        [EmailAddress(ErrorMessage = "Correo electronico no valido")]
        public string? EmailId { get; set; }

    }
}
