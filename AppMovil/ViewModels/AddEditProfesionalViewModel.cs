using AppMovil.Class;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Maui.ApplicationModel.Communication;
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
		private Profesional editProfessional;

		public Profesional EditProfessional
        {
			get { return editProfessional; }
			set { editProfessional = value;
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
            }
            else
            {
                Nombre = editProfessional.Nombre;
                Profesion = editProfessional.Profesion;
                Matricula = editProfessional.Matricula;
                Especialidad = editProfessional.Especialidad;
                Mail = editProfessional.Email;
                Telefono = editProfessional.Telefono;
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

        public Command SaveProfessionalCommand { get; }

        public AddEditProfesionalViewModel()
        {
            SaveProfessionalCommand = new Command(async () => await SaveProfessional());
        }

        private async Task SaveProfessional()
        {
            if (EditProfessional != null)
            {
                editProfessional.Nombre = this.Nombre;
                editProfessional.Profesion = this.Profesion;
                editProfessional.Matricula = this.Matricula;
                editProfessional.Especialidad = this.Especialidad;
                editProfessional.Email = this.Mail;
                editProfessional.Telefono = this.Telefono;
                await profesionalService.UpdateAsync(editProfessional);
            }else
            {
                var profesional = new Profesional()
                {
                    Nombre = this.Nombre,
                    Profesion = this.Profesion,
                    Matricula = this.Matricula,
                    Especialidad = this.Especialidad,
                    Email = this.Mail,
                    Telefono = this.Telefono
                };
                await profesionalService.AddAsync(profesional);
            }
            await Shell.Current.GoToAsync("//ListaProfesionales");

        }
    }
}


