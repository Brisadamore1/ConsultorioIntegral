using Desktop.Interfaces;
using Desktop.Views;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.States.Pacientes
{
    public class AddState : IFormState
    {
        private PacientesView _form;

        public AddState(PacientesView form)
        {
            _form = form ?? throw new ArgumentNullException(nameof(form), "El formulario no puede ser nulo.");

        }
       
        public void OnCancelar()
        {
            //esto es para limpiar los campos del formulario cuando se cancela la operación de agregar un Paciente.
            _form.txtNombre.Clear();
            _form.txtDni.Clear();
            _form.txtEmail.Clear();
            _form.txtTelefono.Clear();
            _form.comboProfesionales.SelectedIndex = -1; // Limpia la selección del combo de profesionales

            _form.SetState(_form.initialDisplayState);
            _form.currentState.UpdateUI();
        }


        public async void OnGuardar()
        {
           
            if (string.IsNullOrEmpty(_form.txtNombre.Text))
            {
                MessageBox.Show("El nombre del paciente es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var paciente = new Paciente
            {
                Nombre = _form.txtNombre.Text,
                Dni = _form.txtDni.Text,
                FechaNacimiento = _form.dateTimeFecha.Value,
                Email = _form.txtEmail.Text,
                Telefono = _form.txtTelefono.Text,
               
                //CondicionIva = _form.txtCondicionIVA.Text
                ProfesionalId = (int)_form.comboProfesionales.SelectedValue,
            };
            await _form.pacienteService.AddAsync(paciente);
            _form.SetState(_form.initialDisplayState);
            await _form.currentState.UpdateUI();

        }

        public Task UpdateUI()
        {
            _form.txtNombre.Clear();
            _form.txtDni.Clear();
            _form.txtEmail.Clear();
            _form.txtTelefono.Clear();
            
            _form.comboProfesionales.SelectedIndex = -1;
            _form.tabControl1.SelectTab(_form.tabPageAgregarEditar);
            return Task.CompletedTask;

        }
        public void OnAgregar()
        {
            UpdateUI();
        }
        public void OnSalir() { }
        public void OnModificar() { }
        public void OnEliminar() { }
        public void OnBuscar() { }
    }
}
