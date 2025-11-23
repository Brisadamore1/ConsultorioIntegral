using Desktop.Interfaces;
using Desktop.Views;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.States.Profesionales
{
    public class DeleteState : IFormState
    {
        private ProfesionalesView _form;
        public DeleteState(ProfesionalesView form)
        {
            _form = form ?? throw new ArgumentNullException(nameof(form), "El formulario no puede ser nulo.");
        }

        public async void OnEliminar()
        {
            var profesional = (Profesional)_form.ListProfesionales.Current;
            var result = MessageBox.Show($"¿Está seguro que desea eliminar el profesional {profesional.Nombre}?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _form.profesionalCurrent = _form.ListProfesionales.Current as Profesional;
                if (_form.profesionalCurrent != null)
                {
                    // Cambiar la llamada a DeleteAsync por el servicio correspondiente
                    await _form.profesionalService.DeleteAsync(_form.profesionalCurrent.Id);
                    _form.SetState(_form.initialDisplayState);
                    await _form.currentState.UpdateUI();
                }
            }
            else
            {
                _form.SetState(_form.initialDisplayState);
            }
            _form.profesionalCurrent = null;
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
