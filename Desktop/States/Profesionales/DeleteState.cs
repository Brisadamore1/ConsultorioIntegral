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
            var profesional = _form.ListProfesionales.Current as Profesional;
            if (profesional == null)
            {
                MessageBox.Show("No hay un profesional seleccionado.", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show($"¿Está seguro que desea eliminar el profesional {profesional.Nombre}?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                await _form.profesionalService.DeleteAsync(profesional.Id);
                _form.SetState(_form.initialDisplayState);
                await _form.currentState.UpdateUI();
            }
            else
            {
                _form.SetState(_form.initialDisplayState);
            }
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
