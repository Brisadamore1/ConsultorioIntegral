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
using System.ComponentModel;

namespace Desktop.States.Sesiones
{
    public class InitialDisplayState : IFormState
    {
        private SesionesView _form;
        private bool _columnsInitialized = false;
        private bool _dataBindingHandlerRegistered = false;
        public InitialDisplayState(SesionesView form)
        {
            _form = form ?? throw new ArgumentNullException(nameof(form), "El formulario no puede ser nulo.");

        }

        private void DataGridSesionesView_DataBindingComplete(object? sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                var dgv = _form.dataGridSesionesView;
                var colsVisible = dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.Visible).ToList();
                var notasCol = colsVisible.FirstOrDefault(c => string.Equals(c.Name, "Notas", StringComparison.OrdinalIgnoreCase));
                if (notasCol != null)
                {
                    notasCol.DisplayIndex = Math.Max(0, colsVisible.Count - 1);
                }
            }
            catch { }
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

            // Registrar handler para filtrado en vivo (comportamiento funcional original)
            try { if (_form.txtFiltro.Tag is EventHandler old) _form.txtFiltro.TextChanged -= old; } catch { }

            // Asignar datos y enlazar vista
            _form.ListSesiones.DataSource = all;
            _form.dataGridSesionesView.DataSource = _form.ListSesiones;

            EventHandler handler = (s, e) =>
            {
                var txt = _form.txtFiltro.Text?.Trim();
                if (string.IsNullOrEmpty(txt))
                {
                    _form.ListSesiones.DataSource = all;
                    return;
                }
                var terms = txt.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var filtered = all.Where(item =>
                    (!string.IsNullOrEmpty(item.PacienteNombre) && terms.All(t => item.PacienteNombre.IndexOf(t, StringComparison.OrdinalIgnoreCase) >= 0))
                    || (!string.IsNullOrEmpty(item.ProfesionalNombre) && terms.All(t => item.ProfesionalNombre.IndexOf(t, StringComparison.OrdinalIgnoreCase) >= 0))
                ).ToList();

                _form.ListSesiones.DataSource = filtered;
            };
            _form.txtFiltro.Tag = handler;
            _form.txtFiltro.TextChanged += handler;

            // Asegurar que Notas quede al final después del binding (defensa mínima)
            try { _form.dataGridSesionesView.DataBindingComplete -= DataGridSesionesView_DataBindingComplete; } catch { }
            _form.dataGridSesionesView.DataBindingComplete += DataGridSesionesView_DataBindingComplete;

            // Asegurar formateo personalizado de celdas (por ejemplo, mostrar "Sin asignar" cuando Notas esté vacío)
            try { _form.dataGridSesionesView.CellFormatting -= DataGridSesionesView_CellFormatting; } catch { }
            _form.dataGridSesionesView.CellFormatting += DataGridSesionesView_CellFormatting;



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

                // Colocar Notas justo después de Fecha y Hora
                if (cols.Contains("Notas"))
                {
                    cols["Notas"].DisplayIndex = di++; cols["Notas"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; try { cols["Notas"].DefaultCellStyle.WrapMode = DataGridViewTriState.True; } catch { }
                }

                if (cols.Contains("Honorarios")) { cols["Honorarios"].DisplayIndex = di++; try { cols["Honorarios"].DefaultCellStyle.Format = "N0"; cols["Honorarios"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; } catch { } }
                if (cols.Contains("Pagado")) { cols["Pagado"].DisplayIndex = di++; }
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
        
        // Manejador para formateo de celdas: muestra "Sin asignar" cuando Notas está vacío
        private void DataGridSesionesView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
                var grid = _form?.dataGridSesionesView;
                if (grid == null) return;
                if (e.ColumnIndex >= grid.Columns.Count) return;

                var col = grid.Columns[e.ColumnIndex];
                if (string.Equals(col.Name, "Notas", StringComparison.OrdinalIgnoreCase))
                {
                    if (e.Value == null || string.IsNullOrWhiteSpace(e.Value?.ToString()))
                    {
                        e.Value = "Sin asignar";
                        e.FormattingApplied = true;
                    }
                }
            }
            catch
            {
                // Ignorar errores de formateo
            }
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
