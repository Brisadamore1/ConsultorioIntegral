﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Service.Models
{
    public partial class ModalidadPago
    {
        public int Id { get; set; }        

        [Required(ErrorMessage = "El campo Modalidad es obligatorio.")]
        public string? Modalidad { get; set; }

        public bool Eliminado { get; set; } = false;
        public override string? ToString()
        {
            return Modalidad;
        }
    }
}
