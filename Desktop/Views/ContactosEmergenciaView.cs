using Desktop.Interfaces;
using Desktop.States.ContactosEmergencia;
using Service.Interfaces;
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

namespace Desktop.Views
{
    public partial class ContactosEmergenciaView : Form
    {
        //hacer los campos de cada uno de los estados
        public IFormState initialDisplayState;
        public IFormState addState;
        public IFormState editState;
        public IFormState deleteState;

        //estado que respeta esta interfaz
        public IFormState currentState;


        public IGenericService<ContactoEmergencia> contactosEmergenciaService = new GenericService<ContactoEmergencia>();
        public IGenericService<Paciente> pacienteService = new GenericService<Paciente>();

        public BindingSource ListContactosEmergencia = new BindingSource();
        public ContactoEmergencia contactosEmergenciaCurrent;
        public ContactosEmergenciaView()
        {
            InitializeComponent();

            //this es la referencia al formulario pacientes
            initialDisplayState = new InitialDisplayState(this);
            addState = new AddState(this);
            editState = new EditState(this);
            deleteState = new DeleteState(this);

            //inicializamos el estado actual con el estado inicial
            currentState = initialDisplayState;
            currentState.UpdateUI();

            //dataGridProveedoresView.DataSource = ListProveedores;
            //CargarGrilla();
            _ = CargarCombo();
        }

        private async Task CargarCombo()
        {
            comboPacientes.DataSource = await pacienteService.GetAllAsync(string.Empty);
            comboPacientes.DisplayMember = "Nombre";
            comboPacientes.ValueMember = "Id";
            comboPacientes.SelectedIndex = -1;
        }

        public void SetState(IFormState state)
        {
            currentState = state ?? throw new ArgumentNullException(nameof(state), "El estado no puede ser nulo.");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            SetState(addState);
            currentState.OnAgregar();
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            currentState.OnGuardar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            currentState.OnCancelar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            SetState(editState);
            currentState.OnModificar();
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            SetState(deleteState);
            currentState.OnEliminar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            currentState.OnBuscar();
        }

        private void iconButtonSalir_Click(object sender, EventArgs e)
        {
            currentState.OnSalir();
        }
    }
}
