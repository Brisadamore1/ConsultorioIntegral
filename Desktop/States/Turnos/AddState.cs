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
            try
            {
                // Validaciones básicas para evitar excepciones por SelectedValue nulo o tipos inesperados
                if (_form.comboProfesionales.SelectedValue == null || _form.comboPacientes.SelectedValue == null)
                {
                    MessageBox.Show("Debe seleccionar Profesional y Paciente antes de guardar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (_form.comboEstado.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar el Estado del turno.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Convertir SelectedValue a int de forma segura
                int pacienteId;
                int profesionalId;
                try
                {
                    pacienteId = Convert.ToInt32(_form.comboPacientes.SelectedValue);
                }
                catch
                {
                    MessageBox.Show("Id de Paciente inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try
                {
                    profesionalId = Convert.ToInt32(_form.comboProfesionales.SelectedValue);
                }
                catch
                {
                    MessageBox.Show("Id de Profesional inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Duración segura
                int duracion = int.TryParse(_form.txtDuracion.Text, out int d) ? d : 0;

                // Estado: intentar castear o parsear
                EstadoTurnoEnum estado;
                if (_form.comboEstado.SelectedItem is EstadoTurnoEnum e)
                    estado = e;
                else
                {
                    try { estado = (EstadoTurnoEnum)Enum.Parse(typeof(EstadoTurnoEnum), _form.comboEstado.SelectedItem.ToString()); }
                    catch { estado = EstadoTurnoEnum.Reservado; }
                }

                var turno = new Turno
                {
                    FechaHora = _form.dateTimeFecha.Value,
                    DuracionMinutos = duracion,
                    PacienteId = pacienteId,
                    ProfesionalId = profesionalId,
                    EstadoTurno = estado
                };

                await _form.turnoService.AddAsync(turno);
                _form.SetState(_form.initialDisplayState);
                await _form.currentState.UpdateUI();
            }
            catch (Exception ex)
            {
                try { MessageBox.Show($"Error al guardar el turno: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); } catch { }
            }

        }

        public Task UpdateUI()
        {
            _form.txtDuracion.Clear();

            // Al iniciar el modo agregar, fijar la fecha y hora al momento actual y limpiar el calendario
            try { _form.dateTimeFecha.Value = DateTime.Now; } catch { }
            
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
