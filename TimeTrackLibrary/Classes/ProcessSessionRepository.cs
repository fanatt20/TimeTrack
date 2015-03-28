using System;
using System.Collections.Generic;
using System.Linq;
using TimeTrackLibrary.Interfaces;

namespace TimeTrackLibrary.Classes
{
    [Serializable]
    public sealed class ProcessSessionRepository : IProcessSessionRepository, IDisposable
    {
        List<ProcessSession> dataBase = new List<ProcessSession>();
        public IQueryable<ProcessSession> Get()
        {
            return dataBase.AsQueryable();
        }

        public void Add(ProcessSession session)
        {
            if (!dataBase.Contains(session))
                dataBase.Add(session);
        }

        public void Update(ProcessSession oldSession, ProcessSession newSession)
        {
            dataBase.Remove(oldSession);
            dataBase.Add(newSession);
        }

        public void Dispose()
        {
            dataBase.Clear();
            GC.SuppressFinalize(this);
        }

        IQueryable<IProcessSession> IProcessSessionRepository.Get()
        {
            return dataBase.AsQueryable<IProcessSession>();
        }

        public void Add(IProcessSession session)
        {

            this.Add((ProcessSession)session);
        }

        public void Update(IProcessSession oldSession, IProcessSession newSession)
        {
            if (dataBase.Contains((ProcessSession)oldSession))
                dataBase.Remove((ProcessSession)oldSession);
            this.Add(newSession);

        }
    }
}
