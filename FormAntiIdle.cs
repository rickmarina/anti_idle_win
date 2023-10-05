using static WindowsNativeMethods;

namespace anti_idle_win;

public partial class FormAntiIdle : Form
{
    private System.Windows.Forms.Timer timer;
    private const int SECONDS_DELAY = 25;

    private POINT lastMousePosition;

    public FormAntiIdle()
    {
        InitializeComponent();

        lastMousePosition = MouseHelper.GetMouseCurrent();

        timer = new System.Windows.Forms.Timer(); 
        timer.Interval = SECONDS_DELAY * 1000; //25 secs
        timer.Tick += AntiIdleTimer_Tick;

        timer.Enabled = true;
    }

    private void AntiIdleTimer_Tick(object? sender, EventArgs e) {
        MessageBox.Show("Este código se ejecuta cada 25 segundos.");

        PowerHelper.ForceSystemAwake();

        //Check if current mouse position is the same that previous one, if so, then move the mouse to avoid idle
            var current = MouseHelper.GetMouseCurrent();

            if (current.x == lastMousePosition.x && current.y == lastMousePosition.y)
            {
                MouseHelper.MoveAndClick(0, 0);
                Console.WriteLine("anti idle");
            }

            lastMousePosition = current;
    }

}
