using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public partial class Pago
    {
        public int Id { get; set; }

        public int? SesionId { get; set; }

        public virtual Sesion? Sesion { get; set; }

        public int? ModalidadPagoId { get; set; }

        public virtual ModalidadPago? ModalidadPago { get; set; }

        [Required(ErrorMessage = "El campo Monto es obligatorio.")]
        public decimal Monto { get; set; } 

        [Required(ErrorMessage = "El campo Fecha es obligatorio.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }

        public bool IsDeleted { get; set; } = false;

    }
}
