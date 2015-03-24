using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeTrackLibrary.Interfaces;
using System.Threading;

namespace TimeTrackLibrary.Classes
{
    public class ProcessSessionGenerator : IProcessSessionGenerator
    {

        public event Action<IProcessSession> ProcessChanged;
        public void OnProcessChanged(IProcessSession session)
        {
            if (ProcessChanged != null)
                ProcessChanged(session);

        }
        Timer timer;
        
        public TimeSpan Interval { get; private set; }
        public IProcessSession CurrentProcess { get; private set; }
        public IProcessSession RegistredProcess { get; private set; }
        IProcessSessionProvider _provider;

        public void BeginGeneration(TimeSpan interval, IProcessSessionProvider provider)
        {
            _provider = provider;
            Interval = interval;
            RegistredProcess = _provider.GetCurrentProcessSession();
            RegistredProcess.StartAt = DateTime.Now;
            timer = new Timer(new TimerCallback(TrackCurrentProcesses), null, new TimeSpan(0, 0, 0), interval);
        }

        private void TrackCurrentProcesses(object state)
        {
            CurrentProcess = _provider.GetCurrentProcessSession();

            if (RegistredProcess.IsSameProcessAs(CurrentProcess))
                RegistredProcess.Duration += Interval;
            else
            {
                CurrentProcess.StartAt = DateTime.Now;
                CurrentProcess.Duration += Interval;
                RegistredProcess = CurrentProcess;
                OnProcessChanged(RegistredProcess);
            }
                
        }


        public void CancelGeneration()
        {
            timer.Dispose();
        }
    }
}
