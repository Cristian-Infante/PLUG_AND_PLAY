using BuscarTextos.Models;

namespace BuscarTextos.Interfaces;

public interface ITextSearcher
{
    IEnumerable<SearchResult> Search(string content, string word);
}