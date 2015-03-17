using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;
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
        //можно, но есть привязка к реализации через класс System.Diagnostics.Process
        // мне больше нравится получать конкретные данные
        public int GetCurrentProcessId();
        public string GetCurrentProcessName();
        public TimeSpan GetCurrentProcessTime();
        public string GetCurrentProcessTitle();
        public bool GetStartTimeOfCurrentProcess(out DateTime dateTime );
    }
    class ProcessInfoEventArgs:EventArgs
    {
        private readonly string windowTitle, processName;
        private readonly TimeSpan duration;
        public ProcessInfoEventArgs(string windowTitle, string processName, TimeSpan duration)
        {
            this.windowTitle = windowTitle;
            this.processName = processName;
            this.duration = duration;
        }
        public string WindowTitle { get { return windowTitle; } }
        public string ProcessName { get { return processName; } }
        public TimeSpan Duration { get { return duration; } }

    }
    interface IProcessInfoHandler<T>// как ограничить Т на ICategory && IRecord?
    {
        public delegate void ProcessInfoEventHandler(Object sender, ProcessInfoEventArgs e);
        public event ProcessInfoEventHandler StorageHasUpdated;

        public void StartTrack(IProcessInfoGenerator generator, IProcessStorage<T> collection, int intervals);
        public void FinishTrack();
    }
}
