using AppMovil.ViewModels;
using Microsoft.Maui.Controls;

namespace AppMovil.Views;

public partial class PerfilView : ContentPage
{
    private readonly PerfilViewModel viewModel;

    public PerfilView(int pacienteId)
    {
        InitializeComponent();
        viewModel = new PerfilViewModel();
        BindingContext = viewModel;

        // Cuando la vista termina de cargarse, recién ahí traemos los datos
        Loaded += async (s, e) =>
        {
            await viewModel.CargarPacienteAsync(pacienteId);
        };
    }
}