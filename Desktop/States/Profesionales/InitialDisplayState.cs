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

namespace Desktop.States.Profesionales
{
    public class InitialDisplayState : IFormState
    {
        private ProfesionalesView _form;
        public InitialDisplayState(ProfesionalesView form)
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

        // live filter will be wired in UpdateUI using a small lambda stored in txtFiltro.Tag

        public async Task UpdateUI()
        {
            // Obtener todos y luego filtrar localmente de forma case-insensitive para búsqueda en vivo
            var all = (await _form.profesionalService.GetAllAsync(string.Empty))?.ToList() ?? new List<Profesional>();
            // Guardar copia para posibles usos posteriores
            _form.ListaAFiltrar = all;
            // Inicialmente mostrar todos
            _form.ListProfesionales.DataSource = all;

            // Esto es para el filtro en vivo
            try { if (_form.txtFiltro.Tag is EventHandler old) _form.txtFiltro.TextChanged -= old; } catch { }
            EventHandler newHandler = (s, e) =>
            {
                var txt = _form.txtFiltro.Text?.Trim();
                var allLocal = _form.ListaAFiltrar ?? new List<Profesional>();
                if (string.IsNullOrEmpty(txt))
                {
                    _form.ListProfesionales.DataSource = allLocal;
                    return;
                }
                var terms = txt.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                _form.ListProfesionales.DataSource = allLocal.Where(item =>
                {
                    var nombre = item.Nombre ?? string.Empty;
                    var profesion = item.Profesion ?? string.Empty;
                    return terms.All(t =>
                        nombre.IndexOf(t, StringComparison.OrdinalIgnoreCase) >= 0
                        || profesion.IndexOf(t, StringComparison.OrdinalIgnoreCase) >= 0
                    );
                }).ToList();
            };
            _form.txtFiltro.Tag = newHandler;
            _form.txtFiltro.TextChanged += newHandler;

            _form.dataGridProfesionalesView.DataSource = _form.ListProfesionales;

            // Evitar la fila "nueva" editable al fondo
            _form.dataGridProfesionalesView.AllowUserToAddRows = false;

            #region Ocultar columnas innecesarias
            if (_form.dataGridProfesionalesView.Columns.Contains("Pacientes"))
                _form.dataGridProfesionalesView.Columns["Pacientes"].Visible = false;
            if (_form.dataGridProfesionalesView.Columns.Contains("IsDeleted"))
                _form.dataGridProfesionalesView.Columns["IsDeleted"].Visible = false;
            if (_form.dataGridProfesionalesView.Columns.Contains("Imagen"))
                _form.dataGridProfesionalesView.Columns["Imagen"].Visible = false;
            #endregion

            // Orden simple y directo: Id, Nombre, Profesion, Especialidad, Matricula, Email, Telefono, Destacado
            var keys = new[] { "Id", "Nombre", "Profesion", "Especialidad", "Matricula", "Email", "Telefono", "Destacado" };
            int di = 0;
            foreach (var key in keys)
            {
                if (_form.dataGridProfesionalesView.Columns.Contains(key))
                {
                    var c = _form.dataGridProfesionalesView.Columns[key];
                    c.Visible = true;
                    if (string.Equals(key, "Nombre", StringComparison.OrdinalIgnoreCase))
                        c.HeaderText = "Profesional";
                    if (string.Equals(key, "Destacado", StringComparison.OrdinalIgnoreCase))
                        c.HeaderText = "Nuevo";
                    c.DisplayIndex = di++;
                    continue;
                }

                var found = _form.dataGridProfesionalesView.Columns.Cast<DataGridViewColumn>()
                    .FirstOrDefault(c => string.Equals(c.DataPropertyName, key, StringComparison.OrdinalIgnoreCase)
                                         || string.Equals(c.HeaderText, key, StringComparison.OrdinalIgnoreCase));
                if (found != null)
                {
                    found.Visible = true;
                    if (string.Equals(key, "Destacado", StringComparison.OrdinalIgnoreCase))
                        found.HeaderText = "Nuevo";
                    found.DisplayIndex = di++;
                }
            }

            // Asegurar que la columna "Destacado" se muestre como checkbox (tildado si true, destildado si false)
            try
            {
                DataGridViewColumn? destCol = null;
                if (_form.dataGridProfesionalesView.Columns.Contains("Destacado"))
                    destCol = _form.dataGridProfesionalesView.Columns["Destacado"];
                else
                    destCol = _form.dataGridProfesionalesView.Columns.Cast<DataGridViewColumn>()
                        .FirstOrDefault(c => string.Equals(c.DataPropertyName, "Destacado", StringComparison.OrdinalIgnoreCase)
                                             || string.Equals(c.HeaderText, "Destacado", StringComparison.OrdinalIgnoreCase));

                if (destCol != null)
                {
                    // Si ya es checkbox, asegurar propiedades y permitir edición directa
                    if (destCol is DataGridViewCheckBoxColumn chkCol)
                    {
                        chkCol.ReadOnly = false; // permitir toggling
                        chkCol.ThreeState = false;
                        chkCol.HeaderText = "Nuevo";
                        chkCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }
                    else
                    {
                        var displayIndex = destCol.DisplayIndex;
                        var visible = destCol.Visible;
                        var dataProp = string.IsNullOrWhiteSpace(destCol.DataPropertyName) ? "Destacado" : destCol.DataPropertyName;
                        // Remover la columna existente y reemplazar por DataGridViewCheckBoxColumn vinculada
                        _form.dataGridProfesionalesView.Columns.Remove(destCol);
                        var newChk = new DataGridViewCheckBoxColumn
                        {
                            Name = "Destacado",
                            HeaderText = "Nuevo",
                            DataPropertyName = dataProp,
                            ReadOnly = false,
                            ThreeState = false,
                            AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                            TrueValue = true,
                            FalseValue = false
                        };
                        _form.dataGridProfesionalesView.Columns.Add(newChk);
                        newChk.DisplayIndex = displayIndex;
                        newChk.Visible = visible;
                    }
                }
            }
            catch
            {
                // Silenciar errores para no romper la UI
            }

            // Permitir que el usuario tilda/destilde el check directamente y propagar al servidor
            try { _form.dataGridProfesionalesView.CurrentCellDirtyStateChanged -= DataGridProfesionalesView_CurrentCellDirtyStateChanged; } catch { }
            _form.dataGridProfesionalesView.CurrentCellDirtyStateChanged += DataGridProfesionalesView_CurrentCellDirtyStateChanged;

            try { _form.dataGridProfesionalesView.CellValueChanged -= DataGridProfesionalesView_DestacadoCellValueChanged; } catch { }
            _form.dataGridProfesionalesView.CellValueChanged += DataGridProfesionalesView_DestacadoCellValueChanged;

            // Formateo de celdas: mostrar "Sin asignar" cuando Especialidad esté vacía
            try { _form.dataGridProfesionalesView.CellFormatting -= DataGridProfesionalesView_CellFormatting; } catch { }
            _form.dataGridProfesionalesView.CellFormatting += DataGridProfesionalesView_CellFormatting;

            // Encabezados en negrita
            try
            {
                var f = _form.dataGridProfesionalesView.ColumnHeadersDefaultCellStyle.Font ?? _form.dataGridProfesionalesView.Font;
                _form.dataGridProfesionalesView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font(f, System.Drawing.FontStyle.Bold);
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

        public void OnAgregar() { }
        public void OnCancelar() { }
        public void OnGuardar() { }
        public void OnModificar() { }
        public void OnEliminar() { }

        private void DataGridProfesionalesView_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                var grid = _form.dataGridProfesionalesView;
                if (grid.Columns[e.ColumnIndex].Name.Equals("Especialidad", StringComparison.OrdinalIgnoreCase))
                {
                    if (e.Value == null || string.IsNullOrWhiteSpace(e.Value.ToString()))
                    {
                        e.Value = "Sin asignar";
                        e.FormattingApplied = true;
                    }
                }
            }
            catch
            {
                // Ignorar cualquier error de formateo para no romper la UI
            }
        }

