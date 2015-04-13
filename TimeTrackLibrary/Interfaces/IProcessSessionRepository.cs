using System;
using System.Linq;

namespace TimeTrackLibrary.Interfaces
{
    public interface IProcessSessionRepository : IDisposable
    {
        IQueryable<IProcessSession> Get();
        void Add(IProcessSession session);
        void Update(IProcessSession oldSession, IProcessSession newSession);
    }
}