using SQLite;

namespace LordOfTheGeeks.Models;

[Table("ResultadosTrivias")]
public class ResultadoTrivia
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [NotNull]
    public int IdUsuario { get; set; }

    [NotNull]
    public string Saga { get; set; }

    [NotNull]
    public int Puntaje { get; set; }

    [NotNull]
    public DateTime Fecha { get; set; } = DateTime.Now;
}