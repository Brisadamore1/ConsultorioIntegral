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

        public int? IdProfesional { get; set; }

        public virtual Profesional? Profesional { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = "El campo Dni es obligatorio.")]
        public string Dni { get; set; } = null!;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El campo Telefono es obligatorio.")]
        public string Telefono { get; set; } = null!;

        [EmailAddress(ErrorMessage = "El campo Email no tiene un formato válido.")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "El campo Direccion es obligatorio.")]
        public string Direccion { get; set; } = null!;

        public bool EsParticular { get; set; }
        
        public string ObraSocial { get; set; }
        public string NumeroAfiliado { get; set; }

    }
}
