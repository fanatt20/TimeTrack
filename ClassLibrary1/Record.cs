using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeTrackLibrary
{
    public class ProcessInfo : IProcessInfo
    {
        #region Properties
        public string Name { get; set; }
        SortedList<DateTime, TimeSpan> lst;

        #endregion

        #region Constructors
        public ProcessInfo()
        {
            Name = "Default";
            lst = new SortedList<DateTime, TimeSpan>();
            lst.Add(DateTime.Now, new TimeSpan());
        }
        public ProcessInfo(string name, TimeSpan duration, DateTime startTime)
        {
            Name = name;
            lst = new SortedList<DateTime, TimeSpan>();
            lst.Add(startTime, duration);
        }
        #endregion
        public void Sum(ProcessInfo right)
        {
            TimeSpan buff;
            if (Name.Equals(right.Name))
            {
                foreach (var key in right.GetDateTimeCollection())
                {
                    if (lst.TryGetValue(key, out buff))
                        lst[key] += right[key];
                    else
                        lst.Add(key, right[key]);
                }
            }
        }
        public void SetRecord(string name, TimeSpan duration, DateTime processStartTime)
        {
            Name = name;
            lst.Add(processStartTime, duration);
        }
        public override string ToString()
        {
            var result = "Process:" + Name;
            foreach (var keyValuePair in lst)
                result += "\t start in: " + keyValuePair.Key + "\t with duration: " + keyValuePair.Value + ".\n";

            return result;
        }


        public void Sum(IProcessInfo other)
        {
            Sum((ProcessInfo)other);
        }


        public DateTime[] GetDateTimeCollection()
        {
            return lst.Keys.ToArray<DateTime>();
        }

        public TimeSpan[] GetTimeSpanCollection()
        {
            return lst.Values.ToArray<TimeSpan>();
        }


        public TimeSpan this[DateTime key]
        {
            get
            {
                return lst[key];
            }
            set
            {
                lst[key] = value;
            }
        }


        public bool ContainsKey(DateTime key)
        {
            return lst.ContainsKey(key);
        }

        public bool ContainsValue(TimeSpan value)
        {
            return lst.ContainsValue(value);
        }


        public Dictionary<DateTime, TimeSpan> GetCollection()
        {
            Dictionary<DateTime, TimeSpan> result = new Dictionary<DateTime, TimeSpan>();
            foreach (var item in lst)
                result.Add(item.Key, item.Value);

            return result;


        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
        TimeSpan GetProcessDuration()
        {
            var result = new TimeSpan();
            foreach (var item in lst)
                result += item.Value;
            return result;
        }

        public TimeSpan ProcessDuration
        {
            get { return GetProcessDuration(); }
        }
    }
}
