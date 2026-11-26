# Proyecto: Sistema de Registro de Videojuegos con ADO.NET y SQLite

## 1. ¿De qué trata el proyecto?

Este proyecto lo realicé utilizando C# y .NET 8. Consiste en un pequeño programa de consola que permite guardar y mostrar información de videojuegos utilizando una base de datos SQLite.

La idea de este ejercicio es aprender cómo conectar un programa con una base de datos y cómo guardar información para que no se pierda cuando se cierre el programa.

Para el ejemplo utilicé tres videojuegos: Minecraft, GTA V y FIFA 25.

## 2. Herramientas que utilicé

Para desarrollar este proyecto utilicé las siguientes herramientas:

- **C#:** fue el lenguaje que utilicé para escribir el código.
- **.NET 8:** es la plataforma donde se ejecuta el programa.
- **ADO.NET:** permite que el programa se comunique con la base de datos.
- **SQLite:** es donde se guarda la información de los videojuegos.
- **Microsoft.Data.Sqlite:** es el paquete que permite trabajar con SQLite desde C#.

## 3. ¿Cómo está organizada la base de datos?

El programa crea una base de datos llamada `Videojuegos.db`. Dentro de ella se encuentra una tabla llamada `Videojuegos`.

Esta tabla tiene cuatro campos:

| Campo | ¿Para qué sirve? |
|---|---|
| Id | Identifica cada videojuego. |
| Nombre | Guarda el nombre del videojuego. |
| Genero | Guarda el género del videojuego. |
| Precio | Guarda el precio del videojuego. |

De esta manera, cada videojuego queda almacenado con sus respectivos datos.

## 4. ¿Cómo funciona el código?

El programa realiza varias operaciones en orden:

**Primero: conexión con la base de datos.**

Utilicé `SqliteConnection` para conectar el programa con SQLite. Esta conexión permite que C# pueda trabajar con la información que está guardada en la base de datos.

**Segundo: creación de la tabla.**

Después de conectarse, el programa revisa si ya existe la tabla Videojuegos. Si no existe, la crea automáticamente con sus respectivos campos.

**Tercero: insertar los videojuegos.**

Para guardar los videojuegos utilicé `SqliteCommand`, que permite ejecutar instrucciones SQL. También utilicé parámetros para enviar el nombre, el género y el precio de cada videojuego.

**Cuarto: mostrar la información.**

Después de guardar los datos, el programa realiza una consulta para mostrar los videojuegos registrados. Para esto utilicé `SqliteDataReader`, que permite leer la información almacenada y mostrarla en la consola.

**Quinto: liberar los recursos.**

También utilicé `using`, que permite liberar automáticamente los recursos utilizados por la conexión y los comandos cuando terminan de trabajar.

## 5. Componentes de ADO.NET que utilicé

Durante el desarrollo entendí que cada componente tiene una función diferente:

- **SqliteConnection:** lo utilicé para conectar mi programa con la base de datos.
- **SqliteCommand:** lo utilicé para ejecutar las instrucciones SQL y guardar los videojuegos.
- **SqliteDataReader:** lo utilicé para leer y mostrar los videojuegos que están guardados.
- **Parameters:** los utilicé para enviar los datos de cada videojuego sin tener que escribirlos directamente dentro de la consulta SQL.
- **using:** lo utilicé para que los recursos se liberen correctamente cuando terminan de utilizarse.

## 6. ¿Cómo ejecutar el proyecto?

Para ejecutar el programa primero necesito tener instalado .NET 8 o una versión superior.

Después debo seguir estos pasos:

1. Descargar y descomprimir la carpeta del proyecto.
2. Abrir la carpeta donde se encuentra el archivo `.csproj`.
3. Abrir PowerShell o la terminal de Visual Studio Code.
4. Escribir el siguiente comando:

```powershell
dotnet restore
```

5. Cuando termine, ejecutar:

```powershell
dotnet run
```

Al hacer esto, el programa se ejecuta, se conecta con SQLite, guarda los videojuegos que todavía no estén registrados y muestra la información en la pantalla.

## 7. Resultado del proyecto

Al ejecutar el programa puedo observar los mensajes de conexión, la creación de la tabla, la inserción de los videojuegos y finalmente la consulta de los registros.

Algo que también pude comprobar es que, si vuelvo a ejecutar el programa, no se repiten los videojuegos que ya estaban guardados. Esto sucede porque el código tiene una instrucción que evita insertar nombres duplicados.

## 8. Conclusión personal

Con esta actividad pude aprender un poco más sobre cómo se conecta un programa de C# con una base de datos. Antes conocía la programación para mostrar información en la consola, pero con este ejercicio entendí que también es posible guardar datos y consultarlos después sin perderlos.

También aprendí para qué sirven SqliteConnection, SqliteCommand y SqliteDataReader, y cómo se pueden utilizar juntos para trabajar con una base de datos.

Considero que esto es importante porque en el futuro puedo utilizar estos conocimientos para desarrollar programas más completos, como un sistema de inventario, un registro de estudiantes o una aplicación para administrar productos.
