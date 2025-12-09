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

            // Asegurar que el control muestre fecha y hora actuales al entrar en el estado de agregar
            try
            {
                // Mostrar solo la fecha (sin hora) y usar la fecha actual
                _form.dateTimeFecha.Format = DateTimePickerFormat.Custom;
                _form.dateTimeFecha.CustomFormat = "dd/MM/yyyy";
                _form.dateTimeFecha.Value = DateTime.Today;
            }
            catch
            {
                // Si por alguna razón el control no está inicializado aún, evitamos lanzar excepción aquí.
            }
        }
       
        public void OnCancelar()
        {
            //esto es para limpiar los campos del formulario cuando se cancela la operación de agregar un Paciente.
            _form.txtNombre.Clear();
            _form.txtDni.Clear();
            _form.txtEmail.Clear();
            _form.txtTelefono.Clear();
            _form.comboProfesionales.SelectedIndex = -1; // Limpia la selección del combo de profesionales

            // Restablecer fecha/hora actual al cancelar
            try
            {
                // Restablecer solo la fecha actual
                _form.dateTimeFecha.Format = DateTimePickerFormat.Custom;
                _form.dateTimeFecha.CustomFormat = "dd/MM/yyyy";
                _form.dateTimeFecha.Value = DateTime.Today;
            }
            catch { }

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
            if (string.IsNullOrWhiteSpace(_form.txtDni.Text))
            {
                MessageBox.Show("El DNI del paciente es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_form.dateTimeFecha.Value == DateTime.MinValue)
            {
                MessageBox.Show("La fecha de nacimiento es obligatoria", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(_form.txtTelefono.Text))
            {
                MessageBox.Show("El teléfono del paciente es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var paciente = new Paciente
            {
                Nombre = _form.txtNombre.Text,
                Dni = _form.txtDni.Text,
                // Guardar solo la fecha de nacimiento (sin hora)
                FechaNacimiento = _form.dateTimeFecha.Value.Date,
                Email = string.IsNullOrWhiteSpace(_form.txtEmail.Text) ? null : _form.txtEmail.Text,
                Telefono = _form.txtTelefono.Text,
               
                ProfesionalId = _form.comboProfesionales.SelectedValue != null ? (int?)Convert.ToInt32(_form.comboProfesionales.SelectedValue) : null,
            };
            try
            {
                await _form.pacienteService.AddAsync(paciente);
                _form.SetState(_form.initialDisplayState);
                await _form.currentState.UpdateUI();
            }
            catch (Exception ex)
            {
                try { MessageBox.Show($"Error al guardar paciente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); } catch { }
                // Mantener en estado de agregar para permitir reintento
            }

        }

        public Task UpdateUI()
        {
            _form.txtNombre.Clear();
            _form.txtDni.Clear();
            _form.txtEmail.Clear();
            _form.txtTelefono.Clear();
            
            _form.comboProfesionales.SelectedIndex = -1;
            _form.tabControl1.SelectTab(_form.tabPageAgregarEditar);

            // Asegurar que al mostrar el formulario de agregar se establezca la fecha actual (sin hora)
            try
            {
                _form.dateTimeFecha.Format = DateTimePickerFormat.Custom;
                _form.dateTimeFecha.CustomFormat = "dd/MM/yyyy";
                _form.dateTimeFecha.Value = DateTime.Today;
            }
            catch { }

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
