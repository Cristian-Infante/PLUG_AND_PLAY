using IDE.Wrappers;
using System.Reflection;
using IDE.Interfaces;

namespace IDE.UI;

public class MainForm : Form
{
    private TextBox? _txtArchivoInicial;
    private RichTextBox? _rtbArchivoProcesado;
    private RichTextBox? _txtSalidaMensajes;
    private string _filePath = string.Empty;
    private readonly List<PluginWrapper> _plugins = [];
    private GroupBox _groupBoxCargarComponente = null!;
    private Button _btnCargarPlugin = null!;
    private GroupBox _groupBoxComponentesCargados = null!;
    private Button _btnEliminarPlugin = null!;
    private GroupBox _groupBoxEjecutarComponente = null!;
    private Button _btnEjecutarComponente = null!;
    private GroupBox _groupBoxArchivoInicial = null!;
    private Button _btnCargarArchivoDer = null!;
    private GroupBox _groupBoxArchivoProcesado = null!;
    private GroupBox _groupBoxSalidaMensajes = null!;
    private ListBox? _lstComponentesCargados;
    private readonly IArchivoService _archivoService;
    private readonly IPluginService _pluginService;

    public MainForm(IArchivoService archivoService, IPluginService pluginService)
    {
        _archivoService = archivoService;
        _pluginService = pluginService;
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        _groupBoxCargarComponente = new GroupBox();
        _btnCargarPlugin = new Button();
        _groupBoxComponentesCargados = new GroupBox();
        _lstComponentesCargados = new ListBox();
        _btnEliminarPlugin = new Button();
        _groupBoxEjecutarComponente = new GroupBox();
        _btnEjecutarComponente = new Button();
        _groupBoxArchivoInicial = new GroupBox();
        _btnCargarArchivoDer = new Button();
        _txtArchivoInicial = new TextBox();
        _groupBoxArchivoProcesado = new GroupBox();
        _rtbArchivoProcesado = new RichTextBox();
        _groupBoxSalidaMensajes = new GroupBox();
        _txtSalidaMensajes = new RichTextBox();
        SuspendLayout();
        // 
        // groupBoxCargarComponente
        // 
        _groupBoxCargarComponente.Controls.Add(_btnCargarPlugin);
        _groupBoxCargarComponente.Location = new Point(20, 10);
        _groupBoxCargarComponente.Name = "_groupBoxCargarComponente";
        _groupBoxCargarComponente.Size = new Size(200, 60);
        _groupBoxCargarComponente.TabIndex = 0;
        _groupBoxCargarComponente.TabStop = false;
        _groupBoxCargarComponente.Text = @"Cargar componente";
        // 
        // btnCargarPlugin
        // 
        _btnCargarPlugin.Location = new Point(10, 20);
        _btnCargarPlugin.Name = "_btnCargarPlugin";
        _btnCargarPlugin.Size = new Size(180, 30);
        _btnCargarPlugin.TabIndex = 0;
        _btnCargarPlugin.Text = @"Cargar Plugin";
        _btnCargarPlugin.Click += CargarPlugin;
        // 
        // groupBoxComponentesCargados
        // 
        _groupBoxComponentesCargados.Controls.Add(_lstComponentesCargados);
        _groupBoxComponentesCargados.Controls.Add(_btnEliminarPlugin);
        _groupBoxComponentesCargados.Location = new Point(20, 80);
        _groupBoxComponentesCargados.Name = "_groupBoxComponentesCargados";
        _groupBoxComponentesCargados.Size = new Size(200, 450);
        _groupBoxComponentesCargados.TabIndex = 1;
        _groupBoxComponentesCargados.TabStop = false;
        _groupBoxComponentesCargados.Text = @"Componentes cargados";
        // 
        // _lstComponentesCargados
        // 
        _lstComponentesCargados.ItemHeight = 15;
        _lstComponentesCargados.Location = new Point(10, 20);
        _lstComponentesCargados.Name = "_lstComponentesCargados";
        _lstComponentesCargados.ScrollAlwaysVisible = true;
        _lstComponentesCargados.Size = new Size(180, 380);
        _lstComponentesCargados.TabIndex = 0;
        // 
        // btnEliminarPlugin
        // 
        _btnEliminarPlugin.Location = new Point(10, 410);
        _btnEliminarPlugin.Name = "_btnEliminarPlugin";
        _btnEliminarPlugin.Size = new Size(180, 30);
        _btnEliminarPlugin.TabIndex = 1;
        _btnEliminarPlugin.Text = @"Eliminar Plugin";
        _btnEliminarPlugin.Click += EliminarPlugin;
        // 
        // groupBoxEjecutarComponente
        // 
        _groupBoxEjecutarComponente.Controls.Add(_btnEjecutarComponente);
        _groupBoxEjecutarComponente.Location = new Point(20, 540);
        _groupBoxEjecutarComponente.Name = "_groupBoxEjecutarComponente";
        _groupBoxEjecutarComponente.Size = new Size(200, 60);
        _groupBoxEjecutarComponente.TabIndex = 2;
        _groupBoxEjecutarComponente.TabStop = false;
        _groupBoxEjecutarComponente.Text = @"Ejecutar componente";
        // 
        // btnEjecutarComponente
        // 
        _btnEjecutarComponente.Location = new Point(10, 20);
        _btnEjecutarComponente.Name = "_btnEjecutarComponente";
        _btnEjecutarComponente.Size = new Size(180, 30);
        _btnEjecutarComponente.TabIndex = 0;
        _btnEjecutarComponente.Text = @"Ejecutar plugin";
        _btnEjecutarComponente.Click += EjecutarPlugin;
        // 
        // groupBoxArchivoInicial
        // 
        _groupBoxArchivoInicial.Controls.Add(_btnCargarArchivoDer);
        _groupBoxArchivoInicial.Controls.Add(_txtArchivoInicial);
        _groupBoxArchivoInicial.Location = new Point(240, 10);
        _groupBoxArchivoInicial.Name = "_groupBoxArchivoInicial";
        _groupBoxArchivoInicial.Size = new Size(990, 270);
        _groupBoxArchivoInicial.TabIndex = 3;
        _groupBoxArchivoInicial.TabStop = false;
        _groupBoxArchivoInicial.Text = @"Archivo Inicial";
        // 
        // btnCargarArchivoDer
        // 
        _btnCargarArchivoDer.Location = new Point(804, 20);
        _btnCargarArchivoDer.Name = "_btnCargarArchivoDer";
        _btnCargarArchivoDer.Size = new Size(180, 30);
        _btnCargarArchivoDer.TabIndex = 0;
        _btnCargarArchivoDer.Text = @"Cargar Archivo";
        _btnCargarArchivoDer.Click += CargarArchivo;
        // 
        // _txtArchivoInicial
        // 
        _txtArchivoInicial.Location = new Point(10, 60);
        _txtArchivoInicial.Multiline = true;
        _txtArchivoInicial.Name = "_txtArchivoInicial";
        _txtArchivoInicial.ReadOnly = true;
        _txtArchivoInicial.ScrollBars = ScrollBars.Both;
        _txtArchivoInicial.Size = new Size(980, 200);
        _txtArchivoInicial.TabIndex = 1;
        // 
        // groupBoxArchivoProcesado
        // 
        _groupBoxArchivoProcesado.Controls.Add(_rtbArchivoProcesado);
        _groupBoxArchivoProcesado.Location = new Point(240, 290);
        _groupBoxArchivoProcesado.Name = "_groupBoxArchivoProcesado";
        _groupBoxArchivoProcesado.Size = new Size(990, 310);
        _groupBoxArchivoProcesado.TabIndex = 4;
        _groupBoxArchivoProcesado.TabStop = false;
        _groupBoxArchivoProcesado.Text = @"Archivo Procesado";
        // 
        // _rtbArchivoProcesado
        // 
        _rtbArchivoProcesado.Location = new Point(10, 20);
        _rtbArchivoProcesado.Name = "_rtbArchivoProcesado";
        _rtbArchivoProcesado.ReadOnly = true;
        _rtbArchivoProcesado.Size = new Size(980, 280);
        _rtbArchivoProcesado.ScrollBars = RichTextBoxScrollBars.Both;
        _rtbArchivoProcesado.TabIndex = 0;
        _rtbArchivoProcesado.Text = "";
        // 
        // groupBoxSalidaMensajes
        // 
        _groupBoxSalidaMensajes.Controls.Add(_txtSalidaMensajes);
        _groupBoxSalidaMensajes.Location = new Point(20, 610);
        _groupBoxSalidaMensajes.Name = "_groupBoxSalidaMensajes";
        _groupBoxSalidaMensajes.Size = new Size(1210, 180);
        _groupBoxSalidaMensajes.TabIndex = 5;
        _groupBoxSalidaMensajes.TabStop = false;
        _groupBoxSalidaMensajes.Text = @"Salida de mensajes";
        // 
        // _txtSalidaMensajes
        // 
        _txtSalidaMensajes.Location = new Point(10, 20);
        _txtSalidaMensajes.Name = "_txtSalidaMensajes";
        _txtSalidaMensajes.ReadOnly = true;
        _txtSalidaMensajes.Size = new Size(1200, 150);
        _txtSalidaMensajes.ScrollBars = RichTextBoxScrollBars.Vertical;
        _txtSalidaMensajes.TabIndex = 0;
        _txtSalidaMensajes.Text = "";
        // 
        // MainForm
        // 
        ClientSize = new Size(1250, 800);
        Controls.Add(_groupBoxCargarComponente);
        Controls.Add(_groupBoxComponentesCargados);
        Controls.Add(_groupBoxEjecutarComponente);
        Controls.Add(_groupBoxArchivoInicial);
        Controls.Add(_groupBoxArchivoProcesado);
        Controls.Add(_groupBoxSalidaMensajes);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        Name = "MainForm";
        Text = @"Editor de Texto";
        ResumeLayout(false);
    }

