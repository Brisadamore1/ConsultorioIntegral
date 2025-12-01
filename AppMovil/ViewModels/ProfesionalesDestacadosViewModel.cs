using AppMovil.Class;
using Microsoft.Maui.Controls;
using Service.Models;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMovil.ViewModels
{
    public class ProfesionalesDestacadosViewModel : ObjectNotification
    {
        private readonly ProfesionalService profesionalService = new ProfesionalService();

        private string filterProfessionals;
        public string FilterProfessionals
        {
            get => filterProfessionals;
            set
            {
                filterProfessionals = value;
                OnPropertyChanged();
                // Evita filtrar si aún no se cargaron los datos
                if (profesionalesListToFilter != null)
                    _ = FiltrarProfesionales();
            }
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

        private ObservableCollection<Profesional> profesionales;
        public ObservableCollection<Profesional> Profesionales
        {
            get{ return profesionales; } 
            set{ profesionales = value;
                OnPropertyChanged();
            }
        }

        //Esta lista es para guardar todos los profesionales y luego filtrar sobre ella
        private List<Profesional>? profesionalesListToFilter;

        public Command ObtenerProfesionalesCommand { get; }
        public Command FiltrarProfesionalesCommand { get; }
       
        public ProfesionalesDestacadosViewModel()
        {
            ObtenerProfesionalesCommand = new Command(async () => await ObtenerProfesionales());
            FiltrarProfesionalesCommand = new Command(async () => await FiltrarProfesionales());
            _ = ObtenerProfesionales();
        }

        private async Task FiltrarProfesionales()
        {
            // Si no hay datos cargados, no hacer nada
            if (profesionalesListToFilter == null)
                return;

            var filtro = FilterProfessionals ?? string.Empty;
            //IEnumerable<Profesional> profesionalesFiltrados;

            var profesionalesFiltrados = profesionalesListToFilter
                    .Where(p => p.Destacado == true &&
                            (p.Nombre ?? string.Empty).Contains(filtro, System.StringComparison.OrdinalIgnoreCase));
           
            Profesionales = new ObservableCollection<Profesional>(profesionalesFiltrados);
        }

        public async Task ObtenerProfesionales()
        {
            try
            {
                // No disparar filtrado hasta tener datos cargados
                FilterProfessionals = string.Empty;
                IsRefreshing = true;
                profesionalesListToFilter = await profesionalService.GetAllAsync();

                var profesionalesDestacados = (profesionalesListToFilter ?? new List<Profesional>())
                    .Where(d => d.Destacado == true)
                    .ToList();

                Profesionales = new ObservableCollection<Profesional>(profesionalesDestacados);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[ProfesionalesDestacados] Error cargando profesionales: {ex}");
                await Application.Current.MainPage.DisplayAlert("Error", "No se pudieron cargar los profesionales.", "OK");
                Profesionales = new ObservableCollection<Profesional>();
            }
            finally
            {
                IsRefreshing = false;
            }
        }
    }
}
