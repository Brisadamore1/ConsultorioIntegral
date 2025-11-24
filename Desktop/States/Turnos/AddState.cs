using Desktop.Interfaces;
using Desktop.Views;
using Service.Enums;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.States.Turnos
{
    public class AddState : IFormState
    {
        private TurnosView _form;

        public AddState(TurnosView form)
        {
            _form = form ?? throw new ArgumentNullException(nameof(form), "El formulario no puede ser nulo.");

        }
       
        public void OnCancelar()
        {
            //esto es para limpiar los campos del formulario cuando se cancela la operación de agregar un Turno.
            _form.txtDuracion.Clear();

            _form.comboPacientes.SelectedIndex = -1; // Limpia la selección del combo de pacientes
            _form.comboProfesionales.SelectedIndex = -1; // Limpia la selección del combo de profesionales
            _form.comboEstado.SelectedIndex = -1; // Limpia la selección del combo de estados

            _form.SetState(_form.initialDisplayState);
            _form.currentState.UpdateUI();
        }


        public async void OnGuardar()
        {
            var turno = new Turno
            {
                FechaHora = _form.dateTimeFecha.Value,
                DuracionMinutos = int.TryParse(_form.txtDuracion.Text, out int duracion) ? duracion : 0,

                PacienteId = (int)_form.comboPacientes.SelectedValue,
                ProfesionalId = (int)_form.comboProfesionales.SelectedValue,

                EstadoTurno = (EstadoTurnoEnum)_form.comboEstado.SelectedItem
            };
            await _form.turnoService.AddAsync(turno);
            _form.SetState(_form.initialDisplayState);
            await _form.currentState.UpdateUI();

        }

        public Task UpdateUI()
        {
            _form.txtDuracion.Clear();
            
            _form.comboPacientes.SelectedIndex = -1;
            _form.comboProfesionales.SelectedIndex = -1;
            _form.comboEstado.SelectedIndex = -1;
            _form.tabControl1.SelectTab(_form.tabPageAgregarEditar);
            return Task.CompletedTask;

        }
        public void OnAgregar()
        {
            UpdateUI();
        }
        public void OnSalir() { }
        public void OnModificar() { }
        public void OnEliminar() { }
        public void OnBuscar() { }
    }
}
