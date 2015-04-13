using System;
using System.Threading;
using TimeTrackLibrary.Interfaces;

namespace TimeTrackLibrary.Classes
{
    public sealed class ProcessSessionGenerator : IProcessSessionGenerator, IDisposable
    {
        private IProcessSessionProvider _provider;
        private Timer _timer;
        public TimeSpan Interval { get; private set; }
        public IProcessSession CurrentProcess { get; private set; }
        public IProcessSession RegistredProcess { get; private set; }

        public void Dispose()
        {
            if (_timer != null)
                _timer.Dispose();
        }

        public event Action<IProcessSession> ProcessChanged;

        public void BeginGeneration(TimeSpan interval, IProcessSessionProvider provider)
        {
            _provider = provider;
            Interval = interval;
            RegistredProcess = _provider.GetCurrentProcessSession();
            RegistredProcess.StartAt = DateTime.Now;
            _timer = new Timer(TrackCurrentProcesses, null, new TimeSpan(0, 0, 0), interval);
        }

        public void CancelGeneration()
        {
            if (_timer != null)
                _timer.Dispose();
        }

        public void OnProcessChanged(IProcessSession session)
        {
            if (ProcessChanged != null)
                ProcessChanged(session);
        }

        private void TrackCurrentProcesses(object state)
        {
            CurrentProcess = _provider.GetCurrentProcessSession();

            if (RegistredProcess.HaveSameProcessNameAndWindowTitle(CurrentProcess))
                RegistredProcess.Duration += Interval;
            else
            {
                CurrentProcess.StartAt = DateTime.Now;
                CurrentProcess.Duration += Interval;
                RegistredProcess = CurrentProcess;
                OnProcessChanged(RegistredProcess);
            }
        }
    }
}