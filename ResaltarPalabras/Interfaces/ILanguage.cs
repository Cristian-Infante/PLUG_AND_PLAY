namespace ResaltarPalabras.Interfaces;

public interface ILanguage
{
    string Name { get; }
    HashSet<string> ReservedWords { get; }
    bool IsMatch(string content);
}
