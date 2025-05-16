using LordOfTheGeeks.Models;
using LordOfTheGeeks.Services;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace LordOfTheGeeks
{
    public partial class NewsPage : ContentPage
    {
        private readonly DatabaseService _databaseService;
        private bool _isSidebarVisible = true;
        private ObservableCollection<Noticia> _allNews;
        private ObservableCollection<string> _categories = new ObservableCollection<string>();

        public NewsPage(DatabaseService databaseService)
        {
            InitializeComponent();
            _databaseService = databaseService;
            InitializePage();
        }

        private async void InitializePage()
        {
            await LoadCategories();
            CategoryFilter.SelectionChanged += OnCategorySelected;
            CategoryFilter.SelectedItem = "Todas";
            await LoadNews("Todas");
        }

        private async Task LoadCategories()
        {
            var noticias = await _databaseService.ObtenerTodasLasNoticias();
            var categoriasUnicas = noticias
                .Select(n => n.Categoria)
                .Distinct()
                .OrderBy(c => c)
                .ToList();

            _categories.Clear();
            _categories.Add("Todas");

            foreach (var categoria in categoriasUnicas)
            {
                _categories.Add(categoria);
            }

            CategoryFilter.ItemsSource = _categories;
        }

        private async Task LoadNews(string categoria = "Todas")
        {
            var todasNoticias = await _databaseService.ObtenerTodasLasNoticias();

            IEnumerable<Noticia> noticiasFiltradas;

            if (categoria == "Todas")
                noticiasFiltradas = todasNoticias;
            else
                noticiasFiltradas = todasNoticias.Where(n => n.Categoria == categoria);

            _allNews = new ObservableCollection<Noticia>(noticiasFiltradas);
            NewsList.ItemsSource = _allNews;
        }

        private async void OnCategorySelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is string selectedCategory)
            {
                await LoadNews(selectedCategory);
            }
        }

        private async void OnViewMoreClicked(object sender, EventArgs e)
        {
            if ((sender as Button)?.BindingContext is Noticia noticia)
            {
                var layout = new VerticalStackLayout
                {
                    Padding = 20,
                    BackgroundColor = Colors.White,
                    Spacing = 15
                };

                layout.Children.Add(new Label
                {
                    Text = noticia.Titulo,
                    FontSize = 20,
                    FontAttributes = FontAttributes.Bold,
                    TextColor = Colors.Black
                });

                layout.Children.Add(new Label
                {
                    Text = $"Categoría: {noticia.Categoria}",
                    FontSize = 16,
                    TextColor = Colors.Gray
                });

                layout.Children.Add(new ScrollView
                {
                    Content = new Label
                    {
                        Text = noticia.Contenido,
                        FontSize = 16,
                        TextColor = Colors.Black
                    },
                    HeightRequest = 200
                });

                layout.Children.Add(new Label
                {
                    Text = $"📅 Fecha: {noticia.Fecha:dd/MM/yyyy}",
                    FontSize = 14,
                    TextColor = Colors.Gray
                });

                if (!string.IsNullOrEmpty(noticia.ImagenOpcional))
                {
                    layout.Children.Add(new Image
                    {
                        Source = ImageSource.FromStream(() => new MemoryStream(Convert.FromBase64String(noticia.ImagenOpcional))),
                        Aspect = Aspect.AspectFit,
                        HeightRequest = 200
                    });
                }

                layout.Children.Add(new Button
                {
                    Text = "Cerrar",
                    BackgroundColor = Colors.LightGray,
                    TextColor = Colors.Black,
                    Command = new Command(async () => await Navigation.PopModalAsync())
                });

                var popup = new ContentPage
                {
                    BackgroundColor = Colors.Black.MultiplyAlpha(0.7f),
                    Content = new Frame
                    {
                        Content = layout,
                        Padding = 10,
                        Margin = 20,
                        CornerRadius = 10,
                        BackgroundColor = Colors.White
                    }
                };

                await Navigation.PushModalAsync(popup);
            }
        }

        private void OnToggleSidebarClicked(object sender, EventArgs e)
        {
            _isSidebarVisible = !_isSidebarVisible;
            SidebarColumn.Width = _isSidebarVisible ? 250 : 0;
            ToggleSidebarButton.Text = _isSidebarVisible ? "≡" : "»";
        }

        private async void OnTriviasClicked(object sender, EventArgs e)
            => await Navigation.PushAsync(new TriviaPage(_databaseService));

        private async void OnRankingClicked(object sender, EventArgs e)
            => await Navigation.PushAsync(new RankingPage(_databaseService));

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            CategoryFilter.SelectionChanged -= OnCategorySelected;
        }
    }
}
