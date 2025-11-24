using Desktop.Interfaces;
using Desktop.Views;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.States.ContactosEmergencia
{
    public class AddState : IFormState
    {
        private ContactosEmergenciaView _form;

        public AddState(ContactosEmergenciaView form)
        {
            _form = form ?? throw new ArgumentNullException(nameof(form), "El formulario no puede ser nulo.");

        }
       
        public void OnCancelar()
        {
            //esto es para limpiar los campos del formulario cuando se cancela la operación de agregar un Paciente.
            _form.txtNombre.Clear();
            _form.txtRelacion.Clear();
            _form.txtTelefono.Clear();
            _form.comboPacientes.SelectedIndex = -1; // Limpia la selección del combo de profesionales

            _form.SetState(_form.initialDisplayState);
            _form.currentState.UpdateUI();
        }


        public async void OnGuardar()
        {
           
            if (string.IsNullOrEmpty(_form.txtNombre.Text))
            {
                MessageBox.Show("El nombre del contacto es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var contactoEmergencia = new ContactoEmergencia
            {
                Nombre = _form.txtNombre.Text,
                Relacion = _form.txtRelacion.Text,
                Telefono = _form.txtTelefono.Text,
               
                //CondicionIva = _form.txtCondicionIVA.Text
                PacienteId = (int)_form.comboPacientes.SelectedValue,
            };
            await _form.contactosEmergenciaService.AddAsync(contactoEmergencia);
            _form.SetState(_form.initialDisplayState);
            await _form.currentState.UpdateUI();

        }

        public Task UpdateUI()
        {
            _form.txtNombre.Clear();
            _form.txtRelacion.Clear();
            _form.txtTelefono.Clear();
            
            _form.comboPacientes.SelectedIndex = -1;
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
