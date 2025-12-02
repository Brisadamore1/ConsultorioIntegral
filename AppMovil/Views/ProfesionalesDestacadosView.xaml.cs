using AppMovil.ViewModels;

namespace AppMovil.Views;

public partial class ProfesionalesDestacadosView : ContentPage
{
    public ProfesionalesDestacadosView()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        var viewmodel = this.BindingContext as ProfesionalesDestacadosViewModel;
        viewmodel.ObtenerProfesionales();
    }
}