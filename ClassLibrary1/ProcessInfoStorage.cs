using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    public class ProcessInfoStorage:IProcessStorage<ProcessInfoCategory>
    {// TODO: Normalize data for charts
        private Dictionary<string, ProcessInfoCategory> data= new Dictionary<string,ProcessInfoCategory>();
        public bool ContainsKey(string key)
        {
            return data.ContainsKey(key);
        }

        public bool ContainsValue(ProcessInfoCategory value)
        {
            return data.ContainsValue(value);
        }

        public bool ContainsPair(string key, ProcessInfoCategory value)
        {
            return ContainsKey(key) && ContainsValue(value);
        }

        public void AddToCollection(string name, ProcessInfoCategory record)
        {
            if (data.ContainsKey(name))
                data[name].Sum(record);
            else
                data.Add(name, record);
        }

        public ProcessInfoCategory this[string key]
        {
            get {return data[key];}
        }

        public IEnumerator<ProcessInfoCategory> GetEnumerator()
        {
            return data.Values.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Dispose()
        {
            if (data != null)
            {
                data.Clear();
                data = null;
            }
        }
        public override string ToString()
        {
            var result = "";
            foreach (var item in data)
            {
                result += item.Value.ToString();
            }
            return result;
        }
    }
}
