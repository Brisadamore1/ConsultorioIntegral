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

        private string filterProfessionals = string.Empty;
        public string FilterProfessionals
        {
            get => filterProfessionals;
            set{ filterProfessionals = value;
                OnPropertyChanged();
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
            get => profesionales; 
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

            Profesionales = new ObservableCollection<Profesional>(OrderByApellidoNombre(profesionalesFiltrados));
        }

        public async Task ObtenerProfesionales()
        {
            FilterProfessionals = string.Empty;
            IsRefreshing = true;
            profesionalesListToFilter = await profesionalService.GetAllAsync();

            var profesionalesDestacados = (profesionalesListToFilter ?? new List<Profesional>())
                .Where(d => d.Destacado == true)
                .ToList();

            Profesionales = new ObservableCollection<Profesional>(OrderByApellidoNombre(profesionalesDestacados));
            IsRefreshing = false;
        }

        // Ordena por apellido (última palabra en Nombre) y luego por Nombre completo
        private static IEnumerable<Profesional> OrderByApellidoNombre(IEnumerable<Profesional> items)
        {
            return items.OrderBy(p => ExtractApellido(p?.Nombre)).ThenBy(p => p?.Nombre);
        }

        //Este metodo es para extraer el apellido de un nombre completo en caso de que haya mas de un nombre o apellido en 
        private static string ExtractApellido(string? nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre)) return string.Empty;
            var parts = nombre.Trim().Split(' ', System.StringSplitOptions.RemoveEmptyEntries);
            // Detect common format: if names are stored as "Apellido Nombre" take first token as apellido,
            // otherwise fall back to last token. Heuristic: if first token looks like a common surname (capitalized)
            // we assume it's the apellido. Simpler approach: prefer first token.
            return parts.Length > 0 ? parts[0].ToLowerInvariant() : string.Empty;
        }
    }
}
