namespace ResaltarPalabras.Interfaces;

public interface IResaltarPalabrasExtractor
{
    HashSet<string> ExtractReservedWords(string content);
}