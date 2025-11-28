using System.Threading.Tasks;

namespace APIRESTFULL.Views;

public partial class PageCreatePerson : ContentPage
{
    public PageCreatePerson()
    {
        InitializeComponent();
    }

    private void btnfoto_Clicked(object sender, EventArgs e)
    {

    }

    private async void btnproceso_Clicked(object sender, EventArgs e)
    {
        var persona = new Models.Personas
        {
            nombres = Nombres.Text,
            apellidos = Apellidos.Text,
            direccion = Direccion.Text,
            telefono = Telefono.Text,
            foto = "no image"

        };
        if (await Controllers.PersonasController.CreatePerson(persona) != null)
        {
            await DisplayAlert("Mensaje", "Registro Ingresado con Exito", "OK");
        }
        else
        {
            await DisplayAlert("Mensaje", "Error al Ingresar el Registro", "OK");
        }
    }
}