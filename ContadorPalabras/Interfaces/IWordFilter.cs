namespace ContadorPalabras.Interfaces;

public interface IWordFilter
{
    IEnumerable<string> FilterWords(IEnumerable<string> words);
}