    // Método para cargar el archivo y mostrar el contenido en _txtArchivoInicial
    private void CargarArchivo(object? sender, EventArgs e)
    {
        using var openFileDialog = new OpenFileDialog();
        openFileDialog.Title = @"Cargar Archivo";
        openFileDialog.Filter = @"Text and Code files (*.txt;*.java;*.cpp;*.cs;*.sql)|*.txt;*.java;*.cpp;*.cs;*.sql";
        openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        if (openFileDialog.ShowDialog() != DialogResult.OK) return;
        try
        {
            _filePath = openFileDialog.FileName;
            MostrarMensaje($"Cargando archivo desde: {_filePath}", Color.Black);

            var fileContent = _archivoService.ReadFile(_filePath);

            _txtArchivoInicial!.Text = fileContent;
            MostrarMensaje($"Archivo '{Path.GetFileName(_filePath)}' cargado exitosamente.", Color.Green);
            _rtbArchivoProcesado!.Clear();
        }
        catch (Exception ex)
        {
            MostrarError($"Error al cargar el archivo: {ex.Message}");
        }
    }

    // Método para cargar un plugin y mostrarlo en _lstComponentesCargados
    private void CargarPlugin(object? sender, EventArgs e)
    {
        using var openFileDialog = new OpenFileDialog();
        openFileDialog.Title = @"Cargar Plugin";
        openFileDialog.Filter = @"DLL files (*.dll)|*.dll";
        openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        if (openFileDialog.ShowDialog() != DialogResult.OK) return;

        try
        {
            var filePath = openFileDialog.FileName;
            MostrarMensaje($"Cargando plugin desde: {filePath}", Color.Black);

            // Usar el servicio para cargar los plugins
            var loadedPlugins = _pluginService.LoadPlugins(filePath);

            foreach (var plugin in loadedPlugins)
            {
                // Agregar el plugin a la lista local
                _plugins.Add(plugin);

                _lstComponentesCargados!.Items.Add(plugin.PluginName!);
                MostrarMensaje($"Plugin '{plugin.PluginName}' cargado exitosamente.", Color.Green);
            }
        }
        catch (Exception ex)
        {
            MostrarError($"Error al cargar el plugin: {ex.Message}");
        }
    }

