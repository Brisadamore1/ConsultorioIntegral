using Desktop.Interfaces;
using Desktop.Views;
using Service.Services;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.States.ContactosEmergencia
{
    public class InitialDisplayState : IFormState
    {
        private ContactosEmergenciaView _form;
        private bool _columnsConfigured = false;
        public InitialDisplayState(ContactosEmergenciaView form)
        {
            _form = form ?? throw new ArgumentNullException(nameof(form), "El formulario no puede ser nulo.");

            // Registrar el handler una sola vez para evitar acumulación
            _form.tabControl1.Selecting -= TabControl1_Selecting;
            _form.tabControl1.Selecting += TabControl1_Selecting;

        }
        public async void OnBuscar()
        {
            await UpdateUI();
        }

        public void OnSalir()
        {
            _form.Close();
        }

        private void TabControl1_Selecting(object? sender, TabControlCancelEventArgs e)
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
        }

        private void TryEnableDoubleBuffer(DataGridView dgv)
        {
            try
            {
                // Habilitar DoubleBuffered usando reflection porque la propiedad es protegida
                typeof(DataGridView).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic)
                    ?.SetValue(dgv, true, null);
            }
            catch { }
        }

        public async Task UpdateUI()
        {
            await CargarCombo();
            // Obtener todos y luego filtrar localmente de forma case-insensitive para búsqueda en vivo
            var all = (await _form.contactosEmergenciaService.GetAllAsync(string.Empty))?.ToList() ?? new List<ContactoEmergencia>();
            var filter = _form.txtFiltro.Text?.Trim();
            var f = filter;

            // Evitar reasignar el DataSource del BindingSource para no forzar la recreación de columnas
            var bs = _form.ListContactosEmergencia;
            var dgv = _form.dataGridContactosEmergenciaView;
            // Activar double buffering en DataGridView para reducir parpadeo visual
            TryEnableDoubleBuffer(dgv);
            // Suspender layout del DataGridView durante la actualización en sitio para evitar repintados de encabezados
            dgv.SuspendLayout();
            try { bs.SuspendBinding(); } catch { }

            var filtered = string.IsNullOrEmpty(f)
                ? all
                : all.Where(item =>
                    (!string.IsNullOrEmpty(item.Nombre) && item.Nombre.IndexOf(f, StringComparison.OrdinalIgnoreCase) >= 0)
                    || (item.Paciente != null && item.Paciente.ToString().IndexOf(f, StringComparison.OrdinalIgnoreCase) >= 0)
                    || item.Id.ToString().IndexOf(f, StringComparison.OrdinalIgnoreCase) >= 0
                ).ToList();

            if (bs.DataSource is System.Collections.IList existingList)
            {
                // Actualizar en sitio la lista para evitar que el DataGridView regenere columnas/encabezados
                existingList.Clear();
                foreach (var it in filtered)
                {
                    existingList.Add(it);
                }
                bs.ResetBindings(false);
            }
            else
            {
                bs.DataSource = filtered;
                _form.dataGridContactosEmergenciaView.DataSource = bs;
            }

            try { bs.ResumeBinding(); } catch { }
            finally
            {
                // Restaurar layout para que el control repinte una sola vez
                try { dgv.ResumeLayout(); } catch { }
            }

            // Configurar visibilidad/orden de columnas solo la primera vez para evitar cambios que provoquen parpadeo
            if (!_columnsConfigured)
            {
                if (_form.dataGridContactosEmergenciaView.Columns.Contains("PacienteId"))
                    _form.dataGridContactosEmergenciaView.Columns["PacienteId"].Visible = false;
                if (_form.dataGridContactosEmergenciaView.Columns.Contains("IsDeleted"))
                    _form.dataGridContactosEmergenciaView.Columns["IsDeleted"].Visible = false;

                var keys = new[] { "Id", "Nombre", "Relacion", "Paciente", "Telefono" };
                int di = 0;
                foreach (var key in keys)
                {
                    var found = _form.dataGridContactosEmergenciaView.Columns.Cast<DataGridViewColumn>()
                        .FirstOrDefault(c => string.Equals(c.DataPropertyName, key, StringComparison.OrdinalIgnoreCase)
                                             || string.Equals(c.HeaderText, key, StringComparison.OrdinalIgnoreCase)
                                             || string.Equals(c.Name, key, StringComparison.OrdinalIgnoreCase));
                    if (found != null)
                    {
                        found.Visible = true;
                        if (string.Equals(key, "Nombre", StringComparison.OrdinalIgnoreCase))
                            found.HeaderText = "Contacto";
                        found.DisplayIndex = di++;
                    }
                }

                _columnsConfigured = true;
            }

            // Desactivar la fila de nuevo registro
            _form.dataGridContactosEmergenciaView.AllowUserToAddRows = false;

            // Encabezados en negrita
            try
            {
                var hdrFont = _form.dataGridContactosEmergenciaView.ColumnHeadersDefaultCellStyle.Font ?? _form.dataGridContactosEmergenciaView.Font;
                _form.dataGridContactosEmergenciaView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font(hdrFont, System.Drawing.FontStyle.Bold);
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