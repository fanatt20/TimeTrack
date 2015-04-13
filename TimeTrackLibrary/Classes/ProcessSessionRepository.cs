using System;
using System.Collections.Generic;
using System.Linq;
using TimeTrackLibrary.Interfaces;

namespace TimeTrackLibrary.Classes
{
    [Serializable]
    public sealed class ProcessSessionRepository : IProcessSessionRepository, IDisposable
    {
        List<ProcessSession> _dataBase = new List<ProcessSession>();
        public IQueryable<ProcessSession> Get()
        {
            return _dataBase.AsQueryable();
        }

        public void Add(ProcessSession session)
        {
            if (!_dataBase.Contains(session))
                _dataBase.Add(session);
        }

        public void Update(ProcessSession oldSession, ProcessSession newSession)
        {
            _dataBase.Remove(oldSession);
            _dataBase.Add(newSession);
        }

        public void Dispose()
        {
            _dataBase.Clear();
            GC.SuppressFinalize(this);
        }

        IQueryable<IProcessSession> IProcessSessionRepository.Get()
        {
            return _dataBase.AsQueryable<IProcessSession>();
        }

        public void Add(IProcessSession session)
        {

            this.Add((ProcessSession)session);
        }

        public void Update(IProcessSession oldSession, IProcessSession newSession)
        {
            if (_dataBase.Contains((ProcessSession)oldSession))
                _dataBase.Remove((ProcessSession)oldSession);
            this.Add(newSession);

        }
    }
}
