using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public partial class ContactoEmergencia
    {
        public int Id { get; set; }

        public int? PacienteId { get; set; } // Almacena el número de paciente
        public virtual Paciente? Paciente { get; set; } // Permite ver el nombre del paciente

        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = "El campo Relacion es obligatorio.")]
        public string Relacion { get; set; } = null!;

        [Required(ErrorMessage = "El campo Telefono es obligatorio.")]
        public string Telefono { get; set; } = null!;

        //Esto permite que en la base de datos se visualice el nombre del contacto de emergencia
        public override string ToString()
        {
            return Nombre;
        }
    }
}
