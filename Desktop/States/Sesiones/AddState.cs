using Desktop.Interfaces;
using Desktop.Views;
using Service.Models;
using Service.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.States.Sesiones
{
    public class AddState : IFormState
    {
        private SesionesView _form;

        public AddState(SesionesView form)
        {
            _form = form ?? throw new ArgumentNullException(nameof(form), "El formulario no puede ser nulo.");

        }
       
        public void OnCancelar()
        {
            // Limpiar campos de Sesión cuando se cancela
            _form.comboTurnos.SelectedIndex = -1;
            _form.numericHonorario.Value = 0;
            _form.checkBoxPagado.Checked = false;
            _form.txtNotas.Clear();

            _form.SetState(_form.initialDisplayState);
            _form.currentState.UpdateUI();
        }


        public async void OnGuardar()
        {
            if (_form.comboTurnos.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un turno atendido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var sesion = new Sesion
            {
                TurnoId = (int)_form.comboTurnos.SelectedValue,
                Honorarios = _form.numericHonorario.Value,
                Pagado = _form.checkBoxPagado.Checked,
                Notas = _form.txtNotas.Text
            };

            await _form.sesionService.AddAsync(sesion);
            _form.SetState(_form.initialDisplayState);
            await _form.currentState.UpdateUI();

        }

        public async Task UpdateUI()
        {
            // Cargar solo turnos que no tienen sesión asignada
            try
            {
                var turnos = await _form.turnoService.GetAllAsync(string.Empty) ?? new List<Service.Models.Turno>();
                var sesiones = await _form.sesionService.GetAllAsync(string.Empty) ?? new List<Sesion>();
                var usados = sesiones.Where(s => s.TurnoId.HasValue).Select(s => s.TurnoId!.Value).ToHashSet();
                var disponibles = turnos.Where(t => !usados.Contains(t.Id) && t.EstadoTurno == EstadoTurnoEnum.Atendido).ToList();

                var displayList = disponibles.Select(t => new
                {
                    Id = t.Id,
                    DisplayName = $"{t.Profesional?.Nombre ?? "Profesional sin asignar"} - {t.Paciente?.Nombre ?? "Paciente sin asignar"} - {t.FechaHora:dd/MM/yyyy HH:mm}"
                }).ToList();

                _form.comboTurnos.DataSource = displayList;
                _form.comboTurnos.DisplayMember = "DisplayName";
                _form.comboTurnos.ValueMember = "Id";
                _form.comboTurnos.SelectedIndex = -1;
            }
            catch
            {
                // Si falla, dejar combo vacío para evitar duplicados
                _form.comboTurnos.DataSource = new List<Service.Models.Turno>();
                _form.comboTurnos.SelectedIndex = -1;
            }

            _form.numericHonorario.Value = 0;
            _form.checkBoxPagado.Checked = false;
            _form.txtNotas.Clear();
            _form.tabControl1.SelectTab(_form.tabPageAgregarEditar);
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
