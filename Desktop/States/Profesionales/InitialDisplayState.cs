using Desktop.Interfaces;
using Desktop.Views;
using Desktop.Views;
using Service.Services;
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

        public async Task UpdateUI()
        {
            _form.ListProfesionales.DataSource = await _form.profesionalService.GetAllAsync(_form.txtFiltro.Text);
            _form.dataGridProfesionalesView.DataSource = _form.ListProfesionales;

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
    }
}
