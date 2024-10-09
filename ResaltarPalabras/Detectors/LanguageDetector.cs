using ResaltarPalabras.Interfaces;

namespace ResaltarPalabras.Detectors;

public class LanguageDetector(IEnumerable<ILanguage> languages) : ILanguageDetector
{
    private readonly List<ILanguage> _languages = languages.ToList();

    public ILanguage DetectLanguage(string content)
    {
        foreach (var language in _languages.Where(language => language.IsMatch(content)))
        {
            return language;
        }

        throw new Exception("El lenguaje del archivo no es soportado.");
    }
}