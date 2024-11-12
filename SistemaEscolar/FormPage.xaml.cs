using System.Text;
using System.Text.Json;

namespace SistemaEscolar;

public partial class FormPage : ContentPage
{
	public FormPage()
	{
		InitializeComponent();
	}

    private async void btnGuardar(object sender, EventArgs e)
    {
        string nombre = EntryNombre.Text;
        string apellido = EntryApellido.Text;

        string sexo = "";

        if (RadioButtonH.IsChecked == true)
            sexo = "h";
        else if (RadioButtonM.IsChecked == true)
            sexo = "m";
        else if (RadioButtonO.IsChecked == true)
            sexo = "o";


        DateTime fechaNac = fh_nac.Date;

        string rol = pckRol.SelectedItem?.ToString();
        int idRol = rol switch
        {
            "Alumno" => 1,
            "Profesor" => 2,
            "Administrativo" => 3,
            "Otro" => 4,
            _ => 0
        };

        var nuevaPersona = new PersonaModel
        {
            id = 0,
            nombre = nombre,
            apellido = apellido,
            sexo = sexo,
            fh_nac = fechaNac,
            id_rol = idRol
        };

        await GuardarPersona (nuevaPersona);
    }

    private readonly HttpClient _httpClient = new HttpClient();

    private async Task GuardarPersona(PersonaModel persona)
    {
        try
        {
            // Serializar el objeto persona a JSON
            var json = JsonSerializer.Serialize(persona);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Enviar la solicitud POST a la API
            var response = await _httpClient.PostAsync("https://fi.jcaguilar.dev/v1/escuela/persona", content);

            if (response.IsSuccessStatusCode)
            {
                await DisplayAlert("Éxito", "Persona guardada correctamente", "OK");
            }
            else
            {
                await DisplayAlert("Error", "No se pudo guardar la persona", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Hubo un problema al guardar la persona: {ex.Message}", "OK");
        }
    }

    private async void btnRegresar(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }
}