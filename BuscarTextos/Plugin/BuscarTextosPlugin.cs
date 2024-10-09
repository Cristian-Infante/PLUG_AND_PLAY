using BuscarTextos.Interfaces;
using BuscarTextos.Models;
using BuscarTextos.Services;
using System.Text;

namespace BuscarTextos.Plugin;

public class BuscarTextosPlugin : IPlugin
{
    private readonly FileReader _fileReader = new();
    private readonly TextSearcher _textSearcher = new();

    public string Execute(string filePath)
    {
        // Leer el contenido del archivo
        var fileContent = _fileReader.ReadFile(filePath);
        // Solicitar la palabra al usuario
        var palabra = SolicitarPalabra();

        if (string.IsNullOrWhiteSpace(palabra))
        {
            throw new Exception("La palabra a buscar no puede estar vacía.");
        }

        // Buscar la palabra
        var resultados = _textSearcher.Search(fileContent, palabra);

        // Formatear los resultados para mostrar en el TextBox
        return FormatearResultados(resultados);
    }

    private static string FormatearResultados(IEnumerable<SearchResult> resultados)
    {
        var sb = new StringBuilder();
        foreach (var resultado in resultados)
        {
            sb.AppendLine($"Línea {resultado.Line}, Columna {resultado.Column}");
        }
        return sb.ToString();
    }

    public IEnumerable<SearchResult> Buscar(string filePath)
    {
        var contenido = _fileReader.ReadFile(filePath);
        var palabra = SolicitarPalabra();

        if (string.IsNullOrWhiteSpace(palabra))
        {
            throw new Exception("La palabra ingresada no es válida.");
        }

        var resultados = _textSearcher.Search(contenido, palabra);

        return resultados;
    }

    private static string SolicitarPalabra()
    {
        // Mostrar el formulario para ingresar la palabra
        using var form = new UI.InputForm();
        var result = form.ShowDialog();
        if (result == DialogResult.OK)
        {
            return form.InputText;
        }
        else
        {
            throw new Exception("Operación cancelada por el usuario.");
        }
    }
}