    // Método para ejecutar un plugin seleccionado en _lstComponentesCargados
    private void EjecutarPlugin(object? sender, EventArgs e)
    {
        if (_lstComponentesCargados!.SelectedItem == null)
        {
            MostrarError("Por favor, seleccione un plugin para ejecutar.");
            return;
        }

        if (string.IsNullOrEmpty(_filePath))
        {
            MostrarError("No hay un archivo cargado para procesar.");
            return;
        }

        var pluginName = _lstComponentesCargados.SelectedItem.ToString();
        var pluginWrapper = _plugins.FirstOrDefault(p => p.PluginName == pluginName);

        if (pluginWrapper == null)
        {
            MostrarError("Plugin no encontrado.");
            return;
        }

        try
        {
            // Invocar el método 'Execute' utilizando reflexión
            var method = pluginWrapper.PluginType!.GetMethod("Execute", [typeof(string)]);
            if (method != null)
            {
                var resultado = (string)method.Invoke(pluginWrapper.PluginInstance, [_filePath])!;

                if (_rtbArchivoProcesado != null)
                {
                    if (EsRtf(resultado))
                        _rtbArchivoProcesado.Rtf = resultado;
                    else
                        _rtbArchivoProcesado.Text = resultado;
                }

                MostrarMensaje($"Plugin '{pluginWrapper.PluginName}' ejecutado exitosamente.", Color.Green);
            }
            else
            {
                MostrarError($"El plugin '{pluginWrapper.PluginName}' no tiene un método 'Execute' válido.");
            }
        }
        catch (TargetInvocationException tiex)
        {
            // Mostrar el mensaje de la excepción interna si existe
            MostrarError(tiex.InnerException != null
                ? $"Error al ejecutar el plugin: {tiex.InnerException.Message}"
                : $"Error al ejecutar el plugin: {tiex.Message}");
        }
        catch (Exception ex)
        {
            MostrarError($"Error inesperado al ejecutar el plugin: {ex.Message}");
        }
    }

