namespace ContadorPalabras.Interfaces;

public interface IWordExtractor
{
    IEnumerable<string> ExtractWords(string content);
}