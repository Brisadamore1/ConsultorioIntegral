﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Service.Models
{
    public partial class EstadoTurno
    {
        public int Id { get; set; }         // Ej: 1

        [Required(ErrorMessage = "El campo Estado es obligatorio.")]
        public string? Estado { get; set; }  // Ej: "Reservado"

        public virtual ICollection<Turno> Turnos { get; set; } = new List<Turno>();

        //La navegacion inversa permite acceder a los turnos que tienen este estado.
        //Por ejemplo, si tenemos un estado "Confirmado" con Id = 2, podemos acceder a todos los turnos que tienen ese estado.Mostrar estadísticas por estado(cuántos "cancelados", etc.)

        //Ejemplo de uso:
        //var turnosConfirmados = db.Turnos
        //  .Where(t => t.EstadoTurnoId == 2)
        //  .ToList();

        public bool Eliminado { get; set; } = false;

        public override string? ToString()
        {
            return Estado;
        }
    }
}
