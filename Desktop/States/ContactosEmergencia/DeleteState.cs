using Desktop.Interfaces;
using Desktop.Views;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.States.Pacientes
{
    public class DeleteState : IFormState
    {
        private PacientesView _form;
        public DeleteState(PacientesView form)
        {
            _form = form ?? throw new ArgumentNullException(nameof(form), "El formulario no puede ser nulo.");
        }
        public async void OnEliminar()
        {
            _form.pacienteCurrent = (Paciente)_form.ListPacientes.Current;
            if (_form.pacienteCurrent == null)
            {
                MessageBox.Show("Debe seleccionar un paciente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var result = MessageBox.Show($"¿Está seguro que desea eliminar el paciente {_form.pacienteCurrent.Nombre}?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                _form.pacienteCurrent = (Paciente)_form.ListPacientes.Current;
                if (_form.pacienteCurrent != null)
                {
                    await _form.pacienteService.DeleteAsync(_form.pacienteCurrent.Id);
                    _form.SetState(_form.initialDisplayState);
                    _form.currentState.UpdateUI();
                    // await CargarGrilla();
                }
            }
            else
            {
                _form.SetState(_form.initialDisplayState);
            }
            _form.pacienteCurrent = null;
        }

        public Task UpdateUI()
        {
            return Task.CompletedTask;
        }
        public void OnAgregar() { }
        public void OnBuscar() { }
        public void OnCancelar() { }
        public void OnGuardar() { }
        public void OnModificar() { }
        public void OnSalir() { }
    }
}
