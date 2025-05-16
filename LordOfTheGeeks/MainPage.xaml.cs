using LordOfTheGeeks.Models;
using LordOfTheGeeks.Services;
using Microsoft.Maui.Controls;
using System.Diagnostics;

namespace LordOfTheGeeks
{
    public partial class MainPage : ContentPage
    {
        private readonly DatabaseService _databaseService;

        public MainPage(DatabaseService databaseService)
        {
            InitializeComponent();
            _databaseService = databaseService;
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            string username = UsernameEntry.Text?.Trim();
            string password = PasswordEntry.Text;

            // Validaciones básicas
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                await DisplayAlert("Error", "Usuario y contraseña son obligatorios", "OK");
                return;
            }

            try
            {
                // Buscar usuario en la base de datos
                var usuario = await _databaseService.ObtenerUsuario(username);

                if (usuario != null && usuario.Contrasena == password)
                {
                    App.CurrentUser = usuario; // Guarda el usuario globalmente

                    if (usuario.Rol == "admin")
                    {
                        await Navigation.PushAsync(new AdminDashboardPage(_databaseService));
                    }
                    else
                    {
                        // Pasa SOLO el DatabaseService
                        await Navigation.PushAsync(new NewsPage(_databaseService)); // 👈 1 parámetro
                    }
                }
                else
                {
                    await DisplayAlert("Error", "Credenciales incorrectas", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"No se pudo conectar a la base de datos: {ex.Message}", "OK");
                Debug.WriteLine($"Error en login: {ex}");
            }
        }

        private async void OnRegisterTapped(object sender, EventArgs e)
        {
            //// Opción 1: Usando DI
            //var registerPage = Handler.MauiContext.Services.GetRequiredService<RegisterPage>();
            //await Navigation.PushAsync(registerPage);

            // Opción 2: Si RegisterPage necesita DatabaseService
             await Navigation.PushAsync(new RegisterPage(_databaseService));
        }
    }
}