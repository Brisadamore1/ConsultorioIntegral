using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public partial class Deuda
    {
        public int Id { get; set; }
        public int IdPaciente { get; set; } // Almacena el número de paciente (ej: 1)
        public virtual Paciente? Paciente { get; set; } // Permite ver el nombre del paciente
        public int IdProfesional { get; set; } // Almacena el número de profesional (ej: 1)
        public virtual Profesional? Profesional { get; set; } // Permite ver el nombre del profesional

        [Required(ErrorMessage = "El campo Monto es obligatorio.")]
        public decimal Monto { get; set; } // Monto de la deuda

        [Required(ErrorMessage = "El campo Fecha es obligatorio.")]
        public DateTime Fecha { get; set; } // Fecha de la deuda
        public string Descripcion { get; set; } = null!; // Descripción de la deuda

        [Required(ErrorMessage = "El campo Cancelación es obligatorio.")]
        public bool Cancelada { get; set; } // Indica si la deuda ha sido pagada o no
    }
}
