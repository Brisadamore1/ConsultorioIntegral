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

namespace Desktop.States.Turnos
{
    public class InitialDisplayState : IFormState
    {
        private TurnosView _form;
        public InitialDisplayState(TurnosView form)
        {
            _form = form ?? throw new ArgumentNullException(nameof(form), "El formulario no puede ser nulo.");
            // Registrar una sola vez el manejador para evitar duplicados cuando UpdateUI se ejecuta repetidas veces
            try { _form.tabControl1.Selecting -= TabControl_Selecting; } catch { }
            _form.tabControl1.Selecting += TabControl_Selecting;

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

            // Obtener todos y luego aplicar filtro local por paciente y profesional (nombre y apellido)
            var all = (await _form.turnoService.GetAllAsync(string.Empty))?.ToList() ?? new List<Turno>();

            try { if (_form.txtFiltro.Tag is EventHandler old) _form.txtFiltro.TextChanged -= old; } catch { }
            EventHandler h = (s, e) =>
            {
                var txt = _form.txtFiltro.Text?.Trim();
                if (string.IsNullOrEmpty(txt)) { _form.ListTurnos.DataSource = all; return; }
                var terms = txt.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var filtered = all.Where(item =>
                    (item.Paciente != null && terms.All(t => (item.Paciente.Nombre ?? string.Empty).IndexOf(t, StringComparison.OrdinalIgnoreCase) >= 0 || (item.Paciente.ToString() ?? string.Empty).IndexOf(t, StringComparison.OrdinalIgnoreCase) >= 0))
                    || (item.Profesional != null && terms.All(t => (item.Profesional.Nombre ?? string.Empty).IndexOf(t, StringComparison.OrdinalIgnoreCase) >= 0 || (item.Profesional.ToString() ?? string.Empty).IndexOf(t, StringComparison.OrdinalIgnoreCase) >= 0))
                ).ToList();
                _form.ListTurnos.DataSource = filtered;
            };
            _form.txtFiltro.Tag = h;
            _form.txtFiltro.TextChanged += h;

            _form.ListTurnos.DataSource = all;
            EnsureColumns();
            _form.dataGridTurnosView.DataSource = _form.ListTurnos;

            #region Ocultar columnas innecesarias
            if (_form.dataGridTurnosView.Columns.Contains("PacienteId"))
                _form.dataGridTurnosView.Columns["PacienteId"].Visible = false;
            if (_form.dataGridTurnosView.Columns.Contains("ProfesionalId"))
                _form.dataGridTurnosView.Columns["ProfesionalId"].Visible = false;
            if (_form.dataGridTurnosView.Columns.Contains("CanceladoPorProfesional"))
                _form.dataGridTurnosView.Columns["CanceladoPorProfesional"].Visible = false;
            if (_form.dataGridTurnosView.Columns.Contains("MotivoCancelacion"))
                _form.dataGridTurnosView.Columns["MotivoCancelacion"].Visible = false;
            if (_form.dataGridTurnosView.Columns.Contains("IsDeleted"))
                _form.dataGridTurnosView.Columns["IsDeleted"].Visible = false;
            if (_form.dataGridTurnosView.Columns.Contains("DisplayName"))
                _form.dataGridTurnosView.Columns["DisplayName"].Visible = false;
            #endregion

            // Ordenar y renombrar columnas para mostrar solo las que importan en el orden requerido
            try
            {
                var cols = _form.dataGridTurnosView.Columns;
                // Preferencia de orden: Id, Profesional, Paciente, FechaHora, DuracionMinutos, EstadoTurno
                var keys = new[] { "Id", "Profesional", "Paciente", "FechaHora", "DuracionMinutos", "EstadoTurno" };
                int di = 0;
                foreach (var key in keys)
                {
                    if (cols.Contains(key))
                    {
                        var c = cols[key];
                        c.Visible = true;
                        if (string.Equals(key, "Profesional", StringComparison.OrdinalIgnoreCase))
                            c.HeaderText = "Profesional";
                        if (string.Equals(key, "Paciente", StringComparison.OrdinalIgnoreCase))
                            c.HeaderText = "Paciente";
                        if (string.Equals(key, "FechaHora", StringComparison.OrdinalIgnoreCase))
                        {
                            c.HeaderText = "Fecha y Hora";
                            try { c.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm"; } catch { }
                            try { c.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; } catch { }
                            try { c.HeaderCell.Style.WrapMode = DataGridViewTriState.False; c.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader; c.MinimumWidth = 140; } catch { }
                        }
                        if (string.Equals(key, "DuracionMinutos", StringComparison.OrdinalIgnoreCase))
                        {
                            c.HeaderText = "Duración (min)";
                            try { c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; } catch { }
                        }
                        if (string.Equals(key, "EstadoTurno", StringComparison.OrdinalIgnoreCase))
                            c.HeaderText = "Estado Turno";

                        c.DisplayIndex = di++;
                        continue;
                    }

                    var found = cols.Cast<DataGridViewColumn>()
                        .FirstOrDefault(c => string.Equals(c.DataPropertyName, key, StringComparison.OrdinalIgnoreCase)
                                             || string.Equals(c.Name, key, StringComparison.OrdinalIgnoreCase)
                                             || string.Equals(c.HeaderText, key, StringComparison.OrdinalIgnoreCase));
                    if (found != null)
                    {
                        found.Visible = true;
                        if (string.Equals(key, "Profesional", StringComparison.OrdinalIgnoreCase))
                            found.HeaderText = "Profesional";
                        if (string.Equals(key, "Paciente", StringComparison.OrdinalIgnoreCase))
                            found.HeaderText = "Paciente";
                        if (string.Equals(key, "FechaHora", StringComparison.OrdinalIgnoreCase))
                        {
                            found.HeaderText = "Fecha y Hora";
                            try { found.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm"; } catch { }
                            try { found.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; } catch { }
                        }
                        if (string.Equals(key, "DuracionMinutos", StringComparison.OrdinalIgnoreCase))
                        {
                            found.HeaderText = "Duración (minutos)";
                            try { found.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; } catch { }
                            try { found.HeaderCell.Style.WrapMode = DataGridViewTriState.False; found.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader; found.MinimumWidth = 90; } catch { }
                        }
                        if (string.Equals(key, "EstadoTurno", StringComparison.OrdinalIgnoreCase))
                        {
                            found.HeaderText = "Estado Turno";
                            try { found.HeaderCell.Style.WrapMode = DataGridViewTriState.False; found.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader; found.MinimumWidth = 110; } catch { }
                        }

                        found.DisplayIndex = di++;
                    }
                }
            }
            catch { }

            // Desactivar la fila de nuevo registro
            _form.dataGridTurnosView.AllowUserToAddRows = false;

            // Encabezados en negrita
            try
            {
                var f = _form.dataGridTurnosView.ColumnHeadersDefaultCellStyle.Font ?? _form.dataGridTurnosView.Font;
                _form.dataGridTurnosView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font(f, System.Drawing.FontStyle.Bold);
            }
            catch { }

            //Esto es para cargar el dataGrid de proveedores
            _form.tabControl1.SelectTab(_form.tabPageLista);

            _form.tabControl1.Selecting += (sender, e) =>
            {
                if (e.TabPage == _form.tabPageAgregarEditar)
                    if (_form.currentState == _form.initialDisplayState)
                    {
                        e.Cancel = true; // Evita que se cambie a la pestaña de agregar/editar directamente desde el estado inicial
                    }
                if (e.TabPage == _form.tabPageLista)
                    if (_form.currentState == _form.addState || _form.currentState == _form.editState)
                    {
                        e.Cancel = true; // Deshabilita la pestaña de agregar/editar si no está en el estado inicial
                    }
            };
        }

        private void TabControl_Selecting(object? sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage == _form.tabPageAgregarEditar && _form.currentState == _form.initialDisplayState) e.Cancel = true;
            if (e.TabPage == _form.tabPageLista && (_form.currentState == _form.addState || _form.currentState == _form.editState)) e.Cancel = true;
        }

        private void EnsureColumns()
        {
            try { _form.dataGridTurnosView.AutoGenerateColumns = false; } catch { }
            if (_form.dataGridTurnosView.Columns.Contains("Id")) return;

            _form.dataGridTurnosView.Columns.Clear();
            DataGridViewColumn Col(string name, string prop, string header, DataGridViewContentAlignment? align = null, string format = null, int minWidth = 0, DataGridViewAutoSizeColumnMode mode = DataGridViewAutoSizeColumnMode.ColumnHeader)
            {
                var c = new DataGridViewTextBoxColumn { Name = name, DataPropertyName = prop, HeaderText = header, ReadOnly = true };
                if (align.HasValue) c.DefaultCellStyle.Alignment = align.Value;
                if (!string.IsNullOrEmpty(format)) c.DefaultCellStyle.Format = format;
                c.HeaderCell.Style.WrapMode = DataGridViewTriState.False;
                c.AutoSizeMode = mode;
                if (minWidth > 0) try { c.MinimumWidth = minWidth; } catch { }
                return c;
            }

            _form.dataGridTurnosView.Columns.AddRange(new DataGridViewColumn[] {
                Col("Id","Id","Id",DataGridViewContentAlignment.MiddleLeft,null,50,DataGridViewAutoSizeColumnMode.ColumnHeader),
                Col("Profesional","Profesional","Profesional",DataGridViewContentAlignment.MiddleLeft,null,200,DataGridViewAutoSizeColumnMode.AllCells),
                Col("Paciente","Paciente","Paciente",DataGridViewContentAlignment.MiddleLeft,null,200,DataGridViewAutoSizeColumnMode.AllCells),
                Col("FechaHora","FechaHora","Fecha y Hora",DataGridViewContentAlignment.MiddleCenter,"dd/MM/yyyy HH:mm",140,DataGridViewAutoSizeColumnMode.ColumnHeader),
                Col("DuracionMinutos","DuracionMinutos","Duración (min)",DataGridViewContentAlignment.MiddleLeft,null,90,DataGridViewAutoSizeColumnMode.ColumnHeader),
                Col("EstadoTurno","EstadoTurno","Estado Turno",DataGridViewContentAlignment.MiddleLeft,null,110,DataGridViewAutoSizeColumnMode.ColumnHeader)
            });

            try { _form.dataGridTurnosView.CellFormatting -= DataGridTurnosView_CellFormatting; } catch { }
            _form.dataGridTurnosView.CellFormatting += DataGridTurnosView_CellFormatting;
        }

       
        private void DataGridTurnosView_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                var grid = _form.dataGridTurnosView;
                var column = grid.Columns[e.ColumnIndex];

                if (column.Name.Equals("Profesional", StringComparison.OrdinalIgnoreCase))
                {
                    if (e.Value is Service.Models.Profesional prof)
                    {
                        e.Value = prof.Nombre;
                        e.FormattingApplied = true;
                    }
                    else if (e.Value != null && e.Value.ToString()!.Contains("Profesional"))
                    {
                        // fallback
                    }
                }
                else if (column.Name.Equals("Paciente", StringComparison.OrdinalIgnoreCase))
                {
                    if (e.Value is Service.Models.Paciente pac)
                    {
                        e.Value = pac.Nombre;
                        e.FormattingApplied = true;
                    }
                }
                else if (column.Name.Equals("DuracionMinutos", StringComparison.OrdinalIgnoreCase))
                {
                    // Alinear valores de duración a la izquierda
                    try { column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft; } catch { }
                }
            }
            catch { }
        }
        private async Task CargarCombo()
        {
            // Cargar Pacientes
            _form.comboPacientes.DataSource = await _form.pacienteService.GetAllAsync(string.Empty);
            _form.comboPacientes.DisplayMember = "Nombre";
            _form.comboPacientes.ValueMember = "Id";
            _form.comboPacientes.SelectedIndex = -1;

            _form.comboProfesionales.DataSource = await _form.profesionalService.GetAllAsync(string.Empty);
            _form.comboProfesionales.DisplayMember = "Nombre";
            _form.comboProfesionales.ValueMember = "Id";
            _form.comboProfesionales.SelectedIndex = -1;

            _form.comboEstado.DataSource = Enum.GetValues(typeof(Service.Enums.EstadoTurnoEnum));
            _form.comboEstado.SelectedIndex = -1;
        }

        public void OnAgregar() { }
        public void OnCancelar() { }
        public void OnGuardar() { }
        public void OnModificar() { }
        public void OnEliminar() { }
    }
}
