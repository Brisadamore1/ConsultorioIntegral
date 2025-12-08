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
            _form.dataGridTurnosView.DataSource = _form.ListTurnos;

            // Ocultar columnas innecesarias
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
