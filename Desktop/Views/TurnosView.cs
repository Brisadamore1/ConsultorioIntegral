using Desktop.Interfaces;
using Service.Interfaces;
using Desktop.States.Turnos;
using Service.Models;
using Service.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Service.Enums;

namespace Desktop.Views
{
    public partial class TurnosView : Form
    {
        //hacer los campos de cada uno de los estados
        public IFormState initialDisplayState;
        public IFormState addState;
        public IFormState editState;
        public IFormState deleteState;

        //estado que respeta esta interfaz
        public IFormState currentState;


        public IGenericService<Turno> turnoService = new GenericService<Turno>();
        public IGenericService<Paciente> pacienteService = new GenericService<Paciente>();
        public IGenericService<Profesional> profesionalService = new GenericService<Profesional>();

        public BindingSource ListTurnos = new BindingSource();
        public Turno turnoCurrent;

        public TurnosView()
        {
            InitializeComponent();
            //this es la referencia al formulario pacientes
            initialDisplayState = new InitialDisplayState(this);
            addState = new AddState(this);
            editState = new EditState(this);
            deleteState = new DeleteState(this);

            //inicializamos el estado actuales con el estado inicial
            currentState = initialDisplayState;
            try
            {
                var initTask = currentState.UpdateUI();
                // Observa errores asincrónicos y muéstralos en UI para evitar que el ShowDialog lance TargetInvocationException
                initTask.ContinueWith(t =>
                {
                    if (t.IsFaulted)
                    {
                        var ex = t.Exception?.GetBaseException();
                        try { MessageBox.Show($"Error inicializando vista Turnos: {ex?.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); } catch { }
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());
            }
            catch (Exception ex)
            {
                try { MessageBox.Show($"Error inicializando vista Turnos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); } catch { }
            }

            //dataGridProveedoresView.DataSource = ListProveedores;
            //CargarGrilla();
            try
            {
                var comboTask = CargarCombo();
                comboTask.ContinueWith(t =>
                {
                    if (t.IsFaulted)
                    {
                        var ex = t.Exception?.GetBaseException();
                        try { MessageBox.Show($"Error cargando combos Turnos: {ex?.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); } catch { }
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());
            }
            catch (Exception ex)
            {
                try { MessageBox.Show($"Error iniciando carga de combos Turnos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); } catch { }
            }
        }

        private async Task CargarCombo()
        {
            comboPacientes.DataSource = await pacienteService.GetAllAsync(string.Empty);
            comboPacientes.DisplayMember = "Nombre";
            comboPacientes.ValueMember = "Id";
            comboPacientes.SelectedIndex = -1;

            comboProfesionales.DataSource = await profesionalService.GetAllAsync(string.Empty);
            comboProfesionales.DisplayMember = "Nombre";
            comboProfesionales.ValueMember = "Id";
            comboProfesionales.SelectedIndex = -1;

            // Poblar el combo de estados con los valores del enum
            comboEstado.DataSource = Enum.GetValues(typeof(EstadoTurnoEnum));
            comboEstado.SelectedIndex = -1;
        }
        public void SetState(IFormState state)
        {
            currentState = state ?? throw new ArgumentNullException(nameof(state), "El estado no puede ser nulo.");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            currentState.OnBuscar();
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            SetState(addState);
            currentState.OnAgregar();
        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            SetState(editState);
            currentState.OnModificar();
        }

        private async void btnEliminar_Click_1(object sender, EventArgs e)
        {
            SetState(deleteState);
            currentState.OnEliminar();
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            currentState.OnSalir();
        }

        private async void btnGuardar_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (comboEstado.SelectedItem is Service.Enums.EstadoTurnoEnum estado)
                {
                    turnoCurrent.EstadoTurno = estado;
                }
            }
            catch { }

            currentState.OnGuardar();
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            currentState.OnCancelar();
        }
    }
}
