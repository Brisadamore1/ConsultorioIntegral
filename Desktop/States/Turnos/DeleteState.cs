using Desktop.Interfaces;
using Desktop.Views;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.States.Turnos
{
    public class DeleteState : IFormState
    {
        private TurnosView _form;
        public DeleteState(TurnosView form)
        {
            _form = form ?? throw new ArgumentNullException(nameof(form), "El formulario no puede ser nulo.");
        }
        public async void OnEliminar()
        {
            _form.turnoCurrent = (Turno)_form.ListTurnos.Current;
            if (_form.turnoCurrent == null)
            {
                MessageBox.Show("Debe seleccionar un turno", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var result = MessageBox.Show($"¿Está seguro que desea eliminar el turno {_form.turnoCurrent.Id}?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                _form.turnoCurrent = (Turno)_form.ListTurnos.Current;
                if (_form.turnoCurrent != null)
                {
                    await _form.turnoService.DeleteAsync(_form.turnoCurrent.Id);
                    _form.SetState(_form.initialDisplayState);
                    _form.currentState.UpdateUI();
                    // await CargarGrilla();
                }
            }
            else
            {
                _form.SetState(_form.initialDisplayState);
            }
            _form.turnoCurrent = null;
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
