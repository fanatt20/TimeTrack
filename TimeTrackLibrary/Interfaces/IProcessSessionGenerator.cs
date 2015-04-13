using System;

namespace TimeTrackLibrary.Interfaces
{
    public interface IProcessSessionGenerator
    {
        event Action<IProcessSession> ProcessChanged;
        void BeginGeneration(TimeSpan interval, IProcessSessionProvider provider);
        void CancelGeneration();
    }
}