using System;
using TimeTrackLibrary.Interfaces;

namespace TimeTrackLibrary.Classes
{
    [Serializable]
    public class ProcessSession : IProcessSession, IComparable<ProcessSession>,IEquatable<ProcessSession>
    {
        public string ProcessName
        {
            get;
            set;
        }

        public string WindowTitle
        {
            get;
            set;
        }

        public DateTime StartAt
        {
            get;
            set;
        }

        public TimeSpan Duration
        {
            get;
            set;
        }


        public bool IsSameProcessAs(ProcessSession other)
        {
            return (ProcessName == other.ProcessName && WindowTitle == other.WindowTitle);
        }


        public bool HaveSameProcessNameAndWindowTitle(IProcessSession other)
        {
            return IsSameProcessAs((ProcessSession)other);
        }
        public override string ToString()
        {
            return "Process Name: " + ProcessName + "\t Window Title: " + WindowTitle + "\t Start At: " + StartAt.ToString() + "\t Duration: " + Duration.ToString() + "\n";
        }
        public ProcessSession(string processName, string windowTitle, DateTime startAt, TimeSpan duration)
        {
            ProcessName = processName;
            WindowTitle = windowTitle;
            StartAt = startAt;
            Duration = duration;
        }

        public ProcessSession()
        {

        }


        public int CompareTo(ProcessSession other)
        {
            int result = -1;
            if (StartAt > other.StartAt)
                result = 1;
            else
                if (ProcessName == other.ProcessName &&
                        WindowTitle == other.WindowTitle &&
                        Duration == other.Duration &&
                        StartAt == other.StartAt)
                    result = 0;

            return result;
        }

        public bool Equals(ProcessSession other)
        {
            return ProcessName == other.ProcessName &&
                        WindowTitle == other.WindowTitle &&
                        Duration == other.Duration &&
                        StartAt == other.StartAt;
        }
    }
}
