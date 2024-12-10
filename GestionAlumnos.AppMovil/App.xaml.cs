using GestionAlumnos.AppMovil.Vistas;

namespace GestionAlumnos.AppMovil
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ListarAlumnos());
        }
    }
}
