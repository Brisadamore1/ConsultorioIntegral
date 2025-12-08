using Desktop.Interfaces;
using Desktop.Views;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.States.Sesiones
{
    public class InitialDisplayState : IFormState
    {
        private SesionesView _form;
        public InitialDisplayState(SesionesView form)
        {
            _form = form ?? throw new ArgumentNullException(nameof(form), "El formulario no puede ser nulo.");

        }
        public async void OnBuscar()
        {
            await UpdateUI();
        }

        public void OnSalir()
        {
           _form.Close();
        }

        public async Task UpdateUI()
        {
            await CargarCombo();
            _form.dataGridSesionesView.Columns.Clear();
            _form.dataGridSesionesView.AutoGenerateColumns = false;

            if (_form.dataGridSesionesView.Columns.Count == 0)
            {
                _form.dataGridSesionesView.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "ID", DataPropertyName = "Id", Width = 60 });
                _form.dataGridSesionesView.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Turno", DataPropertyName = "TurnoDisplayName", Width = 280 });
                _form.dataGridSesionesView.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Profesional", DataPropertyName = "ProfesionalNombre", Width = 180 });
                _form.dataGridSesionesView.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Paciente", DataPropertyName = "PacienteNombre", Width = 180 });
                _form.dataGridSesionesView.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Fecha", DataPropertyName = "FechaHoraTurno", Width = 160 });
                _form.dataGridSesionesView.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Honorarios", DataPropertyName = "Honorarios", Width = 120 });
                _form.dataGridSesionesView.Columns.Add(new DataGridViewCheckBoxColumn { HeaderText = "Pagado", DataPropertyName = "Pagado", Width = 80 });
                _form.dataGridSesionesView.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Notas", DataPropertyName = "Notas", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
                _form.dataGridSesionesView.ScrollBars = ScrollBars.Vertical;
            }

            _form.ListSesiones.DataSource = await _form.sesionService.GetAllAsync(_form.txtFiltro.Text);
            _form.dataGridSesionesView.DataSource = _form.ListSesiones;

            // Encabezados en negrita
            try
            {
                var f = _form.dataGridSesionesView.ColumnHeadersDefaultCellStyle.Font ?? _form.dataGridSesionesView.Font;
                _form.dataGridSesionesView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font(f, System.Drawing.FontStyle.Bold);
            }
            catch { }

            //Esto es para cargar el dataGrid de proveedores
            _form.tabControl1.SelectTab(_form.tabPageLista);

            // No registrar múltiples manejadores Selecting para evitar refrescos involuntarios
        }
        private async Task CargarCombo()
        {
            // Cargar Turnos atendidos para el combo (usa DisplayName)
            var turnosTodos = await _form.turnoService.GetAllAsync(string.Empty);
            var turnosAtendidos = turnosTodos
                .Where(t => t.EstadoTurno == Service.Enums.EstadoTurnoEnum.Atendido)
                .ToList();
            _form.comboTurnos.DataSource = turnosAtendidos;
            _form.comboTurnos.DisplayMember = "DisplayName";
            _form.comboTurnos.ValueMember = "Id";
            _form.comboTurnos.SelectedIndex = -1;
        }

        public void OnAgregar() { }
        public void OnCancelar() { }
        public void OnGuardar() { }
        public void OnModificar() { }
        public void OnEliminar() { }
    }
}
