using IDE.Wrappers;

namespace IDE.Interfaces;

public interface IPluginService
{
    IEnumerable<PluginWrapper> LoadPlugins(string filePath);
    bool IsPluginLoaded(string pluginName);
    void UnloadPlugin(string pluginName);
}