        private void DataGridProfesionalesView_CurrentCellDirtyStateChanged(object? sender, EventArgs e)
        {
            try
            {
                var grid = _form.dataGridProfesionalesView;
                if (grid.IsCurrentCellDirty)
                {
                    // Commit inmediato para que CellValueChanged se dispare
                    grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
            catch { }
        }

        private async void DataGridProfesionalesView_DestacadoCellValueChanged(object? sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var grid = _form.dataGridProfesionalesView;
                if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

                var col = grid.Columns[e.ColumnIndex];
                if (!string.Equals(col.Name, "Destacado", StringComparison.OrdinalIgnoreCase) && !string.Equals(col.DataPropertyName, "Destacado", StringComparison.OrdinalIgnoreCase))
                    return;

                var row = grid.Rows[e.RowIndex];
                var profesional = row.DataBoundItem as Profesional;
                if (profesional == null)
                    return;

                // Obtener el valor actual del cell (puede ser bool o null)
                object? cellVal = row.Cells[e.ColumnIndex].Value;
                bool nuevoValor = false;
                if (cellVal is bool b) nuevoValor = b;
                else if (cellVal is bool?) nuevoValor = (bool)((bool?)cellVal ?? false);
                else if (cellVal != null)
                {
                    // intentar parsear
                    bool.TryParse(cellVal.ToString(), out nuevoValor);
                }

                // Si no hay cambio, salir
                if (profesional.Destacado == nuevoValor) return;

                profesional.Destacado = nuevoValor;

                // Intentar persistir al servidor. Mostrar mensaje solo en error.
                try
                {
                    await _form.profesionalService.UpdateAsync(profesional);
                }
                catch (Exception ex)
                {
                    // Revertir valor local si falla
                    profesional.Destacado = !nuevoValor;
                    try { row.Cells[e.ColumnIndex].Value = profesional.Destacado; } catch { }
                    MessageBox.Show($"Error al actualizar 'Destacado': {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch { }
        }
    }
}
