using LordOfTheGeeks.Models;
using LordOfTheGeeks.Services;
using Microsoft.Maui.Controls;
using System.Diagnostics;

namespace LordOfTheGeeks
{
    public partial class EditSingleTriviaPage : ContentPage
    {
        private readonly DatabaseService _databaseService;
        private readonly Trivia _triviaOriginal;
        private readonly List<string> _sagasDisponibles = new List<string>
        {
            "Películas",
            "Videojuegos",
            "Series",
            "Cómics",
            "Tecnología"
        };

        public EditSingleTriviaPage(DatabaseService databaseService, Trivia trivia)
        {
            InitializeComponent();
            _databaseService = databaseService;
            _triviaOriginal = trivia;
            CargarDatosExistentes();

            // Ocultar el campo de la cuarta respuesta
        }

        private void CargarDatosExistentes()
        {
            // Configurar sagas
            SagaPicker.ItemsSource = _sagasDisponibles;
            SagaPicker.SelectedItem = _triviaOriginal.Saga;

            // Llenar campos con solo 3 respuestas
            QuestionEditor.Text = _triviaOriginal.Pregunta;
            CorrectAnswerEntry.Text = _triviaOriginal.OpcionCorrecta;
            WrongAnswer1Entry.Text = _triviaOriginal.OpcionA;
            WrongAnswer2Entry.Text = _triviaOriginal.OpcionB;
            WrongAnswer2Entry.Text = _triviaOriginal.OpcionC;
        }

        private async void OnSaveChangesClicked(object sender, EventArgs e)
        {
            try
            {
                // Validaciones (solo para 3 respuestas)
                if (SagaPicker.SelectedItem == null ||
                    string.IsNullOrWhiteSpace(QuestionEditor.Text) ||
                    string.IsNullOrWhiteSpace(CorrectAnswerEntry.Text) ||
                    string.IsNullOrWhiteSpace(WrongAnswer1Entry.Text) ||
                    string.IsNullOrWhiteSpace(WrongAnswer2Entry.Text)) 
                {
                    await DisplayAlert("Error", "Complete todos los campos obligatorios", "OK");
                    return;
                }

                // Actualizar objeto (sin OpcionD)
                _triviaOriginal.Saga = SagaPicker.SelectedItem.ToString();
                _triviaOriginal.Pregunta = QuestionEditor.Text;
                _triviaOriginal.OpcionA = CorrectAnswerEntry.Text;
                _triviaOriginal.OpcionB = WrongAnswer1Entry.Text;
                _triviaOriginal.OpcionC = WrongAnswer2Entry.Text;

                // Si existe OpcionD en el modelo, la establecemos como null o string.Empty
                if (_triviaOriginal.GetType().GetProperty("OpcionD") != null)
                {
                    _triviaOriginal.GetType().GetProperty("OpcionD")?.SetValue(_triviaOriginal, null);
                }

                // Guardar cambios
                bool exito = await _databaseService.ActualizarTrivia(_triviaOriginal);

                if (exito)
                {
                    await DisplayAlert("Éxito", "Trivia actualizada", "OK");
                    await Navigation.PopAsync();
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Error al guardar: {ex.Message}", "OK");
                Debug.WriteLine($"Error editando trivia: {ex}");
            }
        }
    }
}