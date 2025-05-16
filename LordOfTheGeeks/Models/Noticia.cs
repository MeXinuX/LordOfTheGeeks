using SQLite;

namespace LordOfTheGeeks.Models;

[Table("Noticias")]
public class Noticia
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [NotNull]
    public string Titulo { get; set; }

    [NotNull]
    public string Categoria { get; set; } // Ej: "Películas", "Videojuegos"

    [NotNull]
    public string Contenido { get; set; }

    [NotNull]
    public DateTime Fecha { get; set; }

    public string ImagenOpcional { get; set; } // Ruta o Base64 (puede ser null)
}