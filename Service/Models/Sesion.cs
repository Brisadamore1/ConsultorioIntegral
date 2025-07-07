﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public partial class Sesion
    {
        public int Id { get; set; } // Ej: 1
        public int? TurnoId { get; set; } // Referencia al turno asociado a la sesión.
        public virtual Turno? Turno { get; set; }  // Navegación al turno asociado.
        public string Notas { get; set; } = null!; // Notas de la sesión.

        [Required(ErrorMessage = "El campo Honorarios es obligatorio.")]
        public decimal Honorarios { get; set; } // Honorarios cobrados por la sesión.

        [Required(ErrorMessage = "El campo Pagado es obligatorio.")]
        public bool Pagado { get; set; } // Indica si la sesión ha sido pagada o no.

        public bool Eliminado { get; set; } = false;
    }
}
