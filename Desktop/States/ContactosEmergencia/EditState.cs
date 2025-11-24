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
    public class EditState : IFormState
    {
        private ContactosEmergenciaView _form;
        public EditState(ContactosEmergenciaView form)
        {
            _form = form ?? throw new ArgumentNullException(nameof(form), "El formulario no puede ser nulo.");

        }
        public void OnCancelar()
        {
            _form.txtNombre.Clear();
            _form.txtRelacion.Clear();
            _form.txtTelefono.Clear();
            
            _form.comboPacientes.SelectedIndex = -1;

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
            if (_form.contactosEmergenciaCurrent != null)
            {
                _form.contactosEmergenciaCurrent.Nombre = _form.txtNombre.Text;
                _form.contactosEmergenciaCurrent.Relacion = _form.txtRelacion.Text;
                _form.contactosEmergenciaCurrent.Telefono = _form.txtTelefono.Text;
                _form.contactosEmergenciaCurrent.PacienteId = (int)_form.comboPacientes.SelectedValue;

                await _form.contactosEmergenciaService.UpdateAsync(_form.contactosEmergenciaCurrent);
                _form.contactosEmergenciaCurrent = null;

                _form.SetState(_form.initialDisplayState);
                await _form.currentState.UpdateUI();
            }
        }
        public Task UpdateUI()
        {
            _form.contactosEmergenciaCurrent = _form.dataGridContactosEmergenciaView.CurrentRow.DataBoundItem as ContactoEmergencia;
            _form.txtNombre.Text = _form.contactosEmergenciaCurrent.Nombre;
            _form.txtRelacion.Text = _form.contactosEmergenciaCurrent.Relacion;
            _form.txtTelefono.Text = _form.contactosEmergenciaCurrent.Telefono;
            _form.comboPacientes.SelectedValue = _form.contactosEmergenciaCurrent.PacienteId;
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
