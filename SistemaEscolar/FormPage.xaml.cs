namespace SistemaEscolar;

public partial class FormPage : ContentPage
{
	public FormPage()
	{
		InitializeComponent();
	}

    private void btnGuardar(object sender, EventArgs e)
    {

    }
    private async void btnRegresar(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }
}