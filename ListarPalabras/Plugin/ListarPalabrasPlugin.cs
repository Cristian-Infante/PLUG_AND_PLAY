using ListarPalabras.Interfaces;
using ListarPalabras.Models;
using ListarPalabras.Services;
using System.Text;

namespace ListarPalabras.Plugin;

public class ListarPalabrasPlugin : IPlugin
{
    private readonly FileReader _fileReader = new();
    private readonly WordExtractor _wordExtractor = new();
    private readonly WordFilter _wordFilter = new();

    public string Execute(string filePath)
    {
        var wordList = GetUniqueWords(filePath);
        var sb = new StringBuilder();
        foreach (var word in wordList.Words.OrderBy(w => w))
        {
            sb.AppendLine(word);
        }
        return sb.ToString();
    }

    private WordList GetUniqueWords(string filePath)
    {
        var content = _fileReader.ReadFile(filePath);
        var words = _wordExtractor.ExtractWords(content);
        var filteredWords = _wordFilter.FilterWords(words);

        return new WordList(filteredWords);
    }
}