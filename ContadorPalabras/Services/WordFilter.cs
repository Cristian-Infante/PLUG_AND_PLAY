using ContadorPalabras.Interfaces;

namespace ContadorPalabras.Services;

public class WordFilter(IConnectorWordProvider connectorWordProvider) : IWordFilter
{
    private readonly HashSet<string> _stopWords = connectorWordProvider.GetConnectorWords();

    public IEnumerable<string> FilterWords(IEnumerable<string> words)
    {
        return words
            .Where(word => !_stopWords.Contains(word) && word.All(char.IsLetter) && word.Length > 1);
    }
}