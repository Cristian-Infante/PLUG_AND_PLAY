using IDE.Interfaces;
using IDE.Services;
using IDE.UI;

namespace IDE
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Crear instancias de los servicios manualmente
            IArchivoService archivoService = new ArchivoService();
            IPluginService pluginService = new PluginService();

            // Crear una instancia del formulario principal, pasando los servicios necesarios
            var mainForm = new MainForm(archivoService, pluginService);

            Application.Run(mainForm);
        }
    }
}
