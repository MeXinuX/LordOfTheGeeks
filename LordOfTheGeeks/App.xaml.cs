using LordOfTheGeeks.Services;
using Microsoft.Maui.Controls;
using LordOfTheGeeks.Models;

namespace LordOfTheGeeks
{
    public partial class App : Application
    {
        // Agrega esta propiedad estática para almacenar al usuario actual
        public static Usuario CurrentUser { get; set; }

        // Declara los servicios que utilizarás en la app
        private readonly DatabaseService _databaseService;

        public App(DatabaseService databaseService)
        {
            InitializeComponent();

            _databaseService = databaseService;

            // Llamar al método de sincronización de datos al iniciar la app
            SyncDataIfConnected();

            // Inicializa la página principal
            MainPage = new NavigationPage(new MainPage(databaseService));
        }

        // Método para sincronizar los datos si hay conexión a Internet
        private async void SyncDataIfConnected()
        {
            // Sincroniza los datos con la nube si hay conexión a Internet
            await CloudSyncService.SyncDataIfConnected(_databaseService);
        }
    }
}
