using AppMovil.ViewModels;

namespace AppMovil.Views;

public partial class ProfesionalesView : ContentPage
{
    public ProfesionalesView()
    {
        InitializeComponent();
        BindingContext = new ProfesionalesViewModel();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is ProfesionalesViewModel vm)
        {
            vm.ObtenerProfesionalesCommand.Execute(null);
        }
    }
}