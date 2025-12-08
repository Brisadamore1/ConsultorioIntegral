using Desktop.Interfaces;
using Desktop.Views;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.States.Profesionales
{
    public class EditState : IFormState
    {
        private ProfesionalesView _form;
        public EditState(ProfesionalesView form)
        {
            _form = form ?? throw new ArgumentNullException(nameof(form), "El formulario no puede ser nulo.");
        }
        public void OnCancelar()
        {
            _form.txtNombre.Clear();
            _form.txtProfesion.Clear();
            _form.txtMatricula.Clear();
            _form.txtEspecialidad.Clear();
            _form.txtEmail.Clear();
            _form.txtTelefono.Clear();
            _form.checkBox.Checked = false;

            _form.SetState(_form.initialDisplayState);
            _form.currentState.UpdateUI();
        }

        public async void OnGuardar()
        {
            if (string.IsNullOrEmpty(_form.txtNombre.Text))
            {
                MessageBox.Show("El nombre del profesional es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_form.profesionalCurrent != null)
            {
                _form.profesionalCurrent.Nombre = _form.txtNombre.Text;
                _form.profesionalCurrent.Profesion = _form.txtProfesion.Text;
                _form.profesionalCurrent.Matricula = _form.txtMatricula.Text;
                _form.profesionalCurrent.Especialidad = _form.txtEspecialidad.Text;
                _form.profesionalCurrent.Email = _form.txtEmail.Text;
                _form.profesionalCurrent.Telefono = _form.txtTelefono.Text;
                _form.profesionalCurrent.Destacado = _form.checkBox.Checked;

                await _form.profesionalService.UpdateAsync(_form.profesionalCurrent);
                _form.profesionalCurrent = null;

                _form.SetState(_form.initialDisplayState);
                await _form.currentState.UpdateUI();
            }
        }
        public Task UpdateUI()
        {
            //Esto es para cargar el dataGrid de profesionales
            _form.profesionalCurrent = _form.dataGridProfesionalesView.CurrentRow.DataBoundItem as Profesional;
            _form.txtNombre.Text = _form.profesionalCurrent.Nombre;
            _form.txtProfesion.Text = _form.profesionalCurrent.Profesion;
            _form.txtMatricula.Text = _form.profesionalCurrent.Matricula;
            _form.txtEspecialidad.Text = _form.profesionalCurrent.Especialidad;
            _form.txtEmail.Text = _form.profesionalCurrent.Email;
            _form.txtTelefono.Text = _form.profesionalCurrent.Telefono;
            _form.checkBox.Checked = _form.profesionalCurrent.Destacado ?? false;

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
