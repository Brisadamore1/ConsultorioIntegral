using AppMovil.ViewModels;

namespace AppMovil.Views;

public partial class ProfesionalesDestacadosView : ContentPage
{
    public ProfesionalesDestacadosView()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        try
        {
            if (BindingContext is ProfesionalesDestacadosViewModel vm)
            {
                await vm.ObtenerProfesionales();
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"No se pudieron cargar los profesionales destacados: {ex.Message}", "OK");
        }
    }
}