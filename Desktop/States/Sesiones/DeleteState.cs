using Desktop.Interfaces;
using Desktop.Views;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            // Obtener la sesión seleccionada de forma segura
            var current = _form.ListSesiones.Current as Sesion;
            if (current == null)
            {
                MessageBox.Show("Debe seleccionar una sesión", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Construir mensaje más informativo: Profesional, Paciente y Fecha/Hora
            var profesional = current.Turno?.Profesional?.Nombre ?? "Profesional sin asignar";
            var paciente = current.Turno?.Paciente?.Nombre ?? "Paciente sin asignar";
            var fecha = current.Turno?.FechaHora;
            var fechaTexto = (fecha == null || fecha == DateTime.MinValue) ? "sin fecha" : fecha.Value.ToString("dd/MM/yyyy") + " a las " + fecha.Value.ToString("HH:mm");

            var pregunta = $"¿Está seguro que desea eliminar la sesión de {profesional} para {paciente} correspondiente al día {fechaTexto}?";

            var result = MessageBox.Show(pregunta, "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
            {
                _form.SetState(_form.initialDisplayState);
                return;
            }

            try
            {
                await _form.sesionService.DeleteAsync(current.Id);
                _form.SetState(_form.initialDisplayState);
                await _form.currentState.UpdateUI();
            }
            catch (Exception ex)
            {
                try { MessageBox.Show($"Error al eliminar la sesión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); } catch { }
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
