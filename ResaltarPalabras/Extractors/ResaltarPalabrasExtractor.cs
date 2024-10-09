using ResaltarPalabras.Interfaces;
using System.Text.RegularExpressions;

namespace ResaltarPalabras.Extractors;

public partial class ResaltarPalabrasExtractor(ILanguageDetector languageDetector) : IResaltarPalabrasExtractor
{
    public HashSet<string> ExtractReservedWords(string content)
    {
        var language = languageDetector.DetectLanguage(content);
        var reservedWords = language.ReservedWords;

        // Extraer todas las palabras del contenido usando una expresión regular
        var words = MyRegex().Matches(content)
            .Cast<Match>()
            .Select(m => m.Value)
            .ToHashSet(System.StringComparer.OrdinalIgnoreCase);

        // Intersectar con las palabras reservadas del lenguaje
        return new HashSet<string>(words.Intersect(reservedWords, System.StringComparer.OrdinalIgnoreCase), System.StringComparer.OrdinalIgnoreCase);
    }

    [GeneratedRegex(@"\b\w+\b")]
    private static partial Regex MyRegex();
}
