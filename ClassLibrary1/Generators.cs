using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

using ClassLibrary1;

namespace ClassLibrary1
{
    public class ProcessInfoGenerator : IProcessInfoGenerator
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
        [DllImport("user32", SetLastError = true)]
        internal static extern int GetWindowThreadProcessId([In]IntPtr hwnd, [Out]out int lProcessId);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        public int GetCurrentProcessId()
        {
            int lProcessId;
            IntPtr handle = GetForegroundWindow();
            GetWindowThreadProcessId(handle, out lProcessId);
            return lProcessId;
        }
        public string GetCurrentProcessName()
        {
            return Process.GetProcessById(GetCurrentProcessId()).ProcessName;
        }
        public TimeSpan GetCurrentProcessTime()
        {
            return Process.GetProcessById(GetCurrentProcessId()).UserProcessorTime;
        }
        public string GetCurrentProcessTitle()
        {

            IntPtr handle = GetForegroundWindow();
            int lProcessId;
            GetWindowThreadProcessId(handle, out lProcessId);
            var pr = Process.GetProcessById(lProcessId);
            var result = "";
            // get title
            const int count = 512;
            var text = new StringBuilder(count);

            if (GetWindowText(handle, text, count) > 0)
            {
                result += "\n" + text.ToString();
            }

            return result;

            //return Process.GetProcessById(GetCurrentProcessId()).MainWindowTitle;
        }
        public bool GetStartTimeOfCurrentProcess(out DateTime dateTime)
        {
            bool result = true;
            dateTime = new DateTime();
            try
            {
                //need test stability of this method
                dateTime = Process.GetProcessById(GetCurrentProcessId()).StartTime;
            }
            catch
            {
                result = false;
            }
            return result;
        }
    }

}
