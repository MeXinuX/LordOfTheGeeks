using Microsoft.Maui.Controls;
using LordOfTheGeeks.Models;
using LordOfTheGeeks.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LordOfTheGeeks
{
    public partial class TriviaPage : ContentPage
    {
        private readonly DatabaseService _databaseService;
        private Trivia _currentTrivia;
        private Usuario _currentUser;
        private bool _isSidebarVisible = true;
        private Random _random = new Random();
        private bool _answerLocked = false;

        public TriviaPage(DatabaseService databaseService)
        {
            InitializeComponent();
            _databaseService = databaseService;
            _currentUser = App.CurrentUser;
            LoadCategories();
        }

        private void OnToggleSidebarClicked(object sender, EventArgs e)
        {
            _isSidebarVisible = !_isSidebarVisible;
            SidebarColumn.Width = _isSidebarVisible ? 250 : 0;
            ToggleSidebarButton.Text = _isSidebarVisible ? "≡" : "»";
        }

        private async void LoadCategories()
        {
            var categorias = await _databaseService.ObtenerCategoriasTrivia();
            CategoryPicker.ItemsSource = categorias;
        }

        private async void OnGenerateTrivia(object sender, EventArgs e)
        {
            if (CategoryPicker.SelectedItem == null)
            {
                await DisplayAlert("Error", "Selecciona una categoría primero", "OK");
                return;
            }

            _answerLocked = false;
            ResultLabel.IsVisible = false;
            var categoria = CategoryPicker.SelectedItem.ToString();
            await LoadRandomTrivia(categoria);
        }

        private async Task LoadRandomTrivia(string categoria)
        {
            _currentTrivia = await _databaseService.ObtenerTriviaAleatoria(categoria);

            if (_currentTrivia == null)
            {
                await DisplayAlert("Error", "No hay trivias en esta categoría", "OK");
                return;
            }

            UpdateUIWithTrivia();
        }

        private void UpdateUIWithTrivia()
        {
            QuestionLabel.Text = _currentTrivia.Pregunta;
            AnswersLayout.Children.Clear();

            var opciones = new List<string>
            {
                _currentTrivia.OpcionA,
                _currentTrivia.OpcionB,
                _currentTrivia.OpcionC
            };

            var opcionesMezcladas = opciones.OrderBy(x => _random.Next()).ToList();

            foreach (var opcion in opcionesMezcladas)
            {
                var btn = new Button
                {
                    Text = opcion,
                    BackgroundColor = Color.FromArgb("#2C3E50"),
                    TextColor = Colors.White,
                    CornerRadius = 10,
                    Margin = new Thickness(0, 5)
                };
                btn.Clicked += OnAnswerSelected;
                AnswersLayout.Children.Add(btn);
            }
        }

        private async void OnAnswerSelected(object sender, EventArgs e)
        {
            if (_answerLocked) return;
            _answerLocked = true;

            var selectedButton = (Button)sender;
            var respuesta = selectedButton.Text;

            foreach (var child in AnswersLayout.Children)
            {
                if (child is Button button)
                {
                    button.IsEnabled = false;
                }
            }

            if (respuesta == _currentTrivia.OpcionCorrecta)
            {
                selectedButton.BackgroundColor = Colors.Green;
                ResultLabel.Text = "✅ Respuesta Correcta! +10 XP";
                await _databaseService.AumentarXPUsuario(_currentUser.Id, 10);
            }
            else
            {
                selectedButton.BackgroundColor = Colors.Red;

                var correctButton = AnswersLayout.Children
                    .OfType<Button>()
                    .FirstOrDefault(b => b.Text == _currentTrivia.OpcionCorrecta);

                if (correctButton != null)
                {
                    correctButton.BackgroundColor = Colors.Green;
                }

                ResultLabel.Text = $"❌ Respuesta Incorrecta";
            }

            ResultLabel.IsVisible = true;

            // Ya no se carga otra trivia automáticamente
            // El usuario deberá presionar "Generar Trivia" para continuar
        }

        private async void OnNewsClicked(object sender, EventArgs e)
            => await Navigation.PushAsync(new NewsPage(_databaseService));

        private async void OnRankingClicked(object sender, EventArgs e)
            => await Navigation.PushAsync(new RankingPage(_databaseService));
    }
}
