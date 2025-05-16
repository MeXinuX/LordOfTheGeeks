using LordOfTheGeeks.Models;
using LordOfTheGeeks.Services;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;
using System.Diagnostics;

namespace LordOfTheGeeks
{
    public partial class EditSingleNewsPage : ContentPage
    {
        private readonly DatabaseService _databaseService;
        private readonly Noticia _noticiaOriginal;
        private byte[] _imagenBytes;
        private readonly List<string> _categorias = new List<string>
        {
            "Películas", "Videojuegos", "Series", "Cómics", "Tecnología"
        };

        public EditSingleNewsPage(DatabaseService databaseService, Noticia noticia)
        {
            InitializeComponent();
            _databaseService = databaseService;
            _noticiaOriginal = noticia;
            CargarDatosExistentes();
        }

        private void CargarDatosExistentes()
        {
            TitleEntry.Text = _noticiaOriginal.Titulo;
            CategoryPicker.ItemsSource = _categorias;
            CategoryPicker.SelectedItem = _noticiaOriginal.Categoria;
            ContentEditor.Text = _noticiaOriginal.Contenido;
            DateLabel.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

            // Cargar imagen existente si hay una
            if (!string.IsNullOrEmpty(_noticiaOriginal.ImagenOpcional))
            {
                _imagenBytes = Convert.FromBase64String(_noticiaOriginal.ImagenOpcional);
                PreviewImage.Source = ImageSource.FromStream(() => new MemoryStream(_imagenBytes));
                PreviewImage.IsVisible = true;
                ImagePathEntry.Text = "Imagen cargada";
            }
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
                    _imagenBytes = new byte[stream.Length];
                    await stream.ReadAsync(_imagenBytes, 0, (int)stream.Length);

                    ImagePathEntry.Text = result.FileName;
                    PreviewImage.Source = ImageSource.FromStream(() => new MemoryStream(_imagenBytes));
                    PreviewImage.IsVisible = true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error seleccionando imagen: {ex}");
                await DisplayAlert("Error", "No se pudo cargar la imagen", "OK");
            }
        }

        private async void OnSaveChangesClicked(object sender, EventArgs e)
        {
            try
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

                // Actualizar objeto
                _noticiaOriginal.Titulo = TitleEntry.Text;
                _noticiaOriginal.Categoria = CategoryPicker.SelectedItem.ToString();
                _noticiaOriginal.Contenido = ContentEditor.Text;
                _noticiaOriginal.Fecha = DateTime.Now;

                // Actualizar imagen solo si se seleccionó una nueva
                if (_imagenBytes != null)
                {
                    _noticiaOriginal.ImagenOpcional = Convert.ToBase64String(_imagenBytes);
                }

                // Guardar en DB
                bool exito = await _databaseService.ActualizarNoticia(_noticiaOriginal);

                if (exito)
                {
                    await DisplayAlert("Éxito", "Cambios guardados correctamente", "OK");
                    await Navigation.PopAsync(); // Regresar al listado
                }
                else
                {
                    await DisplayAlert("Error", "No se pudieron guardar los cambios", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Error al guardar: {ex.Message}", "OK");
                Debug.WriteLine($"Error en OnSaveChangesClicked: {ex}");
            }
        }
    }
}