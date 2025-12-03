using AppMovil.Class;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Maui.ApplicationModel.Communication;
using Microsoft.Maui.Controls;
using Service.Models;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMovil.ViewModels
{
    public class AddEditProfesionalViewModel : ObjectNotification
    {
		ProfesionalService profesionalService = new ProfesionalService();

        private Profesional? editProfessional;
		public Profesional? EditProfessional
        {
			get => editProfessional;
			set{
				editProfessional = value;
				OnPropertyChanged();
				SettingData();
			}
		}

		private void SettingData()
        {
            if (editProfessional == null)
            {
                Nombre = string.Empty;
                Profesion = string.Empty;
                Matricula = string.Empty;
                Especialidad = string.Empty;
                Mail = string.Empty;
                Telefono = string.Empty;
                Destacado = false;
            }
            else
            {
                Nombre = editProfessional.Nombre;
                Profesion = editProfessional.Profesion;
                Matricula = editProfessional.Matricula;
                Especialidad = editProfessional.Especialidad;
                Mail = editProfessional.Email;
                Telefono = editProfessional.Telefono;
                Destacado = editProfessional.Destacado ?? false;
            }
           
        }

        private string nombre;
		public string Nombre
		{
			get { return nombre; }
			set { nombre = value; 
			OnPropertyChanged();
            }
        }

        private string profesion;
        public string Profesion
        {
            get { return profesion; }
            set
            {
                profesion = value;
                OnPropertyChanged();
            }
        }

        private string matricula;
		public string Matricula
        {
            get { return matricula; }
            set { matricula = value; 
            OnPropertyChanged();
            }
        }

        private string especialidad;
        public string Especialidad
		{
			get { return especialidad; }
			set { especialidad = value;
                OnPropertyChanged();
            }
        }

		private string mail;
        public string Mail
        {
            get{ return mail; }
            set{ mail = value;
                OnPropertyChanged();
            }
        }
        private string telefono;
        public string Telefono
        {
            get { return telefono; }
            set { telefono = value;
                OnPropertyChanged();
            }
        }

        private bool destacado;
        public bool Destacado
        {
            get => destacado;
            set { destacado = value; OnPropertyChanged(); }
        }

		public Command SaveProfessionalCommand { get; }
		public Command CancelProfessionalCommand { get; }

		public AddEditProfesionalViewModel()
        {
			SaveProfessionalCommand = new Command(async () => await SaveProfessional());
			CancelProfessionalCommand = new Command(async () => await CancelProfessional());
        }

		private async Task SaveProfessional()
        {
            if (EditProfessional != null)
            {
                editProfessional.Nombre = Nombre;
                editProfessional.Profesion = Profesion;
                editProfessional.Matricula = Matricula;
                editProfessional.Especialidad = Especialidad;
                editProfessional.Email = Mail;
                editProfessional.Telefono = Telefono;
                editProfessional.Destacado = Destacado;
                await profesionalService.UpdateAsync(editProfessional);
            }else
            {
                var profesional = new Profesional()
                {
                    Nombre = Nombre,
                    Profesion = Profesion,
                    Matricula = Matricula,
                    Especialidad = Especialidad,
                    Email = Mail,
                    Telefono = Telefono,
                    Destacado = Destacado
                };
                await profesionalService.AddAsync(profesional);
				// Actualiza estado edición
				EditProfessional = profesional;
            }
            await Shell.Current.GoToAsync("//ListaProfesionales");

        }

		private async Task CancelProfessional()
		{
			// Simplemente navega de regreso a la lista sin guardar cambios
			await Shell.Current.GoToAsync("//ListaProfesionales");
		}
    }
}


