namespace ContadorPalabras.Interfaces;

public interface IConnectorWordProvider
{
    HashSet<string> GetConnectorWords();
}