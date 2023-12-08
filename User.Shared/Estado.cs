using System.ComponentModel.DataAnnotations;

namespace User.Shared
{
    public class Estado
    {
        [Key]
        public int IdEstado { get; set; }
        public string Descripcion { get; set; }
    }
}
