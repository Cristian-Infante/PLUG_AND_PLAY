using ContadorPalabras.Interfaces;

namespace ContadorPalabras.Services;

public class ConnectorWordProvider : IConnectorWordProvider
{
    private readonly HashSet<string> _connectorWords =
    [
        "y", "o", "pero", "porque", "aunque", "si", "cuando", "donde", "como", "más", "menos", "hasta", "desde", "entre", "hasta", "con", "sin", "sobre", "tras", "durante", "para", "por", "ante", "bajo", "cabe", "excepto", "salvo", "según", "segun", "tras", "versus", "vs", "v", "además", "así", "aún", "bien", "casi", "cuyo", "de", "del", "al", "el", "la", "los", "las", "un", "una", "unos", "unas", "es", "son", "fue", "fueron", "tiene", "tienen", "tengo", "tienes", "tenemos"
    ];

    public HashSet<string> GetConnectorWords() => _connectorWords;
}