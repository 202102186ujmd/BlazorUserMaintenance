using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Shared
{
    public class Solicitud
    {
        [Key]
        public int IdSolicitud { get; set; }
        [Required]
        public int IdSolicitante { get; set; }
        [FechaFuturaValida(ErrorMessage = "La fecha no puede estar en el futuro.")]
        public DateTime FechadeCreacion { get; set; }
        public int IdEstado { get; set; } = 1;

        public Solicitud()
        {
            // Establecer la fecha de creación al momento de la instancia
            FechadeCreacion = DateTime.Now;
        }
    }
}
