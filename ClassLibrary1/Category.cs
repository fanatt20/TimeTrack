using System;
using System.Collections.Generic;
using System.Linq;
using ClassLibrary1;

namespace ClassLibrary1
{
    class ProcessInfoCategory<T> : IProcessInfoCategory, IProcessStorage<T> where T : IProcessInfo
    {
        #region IRecord implementation
        public string Name { get; set; }
        public void Sum(ProcessInfoCategory<T> category)
        {
            if (Name == category.Name)
            {
                foreach (var item in category.Data)
                {
                    if (_data.ContainsKey(item.Key) && _data[item.Key].StartTime == item.Value.StartTime)
                        _data[item.Key].Sum(item.Value);
                    else
                        _data.Add(item.Key, item.Value);
                }
            }
        }
        public TimeSpan Duration { get { return _processDuration ?? GetGlobalTime(); } }
        public void SetProcessDuration(TimeSpan value) { _processDuration = value; }
        public DateTime StartTime { get; }
        public void StartTime(DateTime value) { _processStartTime = value; }
        #endregion
        #region System variables
        DateTime _processStartTime;
        TimeSpan? _processDuration = null;
        Dictionary<string, T> _data;
        #endregion
        public T this[string key]
        {
            get { if (_data.ContainsKey(key)) return _data[key]; else throw new ArgumentOutOfRangeException(); }
        }

        public Dictionary<string, T> Data { get { return _data ?? CreateDictionary(); } }
        private Dictionary<string, T> CreateDictionary()
        {
            _data = new Dictionary<string, T>();
            return _data;
        }

        public void AddToCollection(string key, T record)
        {
            if (key != null)
                if (_data.ContainsKey(key) && record.StartTime == _data[key].StartTime)
                    _data[key].Sum(record);
                else
                    _data.Add(key, record);
            else
                throw new ArgumentNullException();
        }

        private TimeSpan GetGlobalTime()
        {
            var result = new TimeSpan();
            foreach (var item in _data)
                result += item.Value.Duration;
            _processDuration = result;
            return result;
        }
        public override string ToString()
        {
            var result = Name + "\n";

            foreach (var item in Data)
            {
                result += item.ToString() + "\n";

            }
            return result;
        }
        public ProcessInfoCategory()
        {
            _processDuration = null;
            _data = null;
            Name = "Default";
        }
        public ProcessInfoCategory(TimeSpan ts, string name)
        {
            _processDuration = ts;
            _data = null;
            Name = name;
        }
        public ProcessInfoCategory(IProcessInfo record)
        {
            _data = null;
            _processDuration = record.Duration;
            Name = record.Name;
        }

    }
}
