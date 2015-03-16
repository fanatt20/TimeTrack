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
    class ProcessInfoGenerator : IProcessInfoGenerator
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
        [DllImport("user32", SetLastError = true)]
        internal static extern int GetWindowThreadProcessId([In]IntPtr hwnd, [Out]out int lProcessId);

        public new int GetCurrentProcessId()
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
            return Process.GetProcessById(GetCurrentProcessId()).MainWindowTitle;
        }
        public bool GetStartTimeOfCurrentProcess(out DateTime dateTime)
        {
            bool result=true;
            dateTime = new DateTime();
            try
            {
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
