using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    class ProcessInfo : IProcessInfo
    {
        #region Properties
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime StartTime { get; set; }
        #endregion

        #region Constructors
        public ProcessInfo()
        {
            Name = "Default";
            Duration = new TimeSpan();
            StartTime = DateTime.Now;
        }
        public ProcessInfo(string name, TimeSpan time)
        {
            Name = name;
            Duration = time;
            StartTime = DateTime.Now;
        }
        #endregion
        public void Sum(ProcessInfo left)
        {
            if (Name.Equals(left.Name) && StartTime.Equals(left.StartTime))
                Duration += left.Duration;
        }
        public void SetRecord(string name, TimeSpan duration, DateTime processStartTime){
        Name =name;
        Duration = duration;
        StartTime = processStartTime;
        }
        public override string ToString()
        {
            return "Process: " + Name + "\tbegin in: " + StartTime + "\twith duration: " + Duration + ".\n";
        }
        static public implicit operator ProcessInfoCategory<ProcessInfo>(ProcessInfo record)
        {
            return new ProcessInfoCategory<ProcessInfo>(record);
        }
    }
}
