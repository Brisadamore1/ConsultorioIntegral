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
    public class ProfesionalesViewModel : ObjectNotification
    {
        private GenericService<Profesional> profesionalService = new GenericService<Profesional>();

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

        private Profesional? selectedProfessional;
        public Profesional? SelectedProfessional
        {
            get{ return selectedProfessional; } 
            set{ selectedProfessional = value;
                OnPropertyChanged();
                EditarProfesionalCommand.ChangeCanExecute();
                EliminarProfesionalCommand.ChangeCanExecute();
            }
        }

        public Command ObtenerProfesionalesCommand { get; }
        public Command FiltrarProfesionalesCommand { get; }
        public Command AgregarProfesionalCommand { get; }
        public Command EditarProfesionalCommand { get; }
        public Command EliminarProfesionalCommand { get; }
        public Command<SelectionChangedEventArgs> SelectionChangedCommand { get; }
        public Command<Profesional> ItemTappedCommand { get; }

        public ProfesionalesViewModel()
        {
            ObtenerProfesionalesCommand = new Command(async () => await ObtenerProfesionales());
            FiltrarProfesionalesCommand = new Command(async () => await FiltrarProfesionales());
            AgregarProfesionalCommand = new Command(async () => await AgregarProfesional());
            EditarProfesionalCommand = new Command(async (obj) => await EditarProfesional(), PermitirEditar);
            EliminarProfesionalCommand = new Command(async (obj) => await EliminarProfesional(), PermitirEditar);
            SelectionChangedCommand = new Command<SelectionChangedEventArgs>(OnSelectionChanged);
            ItemTappedCommand = new Command<Profesional>(OnItemTapped);
            _ = ObtenerProfesionales();
        }

        private bool PermitirEditar(object arg)
        {
            return SelectedProfessional!=null;
        }

        private void OnSelectionChanged(SelectionChangedEventArgs args)
        {
            var item = args?.CurrentSelection?.FirstOrDefault() as Profesional;
            // Asignar directamente para asegurar respuesta inmediata al tocar
            SelectedProfessional = item;
        }

        private void OnItemTapped(Profesional profesional)
        {
            if (profesional == null) return;
            SelectedProfessional = profesional;
        }

        private async Task EditarProfesional()
        {
            var navigationParameter = new ShellNavigationQueryParameters
            {
                { "ProfessionalToEdit", SelectedProfessional }
            };
            await Shell.Current.GoToAsync("//AgregarEditarProfesional", navigationParameter);
        }

        private async Task AgregarProfesional()
        {
            var navigationParameter = new ShellNavigationQueryParameters
            {
                { "ProfessionalToEdit", null }
            };
            await Shell.Current.GoToAsync("//AgregarEditarProfesional", navigationParameter);
        }

        private async Task EliminarProfesional()
        {
            if (SelectedProfessional == null) return;
            try
            {
                // Confirmación
                bool confirmar = await Application.Current.MainPage.DisplayAlert(
                    "Eliminar profesional",
                    $"¿Está seguro que desea eliminar a {SelectedProfessional.Nombre}?",
                    "Sí", "No");
                if (!confirmar) return;

                await profesionalService.DeleteAsync(SelectedProfessional.Id);

                // Recargar lista desde servicio para mantener coherencia
                await ObtenerProfesionales();
                SelectedProfessional = null; // Limpia selección para desactivar comandos
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
            }
        }

        public async Task FiltrarProfesionales()
        {
            // Si no hay datos cargados, no hacer nada
            if (profesionalesListToFilter == null)
                return;

            var filtro = FilterProfessionals ?? string.Empty;

            if (string.IsNullOrWhiteSpace(filtro))
            {
                Profesionales = new ObservableCollection<Profesional>(OrderByApellidoNombre(profesionalesListToFilter));
                return;
            }
           
            var filtrados = profesionalesListToFilter
                .Where(p =>(p.Nombre ?? string.Empty)
                .Contains(filtro, System.StringComparison.OrdinalIgnoreCase));
            
            Profesionales = new ObservableCollection<Profesional>(OrderByApellidoNombre(filtrados));
        }

        public async Task ObtenerProfesionales()
        {
            // No disparar filtrado hasta tener datos cargados
            FilterProfessionals = string.Empty;
            IsRefreshing = true;
            profesionalesListToFilter = await profesionalService.GetAllAsync();
            Profesionales = new ObservableCollection<Profesional>(OrderByApellidoNombre(profesionalesListToFilter ?? new List<Profesional>()));
            IsRefreshing = false;
        }

        // Ordena por apellido (última palabra en Nombre) y luego por Nombre completo
        private static IEnumerable<Profesional> OrderByApellidoNombre(IEnumerable<Profesional> items)
        {
            return items.OrderBy(p => ExtractApellido(p?.Nombre)).ThenBy(p => p?.Nombre);
        }

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
