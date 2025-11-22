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
            set
            {
                profesionales = value;
                OnPropertyChanged();
            }
        }

        private List<Profesional>? profesionalesListToFilter;
        private Profesional? selectedProfessional;
        public Profesional? SelectedProfessional
        {
            get => selectedProfessional;
            set
            {
                selectedProfessional = value;
                OnPropertyChanged();
                EditarProfesionalCommand.ChangeCanExecute();
            }
        }

        public Command ObtenerProfesionalesCommand { get; }
        public Command FiltrarProfesionalesCommand { get; }
        public Command AgregarProfesionalCommand { get; }
        public Command EditarProfesionalCommand { get; }

        public ProfesionalesViewModel()
        {
            ObtenerProfesionalesCommand = new Command(async () => await ObtenerProfesionales());
            FiltrarProfesionalesCommand = new Command(async () => await FiltrarProfesionales());
            AgregarProfesionalCommand = new Command(async () => await AgregarProfesional());
            EditarProfesionalCommand = new Command(async () => await EditarProfesional(), () => SelectedProfessional != null);
            _ = ObtenerProfesionales();
        }

        private async Task EditarProfesional()
        {
            if (SelectedProfessional == null) return;
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

        public async Task FiltrarProfesionales()
        {
            if (string.IsNullOrWhiteSpace(filterProfessionals))
            {
                Profesionales = new ObservableCollection<Profesional>(profesionalesListToFilter ?? new List<Profesional>());
            }
            else
            {
                var profesionalesFiltrados = profesionalesListToFilter?
                    .Where(p => p.Nombre != null && p.Nombre.ToUpper().Contains(filterProfessionals.ToUpper()))
                    .ToList() ?? new List<Profesional>();
                Profesionales = new ObservableCollection<Profesional>(profesionalesFiltrados);
            }
        }

        public async Task ObtenerProfesionales()
        {
            FilterProfessionals = string.Empty;
            IsRefreshing = true;
            profesionalesListToFilter = await profesionalService.GetAllAsync();
            Profesionales = new ObservableCollection<Profesional>(profesionalesListToFilter);
            IsRefreshing = false;
        }
    }
}
