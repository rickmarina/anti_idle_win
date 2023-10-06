using System.Drawing.Imaging;
using static WindowsNativeMethods;

namespace anti_idle_win;

public partial class FormAntiIdle : Form
{
    private int SECONDS_DELAY = 10;
    private POINT lastMousePosition;

    public FormAntiIdle()
    {
        InitializeComponent();
    }

    private void AntiIdleTimer_Tick(object? sender, EventArgs e)
    {
        //Check if current mouse position is the same that previous one, if so, then move the mouse to avoid idle
        var current = MouseHelper.GetMouseCurrent();

        if (current.x == lastMousePosition.x && current.y == lastMousePosition.y)
        {
            MouseHelper.MoveAndClick(0, 0);
            MessageBox.Show("antiidle");
        }

        lastMousePosition = current;
    }

    private void FormAntiIdle_Load(object sender, EventArgs e)
    {
        numericUpDownSeconds.Value = SECONDS_DELAY;

        lastMousePosition = MouseHelper.GetMouseCurrent();

        PowerHelper.ForceSystemAwake();

        timerCheckIdle.Interval = SECONDS_DELAY * 1000;
        timerCheckIdle.Tick += AntiIdleTimer_Tick;

        timerCheckIdle.Enabled = true;

        //Aplicaciones abiertas 
        var windows = ScreenshotHelper.GetAllWindowHandleNames();
        comboBoxAplicaciones.DataSource = windows;

    }

    private void numericUpDownSeconds_ValueChanged(object sender, EventArgs e)
    {
        SECONDS_DELAY = Convert.ToInt32(numericUpDownSeconds.Value);
        timerCheckIdle.Interval = SECONDS_DELAY * 1000;
    }

    private void bTakeScreenshot_Click(object sender, EventArgs e)
    {
        string application = comboBoxAplicaciones.Text;
        var img = ScreenshotHelper.GetBitmapScreenshot(application);

        string filename = $"c:\\temp\\{application}.jpg";
        
        img?.Save(filename, ImageFormat.Jpeg);
    }
}
