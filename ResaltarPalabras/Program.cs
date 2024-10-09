using ResaltarPalabras.Plugin;

namespace ResaltarPalabras;

public class Program
{
    [STAThread]
    static void Main(string[] args)
    {
        var plugin = new ResaltarPalabrasPlugin();
        const string filePath = @"C:\Users\USUARIO\OneDrive\Escritorio\SOFTWARE 2\PLUG_AND_PLAY\PLUG_AND_PLAY\ArchivoPrueba.txt";

        try
        {
            var reservedWords = plugin.Execute(filePath!);
            Console.WriteLine($"\nPalabras reservadas encontradas: ");
            Console.WriteLine(reservedWords);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error inesperado: {ex.Message}");
        }

    }
}