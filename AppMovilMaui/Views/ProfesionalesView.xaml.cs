using AppMovil.ViewModels;
using Microsoft.Maui.Controls;

namespace AppMovil.Views;

public partial class ProfesionalesView : ContentPage
{
    public ProfesionalesView()
    {
        InitializeComponent();
        //BindingContext = new ProfesionalesViewModel();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        var viewmodel = this.BindingContext as ProfesionalesViewModel;
        viewmodel.ObtenerProfesionales();
        viewmodel.SelectedProfessional = null;
    }
}