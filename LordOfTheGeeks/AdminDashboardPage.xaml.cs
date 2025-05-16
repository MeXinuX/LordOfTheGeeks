using LordOfTheGeeks.Services;
using Microsoft.Maui.Controls;

namespace LordOfTheGeeks
{
    public partial class AdminDashboardPage : ContentPage
    {
        private readonly DatabaseService _databaseService;

        public AdminDashboardPage(DatabaseService databaseService)
        {
            InitializeComponent();
            _databaseService = databaseService;
        }

        private async void OnCreateNewsClicked(object sender, EventArgs e)
        {
            // M�todo correcto usando inyecci�n de dependencias
            var createNewsPage = Handler.MauiContext.Services.GetRequiredService<CreateNewsPage>();
            await Navigation.PushAsync(createNewsPage);
        }
        private async void OnEditNewsClicked(object sender, EventArgs e)
        {
            var editPage = Handler.MauiContext.Services.GetRequiredService<EditNewsPage>();
            await Navigation.PushAsync(editPage);
            // (Y a�adir�s la l�gica para pasar la noticia a editar)
        }
        private async void OnDeleteNewsClicked(object sender, EventArgs e)
        {
            // L�gica que quieras ejecutar al presionar el bot�n de eliminar noticias.
            // Por ahora puedes dejarlo vac�o para que compile.
            var deletePage = Handler.MauiContext.Services.GetRequiredService<DeleteNewsPage>();
            await Navigation.PushAsync(deletePage);
        }

        private async void OnCreateTriviaClicked(object sender, EventArgs e)
        {
            // Aqu� puedes poner la l�gica para navegar o crear una trivia
            // Por ejemplo, si tienes una p�gina llamada CreateTriviaPage:
            var triviaPage = Handler.MauiContext.Services.GetRequiredService<CreateTriviaPage>();
            await Navigation.PushAsync(triviaPage);
        }

        private async void OnEditTriviaClicked(object sender, EventArgs e)
        {
            // Suponiendo que tengas una p�gina llamada EditTriviaPage registrada
            var editTriviaPage = Handler.MauiContext.Services.GetRequiredService<EditTriviaPage>();
            await Navigation.PushAsync(editTriviaPage);

            // Aqu� puedes agregar l�gica adicional para seleccionar o editar una trivia espec�fica
        }


        private async void OnDeleteTriviaClicked(object sender, EventArgs e)
        {
            // Aqu� puedes implementar l�gica para eliminar una trivia
            // Por ahora, puede estar vac�o si solo quieres compilar
            // M�s adelante puedes mostrar una alerta de confirmaci�n o eliminar desde la base de datos
            var deleteTriviaPage = Handler.MauiContext.Services.GetRequiredService<DeleteTriviaPage>();
            await Navigation.PushAsync(deleteTriviaPage);
        }


    }
}