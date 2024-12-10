using Firebase.Database;
using Microsoft.Extensions.Logging;
using GestionAlumnos.Modelos.Modelos;
using Firebase.Database.Query;

namespace GestionAlumnos.AppMovil
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            Registrar();
            return builder.Build();
        }
        public static void Registrar()
        {
            FirebaseClient client = new FirebaseClient("https://gestiondealumnoseva3-default-rtdb.firebaseio.com/");

            var curso = client.Child("Curso").OnceAsync<Curso>();

            if (curso.Result.Count == 0)
            {
                client.Child("Curso").PostAsync(new Curso { Nombre = "Primero Basico" });
                client.Child("Curso").PostAsync(new Curso { Nombre = "Segundo Basico" });
                client.Child("Curso").PostAsync(new Curso { Nombre = "Tercero Basico" });
                client.Child("Curso").PostAsync(new Curso { Nombre = "Cuarto Basico" });
                client.Child("Curso").PostAsync(new Curso { Nombre = "Quinto Basico" });
                client.Child("Curso").PostAsync(new Curso { Nombre = "Sexto Basico" });
                client.Child("Curso").PostAsync(new Curso { Nombre = "Septimo Basico" });
                client.Child("Curso").PostAsync(new Curso { Nombre = "Octavo Basico" });
                client.Child("Curso").PostAsync(new Curso { Nombre = "Primero Medio" });
                client.Child("Curso").PostAsync(new Curso { Nombre = "Segundo Medio" });
                client.Child("Curso").PostAsync(new Curso { Nombre = "Tercero Medio" });
                client.Child("Curso").PostAsync(new Curso { Nombre = "Cuarto Medio" });
            }
        }
    }
}
