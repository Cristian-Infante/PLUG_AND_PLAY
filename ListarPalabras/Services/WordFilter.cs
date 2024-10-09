using ListarPalabras.Interfaces;

namespace ListarPalabras.Services;

public class WordFilter() : IWordFilter
{

    public IEnumerable<string> FilterWords(IEnumerable<string> words)
    {
        return words.Where(word => word.All(char.IsLetter) && word.Length > 1);
    }
}