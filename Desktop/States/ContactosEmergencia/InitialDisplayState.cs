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

namespace Desktop.States.ContactosEmergencia
{
    public class InitialDisplayState : IFormState
    {
        private ContactosEmergenciaView _form;
        public InitialDisplayState(ContactosEmergenciaView form)
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
            // Obtener todos y luego filtrar localmente de forma case-insensitive para búsqueda en vivo
            var all = (await _form.contactosEmergenciaService.GetAllAsync(string.Empty))?.ToList() ?? new List<ContactoEmergencia>();
            var filter = _form.txtFiltro.Text?.Trim();
            if (!string.IsNullOrEmpty(filter))
            {
                var f = filter;
                var filtered = all.Where(item =>
                    (!string.IsNullOrEmpty(item.Nombre) && item.Nombre.IndexOf(f, StringComparison.OrdinalIgnoreCase) >= 0)
                    || (!string.IsNullOrEmpty(item.Relacion) && item.Relacion.IndexOf(f, StringComparison.OrdinalIgnoreCase) >= 0)
                    || (item.Paciente != null && item.Paciente.ToString().IndexOf(f, StringComparison.OrdinalIgnoreCase) >= 0)
                    || (!string.IsNullOrEmpty(item.Telefono) && item.Telefono.IndexOf(f, StringComparison.OrdinalIgnoreCase) >= 0)
                    || item.Id.ToString().IndexOf(f, StringComparison.OrdinalIgnoreCase) >= 0
                ).ToList();

                _form.ListContactosEmergencia.DataSource = filtered;
            }
            else
            {
                _form.ListContactosEmergencia.DataSource = all;
            }
            _form.dataGridContactosEmergenciaView.DataSource = _form.ListContactosEmergencia;

            // Ocultar columnas innecesarias
            if (_form.dataGridContactosEmergenciaView.Columns.Contains("PacienteId"))
                _form.dataGridContactosEmergenciaView.Columns["PacienteId"].Visible = false;
            if (_form.dataGridContactosEmergenciaView.Columns.Contains("IsDeleted"))
                _form.dataGridContactosEmergenciaView.Columns["IsDeleted"].Visible = false;

            // Orden simple y directo: Id, Nombre(Contacto), Relacion, Paciente, Telefono
            var keys = new[] { "Id", "Nombre", "Relacion", "Paciente", "Telefono" };
            int di = 0;
            foreach (var key in keys)
            {
                if (_form.dataGridContactosEmergenciaView.Columns.Contains(key))
                {
                    var c = _form.dataGridContactosEmergenciaView.Columns[key];
                    c.Visible = true;
                    if (string.Equals(key, "Nombre", StringComparison.OrdinalIgnoreCase))
                        c.HeaderText = "Contacto";
                    c.DisplayIndex = di++;
                    continue;
                }

                var found = _form.dataGridContactosEmergenciaView.Columns.Cast<DataGridViewColumn>()
                    .FirstOrDefault(c => string.Equals(c.DataPropertyName, key, StringComparison.OrdinalIgnoreCase)
                                         || string.Equals(c.HeaderText, key, StringComparison.OrdinalIgnoreCase));
                if (found != null)
                {
                    found.Visible = true;
                    if (string.Equals(key, "Nombre", StringComparison.OrdinalIgnoreCase))
                        found.HeaderText = "Contacto";
                    found.DisplayIndex = di++;
                }
            }

            // Desactivar la fila de nuevo registro
            _form.dataGridContactosEmergenciaView.AllowUserToAddRows = false;

            // Encabezados en negrita
            try
            {
                var f = _form.dataGridContactosEmergenciaView.ColumnHeadersDefaultCellStyle.Font ?? _form.dataGridContactosEmergenciaView.Font;
                _form.dataGridContactosEmergenciaView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font(f, System.Drawing.FontStyle.Bold);
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
            _form.comboPacientes.DataSource = await _form.pacienteService.GetAllAsync(string.Empty);
            _form.comboPacientes.DisplayMember = "Nombre";
            _form.comboPacientes.ValueMember = "Id";
            _form.comboPacientes.SelectedIndex = -1;
        }

        public void OnAgregar() { }
        public void OnCancelar() { }
        public void OnGuardar() { }
        public void OnModificar() { }
        public void OnEliminar() { }
    }
}
