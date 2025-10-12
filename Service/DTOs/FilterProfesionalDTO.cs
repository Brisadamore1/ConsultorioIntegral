using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs
{
    public class FilterProfesionalDTO
    {
        //SearchText es el texto que se va a buscar por nombre o especialidad. ForNombre y ForEspecialidad son booleanos que indican si se debe buscar por nombre o por especialidad.
        public string SearchText { get; set; } = "";
        public bool ForNombre { get; set; } = false;
        public bool ForEspecialidad { get; set; } = false;
    }
}
