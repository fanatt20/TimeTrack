using System;

namespace TimeTrackLibrary.Interfaces
{
    public interface IProcessSession
    {
        string ProcessName { get; set; }
        string WindowTitle { get; set; }
        DateTime StartAt { get; set; }
        TimeSpan Duration { get; set; }
        bool HaveSameProcessNameAndWindowTitle(IProcessSession other);
    }
}