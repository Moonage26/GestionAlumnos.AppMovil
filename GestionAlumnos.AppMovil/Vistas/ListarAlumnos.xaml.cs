using System.Collections.ObjectModel;
using Firebase.Database;
using GestionAlumnos.Modelos.Modelos;

namespace GestionAlumnos.AppMovil.Vistas;

public partial class ListarAlumnos : ContentPage
{
    FirebaseClient client = new FirebaseClient("https://gestiondealumnoseva3-default-rtdb.firebaseio.com/");
    public ObservableCollection<Alumno> Lista { get; set; } = new ObservableCollection<Alumno>();
    public ListarAlumnos()
	{
		InitializeComponent();
        BindingContext = this;
        CargarLista();
    }

    private void CargarLista()
    {
        client.Child("Alumno").AsObservable<Alumno>().Subscribe((alumno) =>
        {
            if (alumno != null)
            {
                Lista.Add(alumno.Object);
            }
        });
    }

    private void FiltroSearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        string filtro = FiltroSearchBar.Text.ToLower();

        if (filtro.Length > 0)
        {
            ListaCollection.ItemsSource = Lista.Where(x => x.NombreCompleto.ToLower().Contains(filtro));
        }
        else
        {
            ListaCollection.ItemsSource = Lista;
        }
    }

    private async void NuevoAlumnoBoton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CrearAlumno());

    }
}