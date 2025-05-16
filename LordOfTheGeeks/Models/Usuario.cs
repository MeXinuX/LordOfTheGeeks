using SQLite;

namespace LordOfTheGeeks.Models;

[Table("Usuarios")]
public class Usuario
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [NotNull, Unique]  // Campo obligatorio y único en la BD
    public string NombreUsuario { get; set; }

    [NotNull]  // Contraseña obligatoria
    public string Contrasena { get; set; }

    [NotNull]  // Rol obligatorio (admin/usuario)
    public string Rol { get; set; } = "usuario";  // Valor por defecto

    public int XP { get; set; } = 0;  // XP inicial en 0
}