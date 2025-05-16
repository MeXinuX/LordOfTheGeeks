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
            // Método correcto usando inyección de dependencias
            var createNewsPage = Handler.MauiContext.Services.GetRequiredService<CreateNewsPage>();
            await Navigation.PushAsync(createNewsPage);
        }
        private async void OnEditNewsClicked(object sender, EventArgs e)
        {
            var editPage = Handler.MauiContext.Services.GetRequiredService<EditNewsPage>();
            await Navigation.PushAsync(editPage);
            // (Y añadirás la lógica para pasar la noticia a editar)
        }
        private async void OnDeleteNewsClicked(object sender, EventArgs e)
        {
            // Lógica que quieras ejecutar al presionar el botón de eliminar noticias.
            // Por ahora puedes dejarlo vacío para que compile.
            var deletePage = Handler.MauiContext.Services.GetRequiredService<DeleteNewsPage>();
            await Navigation.PushAsync(deletePage);
        }

        private async void OnCreateTriviaClicked(object sender, EventArgs e)
        {
            // Aquí puedes poner la lógica para navegar o crear una trivia
            // Por ejemplo, si tienes una página llamada CreateTriviaPage:
            var triviaPage = Handler.MauiContext.Services.GetRequiredService<CreateTriviaPage>();
            await Navigation.PushAsync(triviaPage);
        }

        private async void OnEditTriviaClicked(object sender, EventArgs e)
        {
            // Suponiendo que tengas una página llamada EditTriviaPage registrada
            var editTriviaPage = Handler.MauiContext.Services.GetRequiredService<EditTriviaPage>();
            await Navigation.PushAsync(editTriviaPage);

            // Aquí puedes agregar lógica adicional para seleccionar o editar una trivia específica
        }


        private async void OnDeleteTriviaClicked(object sender, EventArgs e)
        {
            // Aquí puedes implementar lógica para eliminar una trivia
            // Por ahora, puede estar vacío si solo quieres compilar
            // Más adelante puedes mostrar una alerta de confirmación o eliminar desde la base de datos
            var deleteTriviaPage = Handler.MauiContext.Services.GetRequiredService<DeleteTriviaPage>();
            await Navigation.PushAsync(deleteTriviaPage);
        }


    }
}