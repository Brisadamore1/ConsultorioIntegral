using Service.DTOs;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IPacienteService: IGenericService<Paciente> 
    {
        public Task<Paciente?> GetByEmailAsync(string email);
    }
}
