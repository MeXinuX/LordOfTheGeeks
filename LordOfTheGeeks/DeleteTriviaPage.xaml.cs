using LordOfTheGeeks.Models;
using LordOfTheGeeks.Services;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace LordOfTheGeeks
{
    public partial class DeleteTriviaPage : ContentPage
    {
        private readonly DatabaseService _databaseService;
        public ObservableCollection<Trivia> Trivias { get; } = new ObservableCollection<Trivia>();

        public DeleteTriviaPage(DatabaseService databaseService)
        {
            InitializeComponent();
            _databaseService = databaseService;
            LoadTrivias();
        }

        private async void LoadTrivias()
        {
            try
            {
                Trivias.Clear();
                var trivias = await _databaseService.ObtenerTodasLasTrivias();
                foreach (var trivia in trivias)
                {
                    Trivias.Add(trivia);
                }
                TriviaList.ItemsSource = Trivias;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Error cargando trivias: {ex.Message}", "OK");
            }
        }

        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            try
            {
                // Verificar que el BindingContext contiene la trivia
                if (sender is Button button && button.BindingContext is Trivia trivia)
                {
                    Debug.WriteLine($"Intentando eliminar trivia ID: {trivia.Id}");

                    bool confirmar = await DisplayAlert(
                        "Confirmar",
                        $"¿Eliminar la trivia de {trivia.Saga}?\nPregunta: {trivia.Pregunta}",
                        "Sí", "No");

                    if (confirmar)
                    {
                        bool eliminado = await _databaseService.EliminarTrivia(trivia.Id);

                        if (eliminado)
                        {
                            Trivias.Remove(trivia); // Actualiza la ObservableCollection
                            await DisplayAlert("Éxito", "Trivia eliminada", "OK");
                        }
                    }
                }
                else
                {
                    Debug.WriteLine("Error: BindingContext no es una trivia");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Error al eliminar: {ex.Message}", "OK");
                Debug.WriteLine($"Error en OnDeleteClicked: {ex}");
            }
        }
    }
}