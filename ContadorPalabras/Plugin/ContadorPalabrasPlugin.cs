using ContadorPalabras.Interfaces;
using ContadorPalabras.Models;
using ContadorPalabras.Services;
using System.Text;

namespace ContadorPalabras.Plugin;

public class ContadorPalabrasPlugin : IPlugin
{
    private readonly FileReader _fileReader;
    private readonly WordExtractor _wordExtractor;
    private readonly WordFilter _wordFilter;
    private readonly WordCounter _wordCounter;

    public ContadorPalabrasPlugin()
    {
        _fileReader = new FileReader();
        _wordExtractor = new WordExtractor();
        IConnectorWordProvider connectorWordProvider = new ConnectorWordProvider();
        _wordFilter = new WordFilter(connectorWordProvider);
        _wordCounter = new WordCounter();
    }

    public string Execute(string filePath)
    {
        var conteoPalabras = ContarPalabras(filePath);
        var sb = new StringBuilder();
        foreach (var resultado in conteoPalabras)
        {
            sb.AppendLine($"{resultado.Palabra}: {resultado.Cantidad}");
        }
        return sb.ToString();
    }

    private IEnumerable<WordCountResult> ContarPalabras(string filePath)
    {
        var contenido = _fileReader.ReadFile(filePath);
        var palabras = _wordExtractor.ExtractWords(contenido);
        var palabrasFiltradas = _wordFilter.FilterWords(palabras);
        return _wordCounter.CountWords(palabrasFiltradas);
    }
}