using SQLite;
using System.Diagnostics;
using System.Net.Http.Json;
using LordOfTheGeeks.Services;


namespace LordOfTheGeeks.Services;

using LordOfTheGeeks.Models; // Asegúrate de que coincida con el namespace de Usuario.cs
public class DatabaseService
{
    private SQLiteAsyncConnection _db;

    public DatabaseService()
    {
        // Inicializar la conexión
        Initialize();
    }

    private async Task Initialize()
    {
        if (_db is not null)
            return;

        // Ruta donde se guardará la base de datos
        string databasePath = Path.Combine(FileSystem.AppDataDirectory, "trivias.db3");

        // Configuración de SQLite
        _db = new SQLiteAsyncConnection(databasePath);

        try
        {
            // Crear tablas (si no existen)
            await _db.CreateTableAsync<Usuario>();
            await _db.CreateTableAsync<Trivia>();
            await _db.CreateTableAsync<ResultadoTrivia>();
            await _db.CreateTableAsync<Noticia>();

            Debug.WriteLine("✅ Base de datos creada correctamente.");
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"❌ Error al crear la base de datos: {ex.Message}");
        }
    }





    //C R E A R   U N  U S U A R I O
    public async Task<bool> RegistrarUsuario(Usuario usuario)
    {
        try
        {
            // Verificar si el usuario ya existe
            var usuarioExistente = await _db.Table<Usuario>()
                                          .Where(u => u.NombreUsuario == usuario.NombreUsuario)
                                          .FirstOrDefaultAsync();

            if (usuarioExistente != null)
                return false; // Usuario ya existe

            await _db.InsertAsync(usuario);
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error al registrar usuario: {ex.Message}");
            throw; // Relanza la excepción para manejarla en la UI
        }
    }

    //O B T E N E R  U N  U S U A R I O
    public async Task<Usuario> ObtenerUsuario(string nombreUsuario)
    {
        return await _db.Table<Usuario>()
                       .Where(u => u.NombreUsuario == nombreUsuario)
                       .FirstOrDefaultAsync();
    }

    // C R E A R  U N A  N O T I C I A
    public async Task GuardarNoticia(Noticia noticia)
    {
        try
        {
            await _db.InsertAsync(noticia);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error guardando noticia: {ex}");
            throw;
        }
    }

    // M O D I F I C A R  U N A  N O T I C I A
    public async Task<bool> ActualizarNoticia(Noticia noticia)
    {
        try
        {
            await _db.UpdateAsync(noticia);
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error actualizando noticia: {ex}");
            return false;
        }
    }



    // E L I M I N A R  U N A  N O T I C I A
    public async Task<List<Noticia>> ObtenerTodasLasNoticias()
    {
        return await _db.Table<Noticia>().OrderByDescending(n => n.Fecha).ToListAsync();
    }

    public async Task<bool> EliminarNoticia(int idNoticia)
    {
        try
        {
            int result = await _db.DeleteAsync<Noticia>(idNoticia);
            return result == 1; // Retorna true si se eliminó exactamente 1 registro
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error eliminando noticia: {ex}");
            return false;
        }
    }



    // C R E A R  U N A  T R I V I A
    public async Task<bool> GuardarTrivia(Trivia trivia)
    {
        try
        {
            await _db.InsertAsync(trivia);
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error guardando trivia: {ex}");
            return false;
        }
    }


    // M O D I F I C A R  U N A  T R I V I A
    public async Task<bool> ActualizarTrivia(Trivia trivia)
    {
        try
        {
            int result = await _db.UpdateAsync(trivia);
            return result == 1;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error actualizando trivia: {ex}");
            return false;
        }
    }



    // E L I M I N A R  U N A  T R I V I A
    public async Task<List<Trivia>> ObtenerTodasLasTrivias()
    {
        return await _db.Table<Trivia>().OrderBy(t => t.Saga).ToListAsync();
    }

    public async Task<bool> EliminarTrivia(int idTrivia)
    {
        try
        {
            int result = await _db.DeleteAsync<Trivia>(idTrivia);
            return result == 1; // Retorna true si se eliminó 1 registro
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error eliminando trivia: {ex}");
            return false;
        }
    }

    // P A G I N A  D E  T R I V I A S
    public async Task<List<string>> ObtenerCategoriasTrivia()
    {

        return await _db.QueryScalarsAsync<string>("SELECT DISTINCT Saga FROM Trivias");
    }

    public async Task<Trivia> ObtenerTriviaAleatoria(string categoria)
    {
        return await _db.QueryAsync<Trivia>(
            "SELECT * FROM Trivias WHERE Saga = ? ORDER BY RANDOM() LIMIT 1",
            categoria
        ).ContinueWith(t => t.Result.FirstOrDefault());
    }

    public async Task AumentarXPUsuario(int usuarioId, int xp)
    {

        await _db.ExecuteAsync(
            "UPDATE Usuarios SET XP = XP + ? WHERE Id = ?",
            xp, usuarioId);
    }

    public async Task RegistrarResultadoTrivia(int usuarioId, string saga, int puntaje, string fecha)
    {

        await _db.InsertAsync(new ResultadoTrivia
        {
            IdUsuario = usuarioId,
            Saga = saga,
            Puntaje = puntaje
        });
    }








    // P A G I N A  D E  N O T I C I A S

    public async Task<List<Noticia>> ObtenerNoticiasPorCategoria(string categoria)
    {
        return await _db.Table<Noticia>()
                       .Where(n => n.Categoria == categoria)
                       .OrderByDescending(n => n.Fecha)
                       .ToListAsync();
    }





    public async Task<bool> CorreoYaRegistrado(string correo)
    {
        try
        {
            var usuarioExistente = await _db.Table<Usuario>()
                .Where(u => u.NombreUsuario == correo)
                .FirstOrDefaultAsync();

            return usuarioExistente != null;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error al verificar correo: {ex.Message}");
            return false;
        }
    }




    // P A G I N A  D E  R A N K I N G
    public async Task<List<Usuario>> ObtenerUsuariosOrdenadosPorXP()
    {
        return await _db.Table<Usuario>()
                       .OrderByDescending(u => u.XP)
                       .ToListAsync();
    }


    // S I N C R O N I Z A C I O N  D E  B A S E  D E  D A T O S  E N  L A  N U B E
    // Para sincronizar Noticias locales
    // S I N C R O N I Z A C I O N  D E  B A S E  D E  D A T O S  E N  L A  N U B E
    // Para sincronizar Noticias locales
    public async Task<List<Noticia>> GetNoticiasLocalAsync()
    {
        return await ObtenerTodasLasNoticias();
    }

    // Para sincronizar Trivias locales
    public async Task<List<Trivia>> GetTriviasLocalAsync()
    {
        return await ObtenerTodasLasTrivias();
    }

    // ✅ Agrega esto:
    public async Task<List<Usuario>> GetUsuariosLocalAsync()
    {
        return await _db.Table<Usuario>().ToListAsync();
    }





}