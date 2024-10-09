using ContadorPalabras.Interfaces;
using ContadorPalabras.Models;

namespace ContadorPalabras.Services;

public class WordCounter : IWordCounter
{
    public IEnumerable<WordCountResult> CountWords(IEnumerable<string> words)
    {
        return words
            .GroupBy(w => w)
            .Select(g => new WordCountResult
            {
                Palabra = g.Key,
                Cantidad = g.Count()
            });
    }
}