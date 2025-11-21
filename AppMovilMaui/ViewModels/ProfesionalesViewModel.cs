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
        //Servicio necesario para obtener los profesionales desde el backend
        private GenericService<Profesional> profesionalService= new GenericService<Profesional>();

        //Campo para filtrar los profesionales por nombre. Almacena la lista de profesionales filtrados por nombre
        private string filterProfessionals;

        // Propiedad que se usa para filtrar los profesionales por nombre
        public string  FilterProfessionals
		{
			get { return filterProfessionals; }
			set { filterProfessionals = value; 
				OnPropertyChanged();
                _ = FiltrarProfesionales(); // Llamamos al método FiltrarProfesionales cuando se cambia el filtro. Como es asincronico aparece con el guion bajo al principio para indicar que no esperamos su resultado.
            }
		}

        //Esto es para poder mostrar un indicador de carga mientras se obtienen los profesionales. Indicador de actividad. 
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

        //Lista de profesionales que se va a mostrar en la vista
        private ObservableCollection<Profesional> profesionales;

        //Propiedad que se usa para mostrar los profesionales en la vista
        public ObservableCollection<Profesional> Profesionales
		{
			get { return profesionales; }
			set { profesionales = value;
				OnPropertyChanged();
			}
		}

        //Normalmente los ObservableCollection son inmutables, no le podemos hacer cambios. Por eso se creó esta lista que es un objeto mutable.
        //Lista de profesionales que se va a filtrar
        private List<Profesional>? profesionalesListToFilter;

        //Comandos para obtener y filtrar los profesionales
        public Command ObtenerProfesionalesCommand { get; }
		public Command FiltrarProfesionalesCommand { get; }

        public ProfesionalesViewModel()
        {
           
            ObtenerProfesionalesCommand = new Command(async () => await ObtenerProfesionales());
			FiltrarProfesionalesCommand = new Command(async () => await FiltrarProfesionales());
        }

        //Estamos haciendo por caché. Es decir, la lista de profesionales llega completa y se almacena en la memoria del telefono. Luego con lo escrito vamos a filtrar sobre la lista que llegó y asignarlo visualmente a la propiedad Profesionales.
        //profesionalesListToFilter siempre queda llena, y Profesionales es la que se va a mostrar en la vista y va cambiando.
        private async Task FiltrarProfesionales()
        {
            var profesionalesFiltrados = profesionalesListToFilter.Where(p => p.Nombre.ToUpper().Contains(filterProfessionals.ToUpper()));
            Profesionales = new ObservableCollection<Profesional>(profesionalesFiltrados);
        }
        //Método para obtener los profesionales desde el backend
        private async Task ObtenerProfesionales()
        {
            
			FilterProfessionals = string.Empty;
            IsRefreshing = true; // Asegúrate de que IsRefreshing se establezca en true al inicio
            profesionalesListToFilter = await profesionalService.GetAllAsync();
            Profesionales = new ObservableCollection<Profesional>(profesionalesListToFilter);
            IsRefreshing = false; // Establece IsRefreshing en false al final
            
        }

    }
}
