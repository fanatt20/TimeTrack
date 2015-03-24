using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeTrackLibrary.Interfaces;

namespace TimeTrackLibrary.Classes
{
    public class ProcessSession : IProcessSession
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


        public bool IsSameProcessAs(IProcessSession other)
        {
            return IsSameProcessAs((ProcessSession)other);
        }
        public override string ToString()
        {
            return "Process Name: " + ProcessName + "\t Window Title: " + WindowTitle + "\t Start At: " + StartAt.ToString() + "\t Duration: " + Duration.ToString()+"\n";
        }
    }
}
