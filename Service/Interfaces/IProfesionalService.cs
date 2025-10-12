using Service.DTOs;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IProfesionalService: IGenericService<Profesional> 
    {
        public Task<List<Profesional>?> GetWithFilterAsync(FilterProfesionalDTO filter);
    }
}
