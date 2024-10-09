using IDE.Interfaces;
using IDE.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IDE.Services
{
    internal class PluginService : IPluginService
    {
        private readonly List<PluginWrapper> _loadedPlugins = new();

        public IEnumerable<PluginWrapper> LoadPlugins(string filePath)
        {
            var plugins = new List<PluginWrapper>();

            // Cargar el ensamblado
            var assembly = Assembly.LoadFrom(filePath);

            // Buscar tipos que cumplen con las convenciones
            var types = assembly.GetTypes().Where(t =>
                t is { IsClass: true, IsAbstract: false } &&
                t.Name.EndsWith("Plugin") &&
                t.GetMethod("Execute", [typeof(string)]) != null
            ).ToList();

            if (types.Count == 0)
                throw new InvalidOperationException("No se encontraron plugins válidos en el archivo seleccionado.");

            foreach (var type in types)
            {
                var pluginName = type.Name;
                if (IsPluginLoaded(pluginName))
                    throw new InvalidOperationException($"El plugin '{pluginName}' ya está cargado.");

                // Crear una instancia del plugin
                var pluginInstance = Activator.CreateInstance(type);

                // Crear el wrapper del plugin
                var pluginWrapper = new PluginWrapper
                {
                    PluginInstance = pluginInstance,
                    PluginType = type,
                    PluginName = pluginName
                };

                _loadedPlugins.Add(pluginWrapper);
                plugins.Add(pluginWrapper);
            }

            return plugins;
        }

        public bool IsPluginLoaded(string pluginName)
        {
            return _loadedPlugins.Any(p => p.PluginName == pluginName);
        }

        public void UnloadPlugin(string pluginName)
        {
            var plugin = _loadedPlugins.FirstOrDefault(p => p.PluginName == pluginName);
            if (plugin != null)
                _loadedPlugins.Remove(plugin);
            else
                throw new InvalidOperationException($"El plugin '{pluginName}' no está cargado.");
        }
    }
}
