using AppMovil.Class;
using Service.Models;
using Service.Services;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AppMovil.ViewModels
{
    public class PerfilViewModel : ObjectNotification
    {
        private GenericService<Paciente> pacienteService = new GenericService<Paciente>();
        public PerfilViewModel()
        {
            ObtenerPacienteCommand = new Command(async () => await ObtenerPaciente());
        }

        private bool _isRefreshing;
        public bool IsRefreshing
        {
            get => _isRefreshing;
            set
            {
                _isRefreshing = value;
                OnPropertyChanged();
            }
        }

        // Propiedad para almacenar un único paciente
        private Paciente _paciente = new Paciente();
        public Paciente Paciente
        {
            get => _paciente;
            set
            {
                _paciente = value;
                OnPropertyChanged();
            }
        }

        //El ICommand es para enlazar con el boton de refrescar
        public ICommand ObtenerPacienteCommand { get; }
        public int PacienteId { get; set; }

        public async Task CargarPacienteAsync(int id)
        {
            PacienteId = id;
            await ObtenerPaciente();
        }

        private async Task ObtenerPaciente()
        {
            IsRefreshing = true;
            var paciente = await pacienteService.GetByIdAsync(PacienteId);
            Console.WriteLine($"Paciente cargado: {paciente?.Nombre ?? "NULO"}");
            Paciente = paciente;
            IsRefreshing = false;
        }
    }
}