    // Método para verificar si el texto es RTF (Formato de Texto Enriquecido)
    private static bool EsRtf(string text)
    {
        return !string.IsNullOrEmpty(text) && text.TrimStart().StartsWith(@"{\rtf");
    }

    // Método para eliminar un plugin seleccionado en _lstComponentesCargados
    private void EliminarPlugin(object? sender, EventArgs e)
    {
        if (_lstComponentesCargados!.SelectedItem == null)
        {
            MostrarError("Por favor, seleccione un plugin para eliminar.");
            return;
        }

        var pluginName = _lstComponentesCargados.SelectedItem.ToString();

        try
        {
            _pluginService.UnloadPlugin(pluginName!);
            var plugin = _plugins.FirstOrDefault(p => p.PluginName == pluginName);
            if (plugin != null)
            {
                _plugins.Remove(plugin);
                _lstComponentesCargados.Items.Remove(pluginName!);
                MostrarMensaje($"Plugin '{pluginName}' eliminado.", Color.Black);
            }
            else
            {
                MostrarError("Plugin no encontrado en la lista local.");
            }
        }
        catch (Exception ex)
        {
            MostrarError($"Error al eliminar el plugin: {ex.Message}");
        }
    }

    // Método para mostrar mensajes en el RichTextBox _txtSalidaMensajes
    private void MostrarMensaje(string mensaje, Color color)
    {
        if (_txtSalidaMensajes == null) return;
        _txtSalidaMensajes.SelectionStart = _txtSalidaMensajes.Text.Length;
        _txtSalidaMensajes.SelectionColor = color;
        _txtSalidaMensajes.AppendText($"[{DateTime.Now:T}] {mensaje}{Environment.NewLine}");
        _txtSalidaMensajes.SelectionColor = _txtSalidaMensajes.ForeColor;
        _txtSalidaMensajes.ScrollToCaret();
    }

    // Método para mostrar mensajes de error
    private void MostrarError(string mensaje)
    {
        if (_txtSalidaMensajes == null) return;
        _txtSalidaMensajes.SelectionStart = _txtSalidaMensajes.Text.Length;
        _txtSalidaMensajes.SelectionColor = Color.Red;
        _txtSalidaMensajes.AppendText($"[{DateTime.Now:T}] {mensaje}{Environment.NewLine}");
        _txtSalidaMensajes.SelectionColor = _txtSalidaMensajes.ForeColor;
        _txtSalidaMensajes.ScrollToCaret();
    }
}