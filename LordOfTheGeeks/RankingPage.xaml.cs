using LordOfTheGeeks.Models;
using LordOfTheGeeks.Services;
using Microsoft.Maui.Controls;
using System.Linq;

namespace LordOfTheGeeks
{
    public partial class RankingPage : ContentPage
    {
        private readonly DatabaseService _databaseService;
        private Trivia _currentTrivia;
        private Usuario _currentUser;
        private bool _isSidebarVisible = true;

        public RankingPage(DatabaseService databaseService)
        {
            InitializeComponent();
            _databaseService = databaseService;
            LoadRankingData();
        }

        private async void LoadRankingData()
        {
            var usuarios = await _databaseService.ObtenerUsuariosOrdenadosPorXP();

            // Filtrar solo usuarios con rol 'usuario' y extraer nombre antes del @
            var rankingData = usuarios
                .Where(u => u.Rol?.ToLower() == "usuario")
                .Select((usuario, index) => new
                {
                    Position = index + 1,
                    Username = usuario.NombreUsuario.Split('@')[0], // Solo parte antes del @
                    XP = usuario.XP
                })
                .ToList();

            RankingList.ItemsSource = rankingData;
        }

        // Método para alternar la barra lateral
        private void OnToggleSidebarClicked(object sender, EventArgs e)
        {
            _isSidebarVisible = !_isSidebarVisible;
            SidebarColumn.Width = _isSidebarVisible ? 250 : 0;
            ToggleSidebarButton.Text = _isSidebarVisible ? "≡" : "»";
        }

        // Navegación
        private async void OnNewsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewsPage(_databaseService));
        }

        private async void OnTriviasClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TriviaPage(_databaseService));
        }
    }
}
