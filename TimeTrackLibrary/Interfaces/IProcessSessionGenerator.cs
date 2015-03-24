using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeTrackLibrary.Interfaces
{
    public interface IProcessSessionGenerator
    {
        event Action<IProcessSession> ProcessChanged;
        void BeginGeneration(TimeSpan interval, IProcessSessionProvider provider);
        void CancelGeneration();


    }
}
