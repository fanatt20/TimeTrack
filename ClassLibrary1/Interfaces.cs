using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
namespace ClassLibrary1
{
    interface IProcessInfo
    { 
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime StartTime { get; set; }
        public void SetRecord(string name, TimeSpan duration, DateTime processStartTime);
        public void Sum(IProcessInfo other);
    }
    interface IProcessInfoCategory : IProcessStorage<IProcessInfo>
    {
        public TimeSpan CategoryDuration { get; }
        public string CategoryName { get; set; }
    }
    interface IProcessStorage<T> : IEnumerable<T>, IDisposable where T:new()
    {
        public bool ContainsKey(string key);
        public bool ContainsValue(T value);
        public bool ContainsPair(string key, T value);
        public void AddToCollection(string name, T record);
        public void Sum(IProcessStorage<T> other);
        public T this[string key] { get; }
    }
    interface IProcessInfoGenerator
    {
        //public Process GetActiveWindowAsProcess();
        //можно, но есть привязка к реализации через класс System.Diagnostic.Process
        // мне больше нравится получать конкретные данные
        public int GetCurrentProcessId();
        public string GetCurrentProcessName();
        public TimeSpan GetCurrentProcessTime();
        public string GetCurrentProcessTitle();
        public bool GetStartTimeOfCurrentProcess(out DateTime dateTime );
    }
    interface IProcessInfoHandler<T>// как ограничить Т на ICategory && IRecord?
    {
        public void StartTrack(IProcessInfoGenerator generator, IProcessStorage<T> collection, int intervals);
        public void FinishTrack();
    }
}
