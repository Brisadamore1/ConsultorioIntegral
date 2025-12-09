using Desktop.Interfaces;
using Desktop.Views;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            // Obtener el turno seleccionado de forma segura
            var current = _form.ListTurnos.Current as Turno;
            if (current == null)
            {
                MessageBox.Show("Debe seleccionar un turno", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Construir mensaje más informativo: Profesional, Paciente y Fecha/Hora
            var profesional = current.Profesional?.Nombre ?? "Profesional sin asignar";
            var paciente = current.Paciente?.Nombre ?? "Paciente sin asignar";
            var fecha = current.FechaHora;
            var fechaTexto = fecha == DateTime.MinValue ? "sin fecha" : fecha.ToString("dd/MM/yyyy") + " a las " + fecha.ToString("HH:mm");

            var pregunta = $"¿Está seguro que desea eliminar el turno de {profesional} para {paciente} correspondiente al día {fechaTexto}?";

            var result = MessageBox.Show(pregunta, "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
            {
                _form.SetState(_form.initialDisplayState);
                return;
            }

            try
            {
                await _form.turnoService.DeleteAsync(current.Id);
                _form.SetState(_form.initialDisplayState);
                await _form.currentState.UpdateUI();
            }
            catch (Exception ex)
            {
                try { MessageBox.Show($"Error al eliminar el turno: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); } catch { }
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
