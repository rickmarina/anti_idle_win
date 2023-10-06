using System.Configuration;
using System.Drawing.Imaging;
using static WindowsNativeMethods;

namespace anti_idle_win;

public partial class FormAntiIdle : Form
{

    public const string TIMES_SAVED_TEXT = "# times saved from idle";
    public FormAntiIdle()
    {
        InitializeComponent();
    }

    // Main forms loads
    private void FormAntiIdle_Load(object sender, EventArgs e)
    {
        int seconds = IdleManagerSingleton.GetInstance().secondsDelay;
        numericUpDownSeconds.Value = seconds;

        PowerHelper.ForceSystemAwake();

        timerCheckIdle.Interval = IdleManagerSingleton.GetInstance().milisecsDelay();
        timerCheckIdle.Tick += AntiIdleTimer_Tick;
        timerCheckIdle.Enabled = true;

        //Aplicaciones abiertas 
        var windows = ScreenshotHelper.GetAllWindowHandleNames();
        comboBoxAplicaciones.DataSource = windows;

    }

    private void AntiIdleTimer_Tick(object? sender, EventArgs e)
    {
        //Check if current mouse position is the same that previous one, if so, then move the mouse to avoid idle
        var current = MouseHelper.GetMouseCurrent();

        if (IdleManagerSingleton.GetInstance().IsEqualCurrentWithLastMousePosition(current))
        {
            MouseHelper.MoveAndClick(0, 0);
            IdleManagerSingleton.GetInstance().timesIdle++; 
            lTimesSaved.Text = $"{IdleManagerSingleton.GetInstance().timesIdle} {TIMES_SAVED_TEXT}";
        }

        IdleManagerSingleton.GetInstance().UpdateLastMousePosition();
    }

   

    private void numericUpDownSeconds_ValueChanged(object sender, EventArgs e)
    {

        IdleManagerSingleton.GetInstance().secondsDelay = Math.Max(10, Convert.ToInt32(numericUpDownSeconds.Value));
        timerCheckIdle.Interval = IdleManagerSingleton.GetInstance().milisecsDelay();
    }

    private void bTakeScreenshot_Click(object sender, EventArgs e)
    {
        string application = comboBoxAplicaciones.Text;
        var img = ScreenshotHelper.GetBitmapScreenshot(application);

        string directory = $"{Environment.CurrentDirectory}\\screenshots\\";
        string filename = $"{directory}{application}.jpg";

        Directory.CreateDirectory(directory);

        img?.Save(filename, ImageFormat.Jpeg);
    }
}
