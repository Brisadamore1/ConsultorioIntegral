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
    public class EditState : IFormState
    {
        private TurnosView _form;
        public EditState(TurnosView form)
        {
            _form = form ?? throw new ArgumentNullException(nameof(form), "El formulario no puede ser nulo.");

        }
        public void OnCancelar()
        {
            _form.txtDuracion.Clear();
           
            _form.comboPacientes.SelectedIndex = -1;
            _form.comboProfesionales.SelectedIndex = -1;
            _form.comboEstado.SelectedIndex = -1;


            _form.SetState(_form.initialDisplayState);
            _form.currentState.UpdateUI();
        }
        public async void OnGuardar()
        {
            if (_form.turnoCurrent != null)
            {
                _form.turnoCurrent.FechaHora = _form.dateTimeFecha.Value;
                _form.turnoCurrent.DuracionMinutos = int.TryParse(_form.txtDuracion.Text, out int duracion) ? duracion : 0;

                _form.turnoCurrent.ProfesionalId = (int)_form.comboProfesionales.SelectedValue;
                _form.turnoCurrent.PacienteId = (int)_form.comboPacientes.SelectedValue;
                _form.turnoCurrent.EstadoTurno = (EstadoTurnoEnum)_form.comboEstado.SelectedItem;


                await _form.turnoService.UpdateAsync(_form.turnoCurrent);
                _form.turnoCurrent = null;

                _form.SetState(_form.initialDisplayState);
                await _form.currentState.UpdateUI();
            }
        }
        public Task UpdateUI()
        {
            _form.turnoCurrent = _form.dataGridTurnosView.CurrentRow.DataBoundItem as Turno;
            _form.dateTimeFecha.Value = _form.turnoCurrent.FechaHora;
            _form.txtDuracion.Text = _form.turnoCurrent.DuracionMinutos.ToString();

            _form.comboPacientes.SelectedValue = _form.turnoCurrent.PacienteId;
            _form.comboProfesionales.SelectedValue = _form.turnoCurrent.ProfesionalId;
            _form.comboEstado.SelectedItem = _form.turnoCurrent.EstadoTurno;
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
