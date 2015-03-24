using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeTrackLibrary.Interfaces
{
    public interface IProcessSessionProvider
    {
         IProcessSession GetCurrentProcessSession();
    }
}
