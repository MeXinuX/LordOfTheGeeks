using SQLite;

namespace LordOfTheGeeks.Models;

[Table("Trivias")]
public class Trivia
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [NotNull]
    public string Saga { get; set; }

    [NotNull]
    public string Pregunta { get; set; }

    [NotNull]
    public string OpcionA { get; set; }

    [NotNull]
    public string OpcionB { get; set; }

    [NotNull]
    public string OpcionC { get; set; }

    [NotNull]
    public string OpcionCorrecta { get; set; } // "A", "B" o "C"
}