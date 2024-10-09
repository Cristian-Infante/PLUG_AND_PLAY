namespace ListarPalabras.Models;

public class WordList(IEnumerable<string> words)
{
    public HashSet<string> Words { get; } = [.. words];
}