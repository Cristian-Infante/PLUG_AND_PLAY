namespace ResaltarPalabras.Interfaces;

public interface ILanguageDetector
{
    ILanguage DetectLanguage(string content);
}