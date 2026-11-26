using Microsoft.Data.Sqlite;

const string cadenaConexion = "Data Source=Videojuegos.db";

try
{
    // Abrimos la conexión. Si el archivo no existe, SQLite lo crea.
    using (var conexion = new SqliteConnection(cadenaConexion))
    {
        conexion.Open();
        Console.WriteLine("====================================");
        Console.WriteLine(" SISTEMA DE VIDEOJUEGOS");
        Console.WriteLine(" ADO.NET + SQLITE");
        Console.WriteLine("====================================");
        Console.WriteLine("\nConexión establecida correctamente.");

        // Creamos la tabla si todavía no existe.
        string crearTabla = """
            CREATE TABLE IF NOT EXISTS Videojuegos (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Nombre TEXT NOT NULL UNIQUE,
                Genero TEXT NOT NULL,
                Precio REAL NOT NULL
            );
            """;

        using (var comando = new SqliteCommand(crearTabla, conexion))
        {
            comando.ExecuteNonQuery();
        }
        Console.WriteLine("Tabla Videojuegos lista.");

        // Insertamos tres ejemplos. Los parámetros evitan concatenar
        // directamente los valores dentro de la instrucción SQL.
        string insertar = """
            INSERT OR IGNORE INTO Videojuegos (Nombre, Genero, Precio)
            VALUES ($nombre, $genero, $precio);
            """;

        var videojuegos = new[]
        {
            (Nombre: "Minecraft", Genero: "Aventura", Precio: 85000.0),
            (Nombre: "GTA V", Genero: "Accion", Precio: 120000.0),
            (Nombre: "FIFA 25", Genero: "Deportes", Precio: 150000.0)
        };

        Console.WriteLine("\nInsertando videojuegos...");
        int insertados = 0;

        foreach (var videojuego in videojuegos)
        {
            using (var comando = new SqliteCommand(insertar, conexion))
            {
                comando.Parameters.AddWithValue("$nombre", videojuego.Nombre);
                comando.Parameters.AddWithValue("$genero", videojuego.Genero);
                comando.Parameters.AddWithValue("$precio", videojuego.Precio);

                insertados += comando.ExecuteNonQuery();
            }
        }

        Console.WriteLine($"{insertados} videojuegos nuevos registrados.");
        Console.WriteLine("\nLISTA DE VIDEOJUEGOS");
        Console.WriteLine("------------------------------------");

        // Consultamos y leemos los registros con SqliteDataReader.
        string consultar = """
            SELECT Id, Nombre, Genero, Precio
            FROM Videojuegos
            ORDER BY Id;
            """;

        using (var comando = new SqliteCommand(consultar, conexion))
        using (var lector = comando.ExecuteReader())
        {
            while (lector.Read())
            {
                Console.WriteLine($"ID: {lector.GetInt32(0)}");
                Console.WriteLine($"Nombre: {lector.GetString(1)}");
                Console.WriteLine($"Genero: {lector.GetString(2)}");
                Console.WriteLine($"Precio: {lector.GetDecimal(3):N0}");
                Console.WriteLine("------------------------------------");
            }
        }

        Console.WriteLine("Consulta finalizada correctamente.");
        Console.WriteLine($"Base de datos: {Path.GetFullPath("Videojuegos.db")}");
    }
}
catch (SqliteException ex)
{
    Console.WriteLine($"Error de SQLite: {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine($"Ocurrió un error: {ex.Message}");
}
