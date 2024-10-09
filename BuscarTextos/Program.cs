using BuscarTextos.Plugin;

namespace BuscarTextos;

class Program
{
    [STAThread]
    static void Main(string[] args)
    {
        var plugin = new BuscarTextosPlugin();

        const string filePath = @"C:\Users\USUARIO\OneDrive\Escritorio\SOFTWARE 2\PLUG_AND_PLAY\PLUG_AND_PLAY\ArchivoPrueba.java";

        try
        {
            var resultados = plugin.Execute(filePath);
            Console.WriteLine(resultados);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error inesperado p: {ex.Message}");
        }
    }
}