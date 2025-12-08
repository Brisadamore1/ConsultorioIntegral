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
    public class EditState : IFormState
    {
        private PacientesView _form;
        public EditState(PacientesView form)
        {
            _form = form ?? throw new ArgumentNullException(nameof(form), "El formulario no puede ser nulo.");

        }
        public void OnCancelar()
        {
            _form.txtNombre.Clear();
            _form.txtDni.Clear();
            _form.txtEmail.Clear();
            _form.txtTelefono.Clear();
            
            _form.comboProfesionales.SelectedIndex = -1;

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
            if (string.IsNullOrWhiteSpace(_form.txtTelefono.Text))
            {
                MessageBox.Show("El teléfono del paciente es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // validar email si fue completado
            if (!string.IsNullOrWhiteSpace(_form.txtEmail.Text))
            {
                var emailAttr = new System.ComponentModel.DataAnnotations.EmailAddressAttribute();
                if (!emailAttr.IsValid(_form.txtEmail.Text))
                {
                    MessageBox.Show("El campo Email no tiene un formato válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (_form.pacienteCurrent != null)
            {
                _form.pacienteCurrent.Nombre = _form.txtNombre.Text;
                _form.pacienteCurrent.Dni = _form.txtDni.Text;
                // Email es opcional: enviar null si está vacío para no romper la validación del servidor
                _form.pacienteCurrent.Email = string.IsNullOrWhiteSpace(_form.txtEmail.Text) ? null : _form.txtEmail.Text;
                _form.pacienteCurrent.Telefono = _form.txtTelefono.Text;
                // Asegurar que sólo se guarde la fecha (sin hora)
                _form.pacienteCurrent.FechaNacimiento = _form.dateTimeFecha.Value.Date;
                _form.pacienteCurrent.ProfesionalId = _form.comboProfesionales.SelectedValue != null ? (int?)Convert.ToInt32(_form.comboProfesionales.SelectedValue) : null;

                try
                {
                    await _form.pacienteService.UpdateAsync(_form.pacienteCurrent);
                    _form.pacienteCurrent = null;
                    _form.SetState(_form.initialDisplayState);
                    await _form.currentState.UpdateUI();
                }
                catch (Exception ex)
                {
                    // Mostrar detalle de error si viene del servidor
                    try { MessageBox.Show($"Error al actualizar paciente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); } catch { }
                }
            }
        }
        public Task UpdateUI()
        {
            _form.pacienteCurrent = _form.dataGridPacientesView.CurrentRow.DataBoundItem as Paciente;
            _form.txtNombre.Text = _form.pacienteCurrent.Nombre;
            _form.txtDni.Text = _form.pacienteCurrent.Dni;
            _form.txtEmail.Text = _form.pacienteCurrent.Email;
            _form.txtTelefono.Text = _form.pacienteCurrent.Telefono;
            // Mostrar solo la fecha en el control DateTimePicker
            try { _form.dateTimeFecha.Value = _form.pacienteCurrent.FechaNacimiento.Date; } catch { }
            _form.comboProfesionales.SelectedValue = _form.pacienteCurrent.ProfesionalId;
            _form.tabControl1.SelectTab(_form.tabPageAgregarEditar);
            return Task.CompletedTask;
        }

        public void OnModificar()
        {
            UpdateUI();
        }
        public void OnSalir() { }
        public void OnEliminar() { }
        public void OnBuscar() { }
        public void OnAgregar() { }

    }
}
