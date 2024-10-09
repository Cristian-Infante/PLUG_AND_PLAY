namespace ListarPalabras.Interfaces;

public interface IWordExtractor
{
    IEnumerable<string> ExtractWords(string content);
}