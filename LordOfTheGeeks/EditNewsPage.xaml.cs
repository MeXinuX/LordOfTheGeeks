using LordOfTheGeeks.Models;
using LordOfTheGeeks.Services;
using Microsoft.Maui.Controls;

namespace LordOfTheGeeks
{
    public partial class EditNewsPage : ContentPage
    {
        private readonly DatabaseService _databaseService;

        public EditNewsPage(DatabaseService databaseService)
        {
            InitializeComponent();
            _databaseService = databaseService;
            LoadNews();
        }

        private async void LoadNews()
        {
            var noticias = await _databaseService.ObtenerTodasLasNoticias();
            NewsList.ItemsSource = noticias;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadNews(); // Esto se ejecutará al volver de EditSingleNewsPage
        }

        private async void OnModifyClicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.CommandParameter is Noticia noticia)
            {
                await Navigation.PushAsync(new EditSingleNewsPage(_databaseService, noticia));
            }
        }


    }
}