using ContadorPalabras.Plugin;
using ListarPalabras.Plugin;

namespace PLUG_AND_PLAY;

internal abstract class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Ingrese la ruta del archivo:");
        var filePath = Console.ReadLine();

        // Prueba del plugin ListarPalabras
        var plugin2 = new ListarPalabrasPlugin();
        try
        {
            var wordList = plugin2.Execute(filePath!);
            Console.WriteLine($"Palabras únicas encontradas: ");
            Console.WriteLine(wordList);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error inesperado: {e.Message}");
        }

        // Prueba del plugin ContadorPalabras
        var plugin3 = new ContadorPalabrasPlugin();
        try
        {
            var wordCount = plugin3.Execute(filePath!);
            Console.WriteLine($"Conteo de palabras: ");
            Console.WriteLine(wordCount);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error inesperado: {e.Message}");
        }
    }
}