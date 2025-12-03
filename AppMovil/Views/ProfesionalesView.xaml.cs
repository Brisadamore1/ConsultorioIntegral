using AppMovil.ViewModels;
using Microsoft.Maui.Controls;

namespace AppMovil.Views;

public partial class ProfesionalesView : ContentPage
{
    public ProfesionalesView()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        var viewmodel = this.BindingContext as ProfesionalesViewModel;
        viewmodel.ObtenerProfesionales();
        viewmodel.SelectedProfessional = null;
    }

    // Maneja el evento SelectionChanged del CollectionView para asegurar que
    // la vista y el ViewModel se mantengan sincronizados inmediatamente.
    private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        try
        {
            var vm = this.BindingContext as ProfesionalesViewModel;
            if (vm == null) return;

            var item = e?.CurrentSelection?.FirstOrDefault() as Service.Models.Profesional;
            vm.SelectedProfessional = item;
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"SelectionChanged handler error: {ex}");
        }
    }
}