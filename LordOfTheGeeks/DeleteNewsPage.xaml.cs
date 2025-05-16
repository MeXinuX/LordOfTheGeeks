using LordOfTheGeeks.Models;
using LordOfTheGeeks.Services;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace LordOfTheGeeks
{
    public partial class DeleteNewsPage : ContentPage
    {
        private readonly DatabaseService _databaseService;
        public ObservableCollection<Noticia> Noticias { get; } = new ObservableCollection<Noticia>();

        public DeleteNewsPage(DatabaseService databaseService)
        {
            InitializeComponent();
            _databaseService = databaseService;
            LoadNews();
        }

        private async void LoadNews()
        {
            try
            {
                Noticias.Clear();
                var noticias = await _databaseService.ObtenerTodasLasNoticias();
                foreach (var noticia in noticias)
                {
                    Noticias.Add(noticia);
                }
                NewsList.ItemsSource = Noticias;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Error cargando noticias: {ex.Message}", "OK");
                Debug.WriteLine($"Error en LoadNews: {ex}");
            }
        }

        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            try
            {
                if (sender is Button button && button.BindingContext is Noticia noticia)
                {
                    bool confirmar = await DisplayAlert(
                        "Confirmar",
                        $"¿Eliminar la noticia '{noticia.Titulo}'?",
                        "Sí", "No");

                    if (confirmar)
                    {
                        bool eliminado = await _databaseService.EliminarNoticia(noticia.Id);

                        if (eliminado)
                        {
                            Noticias.Remove(noticia); // Esto actualiza automáticamente la UI
                            await DisplayAlert("Éxito", "Noticia eliminada", "OK");
                        }
                        else
                        {
                            await DisplayAlert("Error", "No se pudo eliminar la noticia", "OK");
                        }
                    }
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