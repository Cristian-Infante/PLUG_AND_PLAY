namespace IDE.Wrappers;

// Clase para envolver los plugins y poder mostrarlos en la interfaz
public class PluginWrapper
{
    public object? PluginInstance { get; init; }
    public Type? PluginType { get; init; }
    public string? PluginName { get; init; }
}
