using Firebase.Database;
using Firebase.Database.Query;
using GestionAlumnos.Modelos.Modelos;

namespace GestionAlumnos.AppMovil.Vistas;

public partial class CrearAlumno : ContentPage
{
    FirebaseClient client = new FirebaseClient("https://gestiondealumnoseva3-default-rtdb.firebaseio.com/");

    public List<Curso> Curso { get; set; } //Recordatorio => aqui esta el binding (el vinculante del Xaml CrearAlumno)

    public CrearAlumno()
	{
		InitializeComponent();
        ListarAlumnos();
		BindingContext = this;
	}

    private void ListarAlumnos()
    {
        var curso = client.Child("Curso").OnceAsync<Curso>();
        Curso = curso.Result.Select(x=>x.Object).ToList();

    }

    private async void guardarButton_Clicked(object sender, EventArgs e)
    {
		Curso curso = CursoPicker.SelectedItem as Curso;

        var alumno = new Alumno
        {
            PrimerNombre = primerNombreEntry.Text,
            SegundoNombre = segundoNombreEntry.Text,
            PrimerApellido = primerApellidoEntry.Text,
            SegundoApellido = segundoApellidoEntry.Text,
            CorreoElectronico = correoEntry.Text,
            Edad = int.Parse(edadEntry.Text),
            Curso = curso 
        };

        try
        {
            await client.Child("Alumno").PostAsync(alumno);
            await DisplayAlert("Exito", $"El alumno {alumno.PrimerNombre} {alumno.SegundoNombre} {alumno.PrimerApellido} {alumno.SegundoApellido} fue guardado correctamente", "OK");
            await Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
        

        
    }
}