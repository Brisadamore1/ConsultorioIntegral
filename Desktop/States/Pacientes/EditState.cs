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
            if (_form.pacienteCurrent != null)
            {
                _form.pacienteCurrent.Nombre = _form.txtNombre.Text;
                _form.pacienteCurrent.Dni = _form.txtDni.Text;
                _form.pacienteCurrent.Email = _form.txtEmail.Text;
                _form.pacienteCurrent.Telefono = _form.txtTelefono.Text;
                _form.pacienteCurrent.ProfesionalId = (int)_form.comboProfesionales.SelectedValue;

                await _form.pacienteService.UpdateAsync(_form.pacienteCurrent);
                _form.pacienteCurrent = null;

                _form.SetState(_form.initialDisplayState);
                await _form.currentState.UpdateUI();
            }
        }
        public Task UpdateUI()
        {
            _form.pacienteCurrent = _form.dataGridPacientesView.CurrentRow.DataBoundItem as Paciente;
            _form.txtNombre.Text = _form.pacienteCurrent.Nombre;
            _form.txtDni.Text = _form.pacienteCurrent.Direccion;
            _form.txtEmail.Text = _form.pacienteCurrent.Email;
            _form.txtTelefono.Text = _form.pacienteCurrent.Telefono;
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
