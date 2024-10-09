using ListarPalabras.Interfaces;
using System.Text.RegularExpressions;

namespace ListarPalabras.Services;

public partial class WordExtractor : IWordExtractor
{
    public IEnumerable<string> ExtractWords(string content)
    {
        var coincidences = MyRegex().Matches(content);
        return coincidences.Select(c => c.Value.ToLower());
    }

    [GeneratedRegex(@"\b\w+\b")]
    private static partial Regex MyRegex();
}