using Gma.System.MouseKeyHook;

namespace CardCapture;

public partial class Form1 : Form
{
    private readonly IKeyboardMouseEvents _keyboardMouseEvents;

    private readonly TextBox _textBox = new TextBox();
    public Form1()
    {
        InitializeComponent();
        _keyboardMouseEvents = Hook.GlobalEvents();
        _keyboardMouseEvents.MouseDownExt += GlobalHookMouseDownExt;

        _textBox.Multiline = true;
        _textBox.Dock = DockStyle.Fill;
        Controls.Add(_textBox);
    }
private void GlobalHookMouseDownExt(object sender, MouseEventExtArgs e)
    {
        // Verifica se o CTRL e o mouse foi pressionado dentro da tela do jogo
        if (ModifierKeys == Keys.Control && e.Button == MouseButtons.Left &&
            e.X >= 393 && e.Y >= 138 && e.X <= 833 && e.Y <= 562)
        {
            CardScreenshot screenshot = new CardScreenshot(e);

            screenshot.TakeScreenShot();

            _textBox.Text = $"Clique do mouse em X = {e.X}, Y = {e.Y}" + Environment.NewLine;
            return;
        }

        _textBox.Text += $"Clique simples ou fora do tabuleiro do mouse em X = {e.X}, Y = {e.Y}" + Environment.NewLine;
    }
}