using System.ComponentModel;

namespace BuscarTextos.UI;

public class InputForm : Form
{
    private readonly IContainer? components = null;
    private Label _lblPrompt = null!;
    private TextBox _txtInput = null!;
    private Button _btnAceptar = null!;
    private Button _btnCancelar = null!;
    public string InputText { get; private set; } = null!;

    public InputForm()
    {
        InitializeComponent();
    }

    private void btnAceptar_Click(object sender, EventArgs e)
    {
        InputText = _txtInput.Text;
        DialogResult = DialogResult.OK;
        Close();
    }

    private void btnCancelar_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        _lblPrompt = new Label();
        _txtInput = new TextBox();
        _btnAceptar = new Button();
        _btnCancelar = new Button();
        SuspendLayout();
        // 
        // lblPrompt
        // 
        _lblPrompt.AutoSize = true;
        _lblPrompt.Location = new Point(12, 9);
        _lblPrompt.Name = "_lblPrompt";
        _lblPrompt.Size = new Size(154, 13);
        _lblPrompt.TabIndex = 0;
        _lblPrompt.Text = "Ingrese la palabra a buscar:";
        // 
        // txtInput
        // 
        _txtInput.Location = new Point(15, 25);
        _txtInput.Name = "_txtInput";
        _txtInput.Size = new Size(257, 20);
        _txtInput.TabIndex = 1;
        // 
        // btnAceptar
        // 
        _btnAceptar.Location = new Point(116, 51);
        _btnAceptar.Name = "_btnAceptar";
        _btnAceptar.Size = new Size(75, 23);
        _btnAceptar.TabIndex = 2;
        _btnAceptar.Text = "Aceptar";
        _btnAceptar.UseVisualStyleBackColor = true;
        _btnAceptar.Click += new System.EventHandler(btnAceptar_Click!);
        // 
        // btnCancelar
        // 
        _btnCancelar.Location = new Point(197, 51);
        _btnCancelar.Name = "_btnCancelar";
        _btnCancelar.Size = new Size(75, 23);
        _btnCancelar.TabIndex = 3;
        _btnCancelar.Text = "Cancelar";
        _btnCancelar.UseVisualStyleBackColor = true;
        _btnCancelar.Click += new System.EventHandler(btnCancelar_Click!);
        // 
        // InputForm
        // 
        AcceptButton = _btnAceptar;
        CancelButton = _btnCancelar;
        ClientSize = new Size(284, 86);
        Controls.Add(_btnCancelar);
        Controls.Add(_btnAceptar);
        Controls.Add(_txtInput);
        Controls.Add(_lblPrompt);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "InputForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Buscar Palabra";
        ResumeLayout(false);
        PerformLayout();
    }
}