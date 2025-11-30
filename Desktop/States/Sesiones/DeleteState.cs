using Desktop.Interfaces;
using Desktop.Views;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.States.Sesiones
{
    public class DeleteState : IFormState
    {
        private SesionesView _form;
        public DeleteState(SesionesView form)
        {
            _form = form ?? throw new ArgumentNullException(nameof(form), "El formulario no puede ser nulo.");
        }
        public async void OnEliminar()
        {
            _form.sesionCurrent = (Sesion)_form.ListSesiones.Current;
            if (_form.sesionCurrent == null)
            {
                MessageBox.Show("Debe seleccionar una sesión", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var result = MessageBox.Show($"¿Está seguro que desea eliminar la sesión {_form.sesionCurrent.Id}?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                _form.sesionCurrent = (Sesion)_form.ListSesiones.Current;
                if (_form.sesionCurrent != null)
                {
                    await _form.sesionService.DeleteAsync(_form.sesionCurrent.Id);
                    _form.SetState(_form.initialDisplayState);
                    _form.currentState.UpdateUI();
                }
            }
            else
            {
                _form.SetState(_form.initialDisplayState);
            }
            _form.sesionCurrent = null;
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
