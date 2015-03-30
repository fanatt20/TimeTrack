using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeTrackLibrary.Interfaces
{
   public interface IProcessSessionWatcher
    {
         void StartWatch(IProcessSessionRepository repo, IProcessSessionGenerator gen);
         bool Watching { get;}
         void StopWatch();
    }
}
