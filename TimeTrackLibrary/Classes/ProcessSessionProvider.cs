using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using TimeTrackLibrary.Interfaces;

namespace TimeTrackLibrary.Classes
{
    public sealed class ProcessSessionProvider : IProcessSessionProvider
    {
        public IProcessSession GetCurrentProcessSession()
        {
            var handle = GetForegroundWindow();
            int lProcessId;
            GetWindowThreadProcessId(handle, out lProcessId);

            var currentProcess = Process.GetProcessById(lProcessId);
            var currentProcessWindowTitle = "";

            const int count = 512;
            var text = new StringBuilder(count);
            if (GetWindowText(handle, text, count) > 0)
            {
                currentProcessWindowTitle += text.ToString();
            }
            IProcessSession result = new ProcessSession
            {
                WindowTitle = currentProcessWindowTitle,
                ProcessName = currentProcess.ProcessName
            };
            return result;
        }

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32", SetLastError = true)]
        internal static extern int GetWindowThreadProcessId([In] IntPtr hwnd, [Out] out int lProcessId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);
    }
}