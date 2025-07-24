using AppMovil.Class;
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
        private GenericService<Profesional> profesionalService= new GenericService<Profesional>();
		

        private string filterProfessionals;

		public string  FilterProfessionals
		{
			get { return filterProfessionals; }
			set { filterProfessionals = value; 
				OnPropertyChanged();
            }
		}

        //Esto es para poder mostrar un indicador de carga mientras se obtienen los profesionales
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
			get { return profesionales; }
			set { profesionales = value;
				OnPropertyChanged();
			}
		}

        private List<Profesional>? profesionalesListToFilter;

        public Command ObtenerProfesionalesCommand { get; }
		public Command FiltrarProfesionalesCommand { get; }

        public ProfesionalesViewModel()
        {
			ObtenerProfesionalesCommand = new Command(async () => await ObtenerProfesionales());
			FiltrarProfesionalesCommand = new Command(async () => await FiltrarProfesionales());
        }
        private async Task FiltrarProfesionales()
        {
            var profesionalesFiltrados = profesionalesListToFilter.Where(p => p.Nombre.ToUpper().Contains(filterProfessionals.ToUpper()));
            Profesionales = new ObservableCollection<Profesional>(profesionalesFiltrados);
        }
        private async Task ObtenerProfesionales()
        {
			FilterProfessionals = string.Empty;
			profesionalesListToFilter = await profesionalService.GetAllAsync();
            Profesionales = new ObservableCollection<Profesional>(profesionalesListToFilter);
        }

    }
}
