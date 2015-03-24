using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeTrackLibrary.Interfaces;

namespace TimeTrackLibrary.Classes
{
    public class ProcessSessionRepository : IProcessSessionRepository
    {
        List<ProcessSession> dataBase = new List<ProcessSession>();
        public IQueryable<ProcessSession> Get()
        {
            return dataBase.AsQueryable();
        }

        public void Add(ProcessSession session)
        {
            dataBase.Add(session);
        }

        public void Update(ProcessSession oldSession, ProcessSession newSession)
        {
            dataBase.Remove(oldSession);
            dataBase.Add(newSession);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        IQueryable<IProcessSession> IProcessSessionRepository.Get()
        {
            return dataBase.AsQueryable<IProcessSession>();
        }

        public void Add(IProcessSession session)
        {
            dataBase.Add((ProcessSession)session);
        }

        public void Update(IProcessSession oldSession, IProcessSession newSession)
        {
            dataBase.Remove((ProcessSession)oldSession);
            dataBase.Add((ProcessSession)newSession);
            
        }
    }
}
