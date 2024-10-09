using ContadorPalabras.Models;

namespace ContadorPalabras.Interfaces;

public interface IWordCounter
{
    IEnumerable<WordCountResult> CountWords(IEnumerable<string> words);
}