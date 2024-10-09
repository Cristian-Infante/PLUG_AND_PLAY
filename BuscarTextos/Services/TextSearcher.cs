using BuscarTextos.Interfaces;
using BuscarTextos.Models;
using System.Text.RegularExpressions;

namespace BuscarTextos.Services;

public class TextSearcher : ITextSearcher
{
    public IEnumerable<SearchResult> Search(string content, string word)
    {
        var results = new List<SearchResult>();
        var pattern = $@"\b{Regex.Escape(word)}\b"; // Coincidencia exacta de la palabra
        var regex = new Regex(pattern, RegexOptions.IgnoreCase);

        using (var reader = new StringReader(content))
        {
            var lineNumber = 0;

            while (reader.ReadLine() is { } line)
            {
                lineNumber++;
                foreach (Match match in regex.Matches(line))
                {
                    var columnNumber = match.Index + 1;
                    results.Add(new SearchResult
                    {
                        Line = lineNumber,
                        Column = columnNumber
                    });
                }
            }
        }
        if (results.Count == 0)
        {
            throw new Exception($"La palabra '{word}' no se encontró en el texto.");
        }
        return results;
    }
}