using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeTrackLibrary.Interfaces
{
    public interface IProcessSessionRepository:IDisposable
    {
        IQueryable<IProcessSession> Get();
        void Add(IProcessSession session);
        void Update(IProcessSession oldSession, IProcessSession newSession);
    }
}
