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

namespace Desktop.States.Pacientes
{
    public class InitialDisplayState : IFormState
    {
        private PacientesView _form;
        public InitialDisplayState(PacientesView form)
        {
            _form = form ?? throw new ArgumentNullException(nameof(form), "El formulario no puede ser nulo.");

        }

        private void DataGridPacientesView_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                var grid = _form.dataGridPacientesView;
                if (grid.Columns[e.ColumnIndex].Name.Equals("Email", StringComparison.OrdinalIgnoreCase))
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
                // ignore
            }
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

            // Obtener todos y luego filtrar localmente de forma case-insensitive para búsqueda en vivo
            var all = (await _form.pacienteService.GetAllAsync(string.Empty))?.ToList() ?? new List<Paciente>();


            // Bind all and wire compact live filter (search by terms within Nombre)
            _form.ListPacientes.DataSource = all;
            try { if (_form.txtFiltro.Tag is EventHandler old) _form.txtFiltro.TextChanged -= old; } catch { }
            EventHandler h = (s, e) =>
            {
                var txt = _form.txtFiltro.Text?.Trim();
                if (string.IsNullOrEmpty(txt)) { _form.ListPacientes.DataSource = all; return; }
                var terms = txt.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                _form.ListPacientes.DataSource = all.Where(item => !string.IsNullOrEmpty(item.Nombre) && terms.All(t => item.Nombre.IndexOf(t, StringComparison.OrdinalIgnoreCase) >= 0)).ToList();
            };
            _form.txtFiltro.Tag = h;
            _form.txtFiltro.TextChanged += h;

            _form.dataGridPacientesView.DataSource = _form.ListPacientes;

            // Desactivar la fila de nuevo registro
            _form.dataGridPacientesView.AllowUserToAddRows = false;

            #region Ocultar columnas innecesarias
            if (_form.dataGridPacientesView.Columns.Contains("ProfesionalId"))
                _form.dataGridPacientesView.Columns["ProfesionalId"].Visible = false;
            if (_form.dataGridPacientesView.Columns.Contains("Direccion"))
                _form.dataGridPacientesView.Columns["Direccion"].Visible = false;
            if (_form.dataGridPacientesView.Columns.Contains("EsParticular"))
                _form.dataGridPacientesView.Columns["EsParticular"].Visible = false;
            if (_form.dataGridPacientesView.Columns.Contains("ObraSocial"))
                _form.dataGridPacientesView.Columns["ObraSocial"].Visible = false;
            if (_form.dataGridPacientesView.Columns.Contains("NumeroAfiliado"))
                _form.dataGridPacientesView.Columns["NumeroAfiliado"].Visible = false;
            if (_form.dataGridPacientesView.Columns.Contains("IsDeleted"))
                _form.dataGridPacientesView.Columns["IsDeleted"].Visible = false;
            #endregion

            // Orden deseado: Id, Paciente(Nombre), DNI, FechaNacimiento, Email, Telefono, Profesional
            var keys = new[] { "Id", "Nombre", "Dni", "FechaNacimiento", "Email", "Telefono", "Profesional" };
            int di = 0;
            foreach (var key in keys)
            {
                if (_form.dataGridPacientesView.Columns.Contains(key))
                {
                    var c = _form.dataGridPacientesView.Columns[key];
                    c.Visible = true;
                    if (string.Equals(key, "Nombre", StringComparison.OrdinalIgnoreCase))
                        c.HeaderText = "Paciente";
                    if (string.Equals(key, "FechaNacimiento", StringComparison.OrdinalIgnoreCase))
                        c.HeaderText = "Fecha Nacimiento";
                    c.DisplayIndex = di++;
                    continue;
                }

                var found = _form.dataGridPacientesView.Columns.Cast<DataGridViewColumn>()
                    .FirstOrDefault(c => string.Equals(c.DataPropertyName, key, StringComparison.OrdinalIgnoreCase)
                                         || string.Equals(c.HeaderText, key, StringComparison.OrdinalIgnoreCase));
                if (found != null)
                {
                    found.Visible = true;
                    if (string.Equals(key, "Nombre", StringComparison.OrdinalIgnoreCase))
                        found.HeaderText = "Paciente";
                    if (string.Equals(key, "FechaNacimiento", StringComparison.OrdinalIgnoreCase))
                        found.HeaderText = "Fecha Nacimiento";
                    found.DisplayIndex = di++;
                }
            }

            // Formateo de celdas: mostrar "Sin asignar" cuando Email esté vacío
            try { _form.dataGridPacientesView.CellFormatting -= DataGridPacientesView_CellFormatting; } catch { }
            _form.dataGridPacientesView.CellFormatting += DataGridPacientesView_CellFormatting;

            // Encabezados en negrita
            try
            {
                var f = _form.dataGridPacientesView.ColumnHeadersDefaultCellStyle.Font ?? _form.dataGridPacientesView.Font;
                _form.dataGridPacientesView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font(f, System.Drawing.FontStyle.Bold);
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
        private async Task CargarCombo()
        {
            _form.comboProfesionales.DataSource = await _form.profesionalService.GetAllAsync(string.Empty);
            _form.comboProfesionales.DisplayMember = "Nombre";
            _form.comboProfesionales.ValueMember = "Id";
            _form.comboProfesionales.SelectedIndex = -1;
        }

        public void OnAgregar() { }
        public void OnCancelar() { }
        public void OnGuardar() { }
        public void OnModificar() { }
        public void OnEliminar() { }
    }
}
