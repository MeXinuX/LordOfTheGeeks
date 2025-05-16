using System.Net.Http.Json;
using LordOfTheGeeks.Models;
using System.Net.NetworkInformation;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using LordOfTheGeeks.Services;

namespace LordOfTheGeeks.Services
{
    // Convertir la clase en estática
    public static class CloudSyncService
    {
        private static readonly HttpClient _httpClient;
        private const string SUPABASE_URL = "https://zfmfrxruwxhszvtislgv.supabase.co";
        private const string API_KEY = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6InpmbWZyeHJ1d3hoc3p2dGlzbGd2Iiwicm9sZSI6ImFub24iLCJpYXQiOjE3NDcxMjY0NTgsImV4cCI6MjA2MjcwMjQ1OH0.ENMDI7sylFPRAQnAKp3b5VPbAo-iWbHFvfnQEGW6pLo";

        static CloudSyncService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(SUPABASE_URL + "/rest/v1/");
            _httpClient.DefaultRequestHeaders.Add("apikey", API_KEY);
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + API_KEY);
        }

        // Verificación de internet, ya que ahora es un método estático
        private static bool IsInternetAvailable()
        {
            try
            {
                var ping = new Ping();
                var result = ping.Send("google.com", 1000);
                return result.Status == IPStatus.Success;
            }
            catch
            {
                return false;
            }
        }

        // Método de sincronización con la nube, ahora es estático
        public static async Task SyncDataIfConnected(DatabaseService databaseService)
        {
            if (IsInternetAvailable())
            {
                Console.WriteLine("Conexión a Internet detectada. Sincronizando con Supabase...");
                await SyncDataWithCloud(databaseService);
            }
            else
            {
                Console.WriteLine("Sin conexión a Internet. Los datos no se sincronizan.");
            }
        }

        // Sincronizar datos con la nube
        private static async Task SyncDataWithCloud(DatabaseService databaseService)
        {
            // 1. Usuarios
            var usuarios = await databaseService.GetUsuariosLocalAsync();
            await SubirUsuariosAsync(usuarios);

            var usuariosDeSupabase = await DescargarUsuariosAsync();
            foreach (var usuario in usuariosDeSupabase)
            {
                await databaseService.RegistrarUsuario(usuario);
            }

            // 2. Noticias
            var noticias = await databaseService.GetNoticiasLocalAsync();
            await SubirNoticiasAsync(noticias);

            var noticiasDeSupabase = await DescargarNoticiasAsync();
            foreach (var noticia in noticiasDeSupabase)
            {
                await databaseService.GuardarNoticia(noticia);
            }

            // 3. Trivias
            var trivias = await databaseService.GetTriviasLocalAsync();
            await SubirTriviasAsync(trivias);

            var triviasDeSupabase = await DescargarTriviasAsync();
            foreach (var trivia in triviasDeSupabase)
            {
                await databaseService.GuardarTrivia(trivia);
            }
        }

        // Métodos de subida
        public static async Task SubirUsuariosAsync(List<Usuario> usuarios)
        {
            foreach (var usuario in usuarios)
            {
                try
                {
                    var response = await _httpClient.PostAsJsonAsync("Usuarios", usuario);
                    response.EnsureSuccessStatusCode();
                    Console.WriteLine("Usuario subido correctamente: " + usuario.NombreUsuario);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error subiendo usuario: " + ex.Message);
                }
            }
        }

        public static async Task SubirNoticiasAsync(List<Noticia> noticias)
        {
            foreach (var noticia in noticias)
            {
                try
                {
                    var response = await _httpClient.PostAsJsonAsync("Noticias", noticia);
                    response.EnsureSuccessStatusCode();
                    Console.WriteLine("Noticia subida correctamente: " + noticia.Titulo);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error subiendo noticia: " + ex.Message);
                }
            }
        }

        public static async Task SubirTriviasAsync(List<Trivia> trivias)
        {
            foreach (var trivia in trivias)
            {
                try
                {
                    var response = await _httpClient.PostAsJsonAsync("Trivia", trivia);
                    response.EnsureSuccessStatusCode();
                    Console.WriteLine("Trivia subida correctamente: " + trivia.Pregunta);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error subiendo trivia: " + ex.Message);
                }
            }
        }

        // Métodos de descarga
        public static async Task<List<Usuario>> DescargarUsuariosAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("Usuarios");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<Usuario>>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al descargar usuarios: " + ex.Message);
            }
            return new List<Usuario>();
        }

        public static async Task<List<Noticia>> DescargarNoticiasAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("Noticias");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<Noticia>>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al descargar noticias: " + ex.Message);
            }
            return new List<Noticia>();
        }

        public static async Task<List<Trivia>> DescargarTriviasAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("Trivia");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<Trivia>>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al descargar trivias: " + ex.Message);
            }
            return new List<Trivia>();
        }

        public static async Task<List<ResultadoTrivia>> DescargarResultadosTriviaAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("ResultadoTrivia");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<ResultadoTrivia>>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al descargar resultados: " + ex.Message);
            }
            return new List<ResultadoTrivia>();
        }
    }
}
