using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Class
{
    public partial class ContactoEmergencia
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = "El campo Relacion es obligatorio.")]
        public string Relacion { get; set; } = null!;

        [Required(ErrorMessage = "El campo Telefono es obligatorio.")]
        public string Telefono { get; set; } = null!;


    }
}
