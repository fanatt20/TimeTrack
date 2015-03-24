using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;
namespace TimeTrackLibrary
{
    public interface IProcessInfo:  IDisposable
    {
        string Name { get; set; }
        DateTime[] GetDateTimeCollection();
        bool ContainsKey(DateTime key);
        bool ContainsValue(TimeSpan value);
        TimeSpan[] GetTimeSpanCollection();
        Dictionary<DateTime, TimeSpan> GetCollection();
        TimeSpan ProcessDuration { get; }
        void SetRecord(string name, TimeSpan duration, DateTime processStartTime);
        void Sum(IProcessInfo other);
        TimeSpan this[DateTime key] { get; set; }
    }
    public interface IProcessInfoCategory : IProcessStorage<ProcessInfo>
    {
        string CategoryName { get; set; }
        TimeSpan CategoryDuration { get; }
        void Sum(IProcessInfoCategory other);

    }
    public interface IProcessStorage<T> : IEnumerable<T>, IDisposable where T : new()
    {
        bool ContainsKey(string key);
        bool ContainsValue(T value);
        bool ContainsPair(string key, T value);
        void AddToCollection(string name, T record);
        T[] GetCollection();
        T this[string key] { get; }
    }
    public interface IProcessInfoGenerator
    {
        //public Process GetActiveWindowAsProcess();
        //можно, но есть привязка к реализации через класс System.Diagnostics.Process
        // мне больше нравится получать конкретные данные
        int GetCurrentProcessId();
        string GetCurrentProcessName();
        TimeSpan GetCurrentProcessTime();
        string GetCurrentProcessTitle();
        bool TryGetStartTimeOfCurrentProcess(out DateTime dateTime);
    }
    public class ProcessInfoEventArgs : EventArgs
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
    public interface IProcessInfoHandler<T> where T : class, IProcessInfoCategory, new()// как ограничить Т на ICategory && IRecord?
    {
        void StartTrack(IProcessInfoGenerator generator, IProcessStorage<T> collection, int intervals);
        void FinishTrack();
    }
}
