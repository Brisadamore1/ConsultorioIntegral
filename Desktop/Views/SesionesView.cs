using Desktop.Interfaces;
using Service.Enums;
using Service.Interfaces;
using Desktop.States.Sesiones;
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
    public partial class SesionesView : Form
    {
        //hacer los campos de cada uno de los estados
        public IFormState initialDisplayState;
        public IFormState addState;
        public IFormState editState;
        public IFormState deleteState;

        //estado que respeta esta interfaz
        public IFormState currentState;

        public IGenericService<Sesion> sesionService = new GenericService<Sesion>();
        public IGenericService<Turno> turnoService = new GenericService<Turno>();

        public BindingSource ListSesiones = new BindingSource();
        public Sesion sesionCurrent;

        public SesionesView()
        {
            InitializeComponent();
            //this es la referencia al formulario pacientes
            initialDisplayState = new InitialDisplayState(this);
            addState = new AddState(this);
            editState = new EditState(this);
            deleteState = new DeleteState(this);

            //inicializamos el estado actuales con el estado inicial
            currentState = initialDisplayState;
            currentState.UpdateUI();
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            currentState.OnSalir();
        }
    }
}
