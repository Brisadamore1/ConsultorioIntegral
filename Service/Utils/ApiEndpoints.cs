using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Utils
{
    public static class ApiEndpoints
    {
        public static string ContactoEmergencia { get; set; } = "contactosemergencia";
        public static string Deuda { get; set; } = "deudas";
        public static string Paciente { get; set; } = "pacientes";
        public static string Pago { get; set; } = "pagos";
        public static string Profesional { get; set; } = "profesionales"; 
        public static string Sesion { get; set; } = "sesiones";
        public static string Turno { get; set; } = "turnos";

        public static string Usuario { get; set; } = "usuarios";
        public static string Login { get; set; } = "auth";

        public static string GetEndpoint(string name)
        {
            return name switch
            {
                nameof(ContactoEmergencia) => ContactoEmergencia,
                nameof(Deuda) => Deuda,
                nameof(Paciente) => Paciente,
                nameof(Pago) => Pago,
                nameof(Profesional) => Profesional,
                nameof(Sesion) => Sesion,
                nameof(Turno) => Turno,
                nameof(Usuario) => Usuario,
                nameof(Login) => Login,
                _ => throw new ArgumentException($"Endpoint '{name}' no está definido.")
            };
        }
    }
}
