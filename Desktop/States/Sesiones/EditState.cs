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
    public class EditState : IFormState
    {
        private SesionesView _form;
        public EditState(SesionesView form)
        {
            _form = form ?? throw new ArgumentNullException(nameof(form), "El formulario no puede ser nulo.");

        }
        public void OnCancelar()
        {
            _form.comboTurnos.SelectedIndex = -1;
            _form.numericHonorario.Value = 0;
            _form.checkBoxPagado.Checked = false;
            _form.txtNotas.Clear();


            _form.SetState(_form.initialDisplayState);
            _form.currentState.UpdateUI();
        }
        public async void OnGuardar()
        {
            if (_form.sesionCurrent != null)
            {
                if (_form.comboTurnos.SelectedValue == null)
                {
                    MessageBox.Show("Debe seleccionar un turno atendido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _form.sesionCurrent.TurnoId = (int)_form.comboTurnos.SelectedValue;
                _form.sesionCurrent.Honorarios = _form.numericHonorario.Value;
                _form.sesionCurrent.Pagado = _form.checkBoxPagado.Checked;
                _form.sesionCurrent.Notas = _form.txtNotas.Text;

                await _form.sesionService.UpdateAsync(_form.sesionCurrent);
                _form.sesionCurrent = null;

                _form.SetState(_form.initialDisplayState);
                await _form.currentState.UpdateUI();
            }
        }
        public async Task UpdateUI()
        {
            // Obtener la sesión seleccionada desde el BindingSource (más confiable que CurrentRow)
            var current = _form.ListSesiones.Current as Sesion;
            _form.sesionCurrent = current;

            if (_form.sesionCurrent == null)
            {
                MessageBox.Show("Seleccione una sesión para editar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Cargar solo turnos disponibles o el turno actual (permitir mantener la selección)
            try
            {
                var turnos = await _form.turnoService.GetAllAsync(string.Empty) ?? new List<Service.Models.Turno>();
                var sesiones = await _form.sesionService.GetAllAsync(string.Empty) ?? new List<Sesion>();
                var usados = sesiones.Where(s => s.TurnoId.HasValue && s.Id != _form.sesionCurrent.Id).Select(s => s.TurnoId!.Value).ToHashSet();
                var disponibles = turnos.Where(t => !usados.Contains(t.Id) && t.EstadoTurno == Service.Enums.EstadoTurnoEnum.Atendido).ToList();

                var displayList = disponibles.Select(t => new
                {
                    Id = t.Id,
                    DisplayName = $"{t.Profesional?.Nombre ?? "Profesional sin asignar"} - {t.Paciente?.Nombre ?? "Paciente sin asignar"} - {t.FechaHora:dd/MM/yyyy HH:mm}"
                }).ToList();

                _form.comboTurnos.DataSource = displayList;
                _form.comboTurnos.DisplayMember = "DisplayName";
                _form.comboTurnos.ValueMember = "Id";
            }
            catch
            {
                _form.comboTurnos.DataSource = new List<Service.Models.Turno>();
            }

            // Seleccionar el turno asociado en el combo
            try { _form.comboTurnos.SelectedValue = _form.sesionCurrent.TurnoId; } catch { _form.comboTurnos.SelectedIndex = -1; }

            // Asegurar rango válido para NumericUpDown
            _form.numericHonorario.Minimum = 0;
            _form.numericHonorario.Maximum = 1000000000M; // ajustar según necesidad
            _form.numericHonorario.DecimalPlaces = 0; // solo enteros
            var honorario = _form.sesionCurrent.Honorarios;
            if (honorario < _form.numericHonorario.Minimum) honorario = _form.numericHonorario.Minimum;
            if (honorario > _form.numericHonorario.Maximum) honorario = _form.numericHonorario.Maximum;
            _form.numericHonorario.Value = Math.Truncate(honorario);
            _form.checkBoxPagado.Checked = _form.sesionCurrent.Pagado;
            _form.txtNotas.Text = _form.sesionCurrent.Notas;

            _form.tabControl1.SelectTab(_form.tabPageAgregarEditar);
            return;
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
