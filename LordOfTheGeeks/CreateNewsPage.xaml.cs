using LordOfTheGeeks.Models;
using LordOfTheGeeks.Services;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;
using System.Diagnostics;

namespace LordOfTheGeeks
{
    public partial class CreateNewsPage : ContentPage
    {
        private readonly DatabaseService _databaseService;
        private byte[] _imageBytes;

        public CreateNewsPage(DatabaseService databaseService)
        {
            InitializeComponent();
            _databaseService = databaseService;
            InitializePage();
        }

        private void InitializePage()
        {
            // Configurar categorías disponibles
            CategoryPicker.ItemsSource = new List<string>
            {
                "Películas",
                "Videojuegos",
                "Series",
                "Cómics",
                "Tecnología"
            };

            // Mostrar fecha actual
            DateLabel.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
        }

        private async void OnSelectImageClicked(object sender, EventArgs e)
        {
            try
            {
                var result = await FilePicker.PickAsync(new PickOptions
                {
                    PickerTitle = "Seleccionar imagen",
                    FileTypes = FilePickerFileType.Images
                });

                if (result != null)
                {
                    var stream = await result.OpenReadAsync();
                    _imageBytes = new byte[stream.Length];
                    await stream.ReadAsync(_imageBytes, 0, (int)stream.Length);

                    ImagePathEntry.Text = result.FileName;
                    PreviewImage.Source = ImageSource.FromStream(() => new MemoryStream(_imageBytes));
                    PreviewImage.IsVisible = true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error seleccionando imagen: {ex}");
                await DisplayAlert("Error", "No se pudo cargar la imagen", "OK");
            }
        }

        private async void OnCreateNewsClicked(object sender, EventArgs e)
        {
            // Validaciones
            if (string.IsNullOrWhiteSpace(TitleEntry.Text))
            {
                await DisplayAlert("Error", "El título es obligatorio", "OK");
                return;
            }

            if (CategoryPicker.SelectedItem == null)
            {
                await DisplayAlert("Error", "Debe seleccionar una categoría", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(ContentEditor.Text))
            {
                await DisplayAlert("Error", "El contenido no puede estar vacío", "OK");
                return;
            }

            try
            {
                var nuevaNoticia = new Noticia
                {
                    Titulo = TitleEntry.Text.Trim(),
                    Categoria = CategoryPicker.SelectedItem.ToString(),
                    Contenido = ContentEditor.Text,
                    Fecha = DateTime.Now,
                    ImagenOpcional = _imageBytes != null ? Convert.ToBase64String(_imageBytes) : null
                };

                await _databaseService.GuardarNoticia(nuevaNoticia);
                await DisplayAlert("Éxito", "Noticia creada correctamente", "OK");
                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error creando noticia: {ex}");
                await DisplayAlert("Error", "No se pudo guardar la noticia", "OK");
            }
        }
    }
}