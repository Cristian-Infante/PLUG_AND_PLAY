using ContadorPalabras.Interfaces;
using System.Text.RegularExpressions;

namespace ContadorPalabras.Services;

public partial class WordExtractor : IWordExtractor
{
    public IEnumerable<string> ExtractWords(string content)
    {
        // Utiliza una expresión regular para extraer palabras, excluyendo caracteres especiales
        var matches = MyRegex().Matches(content);
        return matches.Select(m => m.Value.ToLower());
    }

    [GeneratedRegex(@"\b\w+\b")]
    private static partial Regex MyRegex();
}