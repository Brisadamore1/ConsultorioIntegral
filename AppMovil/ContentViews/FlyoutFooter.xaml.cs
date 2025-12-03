namespace AppMovil.ContentViews;

public partial class FlyoutFooter : ContentView
{
	public FlyoutFooter()
	{
		InitializeComponent();
        try
        {
            lblFecha.Text = DateTime.Now.ToString("dd MMMM yyyy");
        }
        catch
        {
            // Silenciar cualquier problema menor para evitar detener InitializeComponent en plataformas específicas
        }
	}
}