using LordOfTheGeeks.Models;
using LordOfTheGeeks.Services;
using Microsoft.Maui.Controls;
using System.Diagnostics;
using System.Linq;

namespace LordOfTheGeeks
{
    public partial class CreateTriviaPage : ContentPage
    {
        private readonly DatabaseService _databaseService;
        private readonly Random _random = new Random();

        public CreateTriviaPage(DatabaseService databaseService)
        {
            InitializeComponent();
            _databaseService = databaseService;
            CargarSagasPredefinidas();
        }

        private void CargarSagasPredefinidas()
        {
            SagaPicker.ItemsSource = new List<string>
            {
                "Películas",
                "Videojuegos",
                "Series",
                "Cómics",
                "Tecnología"
            };
        }

        private async void OnCreateTriviaClicked(object sender, EventArgs e)
        {
            try
            {
                if (SagaPicker.SelectedItem == null)
                {
                    await DisplayAlert("Error", "Selecciona una Categoria", "OK");
                    return;
                }

                if (string.IsNullOrWhiteSpace(QuestionEditor.Text))
                {
                    await DisplayAlert("Error", "La pregunta es obligatoria", "OK");
                    return;
                }

                // Validar respuestas
                var respuestas = new List<string>
                {
                    CorrectAnswerEntry.Text?.Trim(),  // Respuesta correcta
                    WrongAnswer1Entry.Text?.Trim(),   // Respuesta incorrecta 1
                    WrongAnswer2Entry.Text?.Trim()    // Respuesta incorrecta 2
                };

                if (respuestas.Any(string.IsNullOrEmpty))
                {
                    await DisplayAlert("Error", "Todas las respuestas son obligatorias", "OK");
                    return;
                }

                // Mezclar las respuestas aleatoriamente
                var respuestasMezcladas = respuestas.OrderBy(x => _random.Next()).ToList();

                // Obtener el TEXTO de la respuesta correcta (antes de mezclar)
                var textoRespuestaCorrecta = respuestas[0];  // 👈 Respuesta original

                // Crear trivia con respuestas mezcladas
                var nuevaTrivia = new Trivia
                {
                    Saga = SagaPicker.SelectedItem.ToString(),
                    Pregunta = QuestionEditor.Text.Trim(),
                    OpcionA = respuestasMezcladas[0],
                    OpcionB = respuestasMezcladas[1],
                    OpcionC = respuestasMezcladas[2],
                    OpcionCorrecta = textoRespuestaCorrecta  // 👈 Guardar el texto correcto
                };

                // Guardar en DB
                bool exito = await _databaseService.GuardarTrivia(nuevaTrivia);

                if (exito)
                {
                    await DisplayAlert("Éxito", "Trivia creada correctamente", "OK");
                    LimpiarFormulario();
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Error al guardar: {ex.Message}", "OK");
                Debug.WriteLine($"Error en CreateTrivia: {ex}");
            }
        }

        private void LimpiarFormulario()
        {
            SagaPicker.SelectedItem = null;
            QuestionEditor.Text = string.Empty;
            CorrectAnswerEntry.Text = string.Empty;
            WrongAnswer1Entry.Text = string.Empty;
            WrongAnswer2Entry.Text = string.Empty;
        }
    }
}