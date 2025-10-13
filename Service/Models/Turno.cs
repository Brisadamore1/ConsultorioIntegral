using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public partial class Turno
    {
        public int Id { get; set; }

        public int? PacienteId { get; set; } // Almacena el número de paciente (ej: 1)
        public virtual Paciente? Paciente { get; set; } // Permite ver el nombre del paciente (ej: "Juan Pérez")
        public int? ProfesionalId { get; set; } 

        public virtual Profesional? Profesional { get; set; } // Relación con Profesional

        [Required(ErrorMessage = "El campo FechaHora es obligatorio.")]
        public DateTime FechaHora { get; set; }

        [Required(ErrorMessage = "El campo DuracionMinutos es obligatorio.")]
        public int DuracionMinutos { get; set; }

        [Required(ErrorMessage = "El campo Estado es obligatorio.")]
        public int EstadoTurnoId { get; set; } // almacena el número (ej: 2)
        public virtual EstadoTurno? EstadoTurno { get; set; }  // permite ver el nombre ("Confirmado")

        public bool CanceladoPorProfesional { get; set; }

        public string? MotivoCancelacion { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
