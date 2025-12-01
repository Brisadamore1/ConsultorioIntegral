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

        public ProfesionalesViewModel()
        {
            ObtenerProfesionalesCommand = new Command(async () => await ObtenerProfesionales());
            FiltrarProfesionalesCommand = new Command(async () => await FiltrarProfesionales());
            AgregarProfesionalCommand = new Command(async () => await AgregarProfesional());
            EditarProfesionalCommand = new Command(async (obj) => await EditarProfesional(), PermitirEditar);
            EliminarProfesionalCommand = new Command(async (obj) => await EliminarProfesional(), PermitirEditar);
            _ = ObtenerProfesionales();
        }

        private bool PermitirEditar(object arg)
        {
            return SelectedProfessional!=null;
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

            var filtro = filterProfessionals ?? string.Empty;
            IEnumerable<Profesional> profesionalesFiltrados;

            if (string.IsNullOrWhiteSpace(filtro))
            {
                profesionalesFiltrados = profesionalesListToFilter;
            }
            else
            {
                var upper = filtro.ToUpperInvariant();
                profesionalesFiltrados = profesionalesListToFilter.Where(p =>
                    (p?.Nombre ?? string.Empty).ToUpperInvariant().Contains(upper));
            }

            Profesionales = new ObservableCollection<Profesional>(profesionalesFiltrados);
        }

        public async Task ObtenerProfesionales()
        {
            try
            {
                // No disparar filtrado hasta tener datos cargados
                filterProfessionals = string.Empty;
                IsRefreshing = true;
                var result = await profesionalService.GetAllAsync();
                profesionalesListToFilter = result ?? new List<Profesional>();
                Profesionales = new ObservableCollection<Profesional>(profesionalesListToFilter);
                // Aplica filtro inicial (vacío) de forma segura
                await FiltrarProfesionales();
               
            }
            catch (Exception ex)
            {
                profesionalesListToFilter = new List<Profesional>();
                Profesionales = new ObservableCollection<Profesional>();
            }
            finally
            {
                IsRefreshing = false;
            }
        }
    }
}
