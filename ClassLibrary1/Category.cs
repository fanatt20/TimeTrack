using System;
using System.Collections.Generic;
using System.Linq;
using ClassLibrary1;

namespace ClassLibrary1
{
    public class ProcessInfoCategory : IProcessInfoCategory
    {
        public string CategoryName { get; set; }
        public void Sum(IProcessInfoCategory category)
        {
            if (CategoryName == category.CategoryName)
            {
                foreach (ProcessInfo item in category)
                {
                    if (_data.ContainsKey(item.Name))
                        _data[item.Name].Sum(item);
                    else
                        _data.Add(item.Name, item);
                }
            }
        }

        #region System variables
        TimeSpan? _processDuration = null;
        Dictionary<string, ProcessInfo> _data = new Dictionary<string, ProcessInfo>();
        #endregion

        public Dictionary<string, ProcessInfo> Data { get { return _data ?? CreateDictionary(); } }
        private Dictionary<string, ProcessInfo> CreateDictionary()
        {
            _data = new Dictionary<string, ProcessInfo>();
            return _data;
        }

        public void AddToCollection(string key, ProcessInfo record)
        {
            if (key != null)
                if (_data.ContainsKey(key))
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
                foreach (var duration in item.Value.GetTimeSpanCollection())
                    result += duration;
            _processDuration = result;
            return result;
        }
        public override string ToString()
        {
            var result = CategoryName + "\n";

            foreach (var item in Data)
            {
                result += item.ToString() + "\n";

            }
            return result;
        }
        public ProcessInfoCategory()
        {
            _processDuration = null;
            _data = new Dictionary<string, ProcessInfo>();
            CategoryName = "Default";
        }
        public ProcessInfoCategory(string name, params ProcessInfo[] a)
        {
            _processDuration = null;
            CreateDictionary();
            CategoryName = name;
            foreach (var item in a)
            {
                if (!Data.ContainsKey(item.Name))
                    Data.Add(item.Name, item);
                else
                    Data[item.Name].Sum(item);
            }
        }
        public ProcessInfoCategory(string name, ProcessInfo a)
        {
            _processDuration = null;
            CreateDictionary();
            Data.Add(a.Name, a);
            CategoryName = name;
            
        }
        public ProcessInfoCategory(ProcessInfoCategory record)
        {
            _data = record._data;
            CategoryName = record.CategoryName;
        }


        public TimeSpan CategoryDuration
        { get { return GetGlobalTime(); } }


        public bool ContainsKey(string key)
        {
            return _data.ContainsKey(key);
        }

        public bool ContainsValue(ProcessInfo value)
        {
            return _data.ContainsValue(value);
        }

        public bool ContainsPair(string key, ProcessInfo value)
        {
            return ContainsKey(key) && ContainsValue(value);
        }


        ProcessInfo IProcessStorage<ProcessInfo>.this[string key]
        {
            get { if ((_data).ContainsKey(key)) return _data[key]; else throw new ArgumentOutOfRangeException(); }
        }

        public IEnumerator<ProcessInfo> GetEnumerator()
        {
            return _data.Values.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Dispose()
        {
            if (_data != null)
            {
                _data.Clear();
                _data = null;
            }
        }


        public ProcessInfo[] GetCollection()
        {
            return Data.Values.ToArray<ProcessInfo>();
        }
    }
}
