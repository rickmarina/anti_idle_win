using System.Configuration;
using static WindowsNativeMethods;

internal class IdleManagerSingleton
{

    private static volatile IdleManagerSingleton? _instance;
    private static readonly object _lock = new object();
    public int timesIdle { get; set; }
    public int secondsDelay { get; set; }
    public int milisecsDelay() => secondsDelay * 1000;
    
    private POINT lastMousePosition;


    public static IdleManagerSingleton GetInstance()
    {

        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                    _instance = new IdleManagerSingleton();
            }
        }

        return _instance;
    }

    private IdleManagerSingleton() { 
        this.secondsDelay = Convert.ToInt32(ConfigurationManager.AppSettings["DEFAULT_CHECK_TIME"]?.ToString());
        UpdateLastMousePosition();
    }

    public void UpdateLastMousePosition()
    {
        this.lastMousePosition = MouseHelper.GetMouseCurrent();
    }

    public bool IsEqualCurrentWithLastMousePosition(POINT current)
    {
        return (current.x == lastMousePosition.x && current.y == lastMousePosition.y);
    }


}
