using Desktop.Interfaces;
using Desktop.Views;
using Service.Services;
using Service.Models;
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
            // Cargar datos iniciales
            await CargarCombo();

            // Columnas generadas automáticamente por el DataGridView (ver SesionesView.Designer.cs)

            // Obtener todos y luego aplicar filtro local por paciente y profesional (nombre y apellido)
            List<Sesion> all;
            try
            {
                all = (await _form.sesionService.GetAllAsync(string.Empty))?.ToList() ?? new List<Sesion>();
            }
            catch (Exception ex)
            {
                try { MessageBox.Show($"Error al obtener sesiones: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); } catch { }
                all = new List<Sesion>();
            }

            try { if (_form.txtFiltro.Tag is EventHandler old) _form.txtFiltro.TextChanged -= old; } catch { }
            EventHandler h = (s, e) =>
            {
                var txt = _form.txtFiltro.Text?.Trim();
                if (string.IsNullOrEmpty(txt)) { _form.ListSesiones.DataSource = all; return; }
                var terms = txt.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var filtered = all.Where(item =>
                    (
                        !string.IsNullOrEmpty(item.PacienteNombre) && terms.All(t => item.PacienteNombre.IndexOf(t, StringComparison.OrdinalIgnoreCase) >= 0)
                    )
                    || (
                        !string.IsNullOrEmpty(item.ProfesionalNombre) && terms.All(t => item.ProfesionalNombre.IndexOf(t, StringComparison.OrdinalIgnoreCase) >= 0)
                    )
                ).ToList();
                _form.ListSesiones.DataSource = filtered;
            };
            _form.txtFiltro.Tag = h;
            _form.txtFiltro.TextChanged += h;

            _form.ListSesiones.DataSource = all;
            _form.dataGridSesionesView.DataSource = _form.ListSesiones;

            // Activar ajuste de filas para mostrar texto multilínea (notas) y scrolls
            try { _form.dataGridSesionesView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells; } catch { }
            try { _form.dataGridSesionesView.ScrollBars = ScrollBars.Both; } catch { }

            // Ajustar visibilidad y orden de columnas según preferencia
            try
            {
                var cols = _form.dataGridSesionesView.Columns;
                // Ocultar columnas innecesarias
                if (cols.Contains("TurnoId")) cols["TurnoId"].Visible = false;
                if (cols.Contains("Turno")) cols["Turno"].Visible = false;
                if (cols.Contains("IsDeleted")) cols["IsDeleted"].Visible = false;
                if (cols.Contains("TurnoDisplayName")) cols["TurnoDisplayName"].Visible = false;

                // Orden deseado: Id, Profesional, Paciente, FechaHora, Honorarios (entero), Pagado, Notas
                int di = 0;
                if (cols.Contains("Id")) { cols["Id"].DisplayIndex = di++; cols["Id"].HeaderText = "Id"; }
                if (cols.Contains("ProfesionalNombre")) { cols["ProfesionalNombre"].DisplayIndex = di++; cols["ProfesionalNombre"].HeaderText = "Profesional"; }
                if (cols.Contains("PacienteNombre")) { cols["PacienteNombre"].DisplayIndex = di++; cols["PacienteNombre"].HeaderText = "Paciente"; }
                if (cols.Contains("FechaHoraTurno")) { cols["FechaHoraTurno"].DisplayIndex = di++; cols["FechaHoraTurno"].HeaderText = "Fecha y Hora"; try { cols["FechaHoraTurno"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm"; } catch { } }
                if (cols.Contains("Honorarios")) { cols["Honorarios"].DisplayIndex = di++; try { cols["Honorarios"].DefaultCellStyle.Format = "N0"; cols["Honorarios"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; } catch { } }
                if (cols.Contains("Pagado")) { cols["Pagado"].DisplayIndex = di++; }
                if (cols.Contains("Notas")) { cols["Notas"].DisplayIndex = di++; cols["Notas"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; try { cols["Notas"].DefaultCellStyle.WrapMode = DataGridViewTriState.True; } catch { } }
            }
            catch { }

            // Desactivar la fila de nuevo registro
            _form.dataGridSesionesView.AllowUserToAddRows = false;

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
