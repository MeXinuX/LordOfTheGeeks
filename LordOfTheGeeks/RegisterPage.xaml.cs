using LordOfTheGeeks.Models;
using LordOfTheGeeks.Services;
using Microsoft.Maui.Controls;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace LordOfTheGeeks
{
    public partial class RegisterPage : ContentPage
    {
        private readonly DatabaseService _databaseService;

        public RegisterPage(DatabaseService databaseService)
        {
            InitializeComponent();
            _databaseService = databaseService;
        }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            string correo = UsernameEntry.Text?.Trim();
            string contrasena = PasswordEntry.Text;

            // Validación básica
            if (string.IsNullOrWhiteSpace(correo) || string.IsNullOrWhiteSpace(contrasena))
            {
                await DisplayAlert("Error", "Correo y contraseña son obligatorios.", "OK");
                return;
            }

            // Validar formato de correo
            if (!EsCorreoValido(correo))
            {
                await DisplayAlert("Error", "Por favor, ingresa un correo válido.", "OK");
                return;
            }

            // Validar fortaleza de contraseña
            if (!EsContrasenaValida(contrasena))
            {
                await DisplayAlert("Error",
                    "La contraseña debe contener:\n• Al menos una letra mayúscula\n• Al menos un número\n• Al menos un carácter especial (!@#$%^&*())",
                    "OK");
                return;
            }

            // Validar si ya existe en la base de datos
            bool existe = await _databaseService.CorreoYaRegistrado(correo);
            if (existe)
            {
                await DisplayAlert("Error", "Este correo ya está registrado.", "OK");
                return;
            }

            // Crear el objeto usuario
            var nuevoUsuario = new Usuario
            {
                NombreUsuario = correo,
                Contrasena = contrasena, // Recuerda usar hash en producción
                Rol = "usuario",
                XP = 0
            };

            try
            {
                bool registroExitoso = await _databaseService.RegistrarUsuario(nuevoUsuario);

                if (registroExitoso)
                {
                    await DisplayAlert("Éxito", "Usuario registrado correctamente", "OK");
                    var mainPage = Handler.MauiContext.Services.GetRequiredService<MainPage>();
                    await Navigation.PushAsync(mainPage);
                }
                else
                {
                    await DisplayAlert("Error", "No se pudo registrar el usuario.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Ocurrió un error: {ex.Message}", "OK");
                Debug.WriteLine($"❌ Error en registro: {ex}");
            }
        }

        private bool EsCorreoValido(string correo)
        {
            string patron = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(correo, patron, RegexOptions.IgnoreCase);
        }

        private bool EsContrasenaValida(string contrasena)
        {
            // Expresión regular para validar:
            // - Al menos una mayúscula (?=.*[A-Z])
            // - Al menos un número (?=.*\d)
            // - Al menos un carácter especial (?=.*[!@#$%^&*()])
            // - Longitud mínima de 8 caracteres .{8,}
            string patron = @"^(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()]).{8,}$";

            return Regex.IsMatch(contrasena, patron);
        }
    }
}