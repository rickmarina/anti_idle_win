using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    internal class ScreenshotHelper
    {
        public static Image? GetBitmapScreenshot(string processName)
        {
            Image? img = null;

            //https://ourcodeworld.com/articles/read/890/how-to-solve-csharp-exception-current-thread-must-be-set-to-single-thread-apartment-sta-mode-before-ole-calls-can-be-made-ensure-that-your-main-function-has-stathreadattribute-marked-on-it
            Thread t = new(() =>
            {
                IntPtr handle = GetWindowHandle(processName);

                //Check if window is minimized and show it if needed
                if (WindowsNativeMethods.IsIconic(handle))
                    WindowsNativeMethods.ShowWindowAsync(handle, WindowsNativeMethods.SHOWNORMAL);

                WindowsNativeMethods.SetForegroundWindow(handle);

                //ALT + PRINT SCREEN gets screenshot of focused window
                //See this article for key list
                //https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.sendkeys?view=windowsdesktop-6.0#remarks
                SendKeys.SendWait("%({PRTSC})");
                Thread.Sleep(200);

                //The GetImage function in WPF gets a bitmapsource image
                //This could be replaced with the Winforms getimage since that returns an image
                img = Clipboard.GetImage();

                //Uses the WindowsNativeMethods.dll to make sure the clipboard is empty and closed 
                //Without this you might get errors that the clipboard is already open
                IntPtr clipWindow = WindowsNativeMethods.GetOpenClipboardWindow();
                WindowsNativeMethods.OpenClipboard(clipWindow);
                WindowsNativeMethods.EmptyClipboard();
                WindowsNativeMethods.CloseClipboard();
                Thread.Sleep(100);
            });

            //Run your code from a thread that joins the STA Thread
            //If this is not done, clipboard functions won't work
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();

            return img;

        }

        public static List<string> GetAllWindowHandleNames()
        {
            List<string> windowHandleNames = new();
            foreach (Process window in Process.GetProcesses())
            {
                window.Refresh();
                if (window.MainWindowHandle != IntPtr.Zero && !string.IsNullOrEmpty(window.MainWindowTitle))
                    windowHandleNames.Add(window.ProcessName);
            }
            return windowHandleNames;
        }

        private static IntPtr GetWindowHandle(string name)
        {
            var process = Process.GetProcessesByName(name).FirstOrDefault();
            if (process != null && process.MainWindowHandle != IntPtr.Zero)
                return process.MainWindowHandle;

            return IntPtr.Zero;
        }

    }
