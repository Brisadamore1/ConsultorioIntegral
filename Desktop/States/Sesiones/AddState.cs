using Desktop.Interfaces;
using Desktop.Views;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.States.Sesiones
{
    public class AddState : IFormState
    {
        private SesionesView _form;

        public AddState(SesionesView form)
        {
            _form = form ?? throw new ArgumentNullException(nameof(form), "El formulario no puede ser nulo.");

        }
       
        public void OnCancelar()
        {
            // Limpiar campos de Sesión cuando se cancela
            _form.comboTurnos.SelectedIndex = -1;
            _form.numericHonorario.Value = 0;
            _form.checkBoxPagado.Checked = false;
            _form.txtNotas.Clear();

            _form.SetState(_form.initialDisplayState);
            _form.currentState.UpdateUI();
        }


        public async void OnGuardar()
        {
            if (_form.comboTurnos.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un turno atendido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var sesion = new Sesion
            {
                TurnoId = (int)_form.comboTurnos.SelectedValue,
                Honorarios = _form.numericHonorario.Value,
                Pagado = _form.checkBoxPagado.Checked,
                Notas = _form.txtNotas.Text
            };

            await _form.sesionService.AddAsync(sesion);
            _form.SetState(_form.initialDisplayState);
            await _form.currentState.UpdateUI();

        }

        public Task UpdateUI()
        {
            _form.comboTurnos.SelectedIndex = -1;
            _form.numericHonorario.Value = 0;
            _form.checkBoxPagado.Checked = false;
            _form.txtNotas.Clear();
            _form.tabControl1.SelectTab(_form.tabPageAgregarEditar);
            return Task.CompletedTask;

        }
        public void OnAgregar()
        {
            UpdateUI();
        }
        public void OnSalir() { }
        public void OnModificar() { }
        public void OnEliminar() { }
        public void OnBuscar() { }
    }
}
