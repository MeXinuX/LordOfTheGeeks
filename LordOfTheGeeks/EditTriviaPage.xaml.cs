using LordOfTheGeeks.Models;
using LordOfTheGeeks.Services;
using Microsoft.Maui.Controls;

namespace LordOfTheGeeks
{
    public partial class EditTriviaPage : ContentPage
    {
        private readonly DatabaseService _databaseService;

        public EditTriviaPage(DatabaseService databaseService)
        {
            InitializeComponent();
            _databaseService = databaseService;
            LoadTrivias();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadTrivias(); // Recargar al volver
        }

        private async void LoadTrivias()
        {
            var trivias = await _databaseService.ObtenerTodasLasTrivias();
            TriviasList.ItemsSource = trivias;
        }

        private async void OnModifyClicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.CommandParameter is Trivia trivia)
            {
                await Navigation.PushAsync(new EditSingleTriviaPage(_databaseService, trivia));
            }
        }
    }
}