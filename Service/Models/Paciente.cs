using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public partial class Paciente
    {
        public int Id { get; set; }

        public int? ProfesionalId { get; set; }

        public virtual Profesional? Profesional { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo Dni es obligatorio.")]
        public string Dni { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo Fecha de Nacimiento es obligatorio.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El campo Telefono es obligatorio.")]
        public string Telefono { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "El campo Email no tiene un formato válido.")]
        public string? Email { get; set; }
        public string? Direccion { get; set; }

        public bool EsParticular { get; set; }

        public string? ObraSocial { get; set; }
        public string? NumeroAfiliado { get; set; }

        public bool IsDeleted { get; set; } = false;

        public override string ToString()
        {
            return Nombre;
        }
    }
}
