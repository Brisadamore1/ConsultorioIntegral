//using Java.Time;
using AppMovil.ViewModels;
using Microsoft.Maui.Controls;
using Service.Models;

namespace AppMovil.Views;

[QueryProperty(nameof(Professional), "ProfessionalToEdit")]
public partial class AddEditProfesionalView : ContentPage
{
    public Profesional Professional
    {
        set
        {
            var profesional = value;
            var viewmodel = this.BindingContext as AddEditProfesionalViewModel;
            viewmodel.EditProfessional = profesional;
        }
    }
    //nuevo
    public AddEditProfesionalView()
	{
		InitializeComponent();
	}
    //editar
    //public AddEditProductoView(Producto producto)
    //{
    //    InitializeComponent();
    //    //asigno al viewmodel el producto que me pasan
    //    var viewmodel = this.BindingContext as AddEditProductoViewModel;
    //    viewmodel.EditProduct = producto;
    //}
}