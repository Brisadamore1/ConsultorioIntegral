using Desktop.Interfaces;
using Desktop.Views;
using Service.Services;
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
            _form.ListTurnos.DataSource = await _form.turnoService.GetAllAsync(_form.txtFiltro.Text);
            _form.dataGridTurnosView.DataSource = _form.ListTurnos;

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
