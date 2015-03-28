using TimeTrackLibrary.Interfaces;

namespace TimeTrackLibrary.Classes
{
    public class ProcessSessionWatcher : IProcessSessionWatcher
    {
        public IProcessSessionRepository Repository { get; private set; }
        public IProcessSessionGenerator Generator { get; private set; }
        public void StartWatch(IProcessSessionRepository repo, IProcessSessionGenerator gen)
        {
            Repository = repo;
            Generator = gen;
            Generator.ProcessChanged += OnProcessSessionChanged;
        }

        private void OnProcessSessionChanged(IProcessSession session)
        {
            Repository.Add(session);

        }
        public void StopWatch()
        {
            Generator.CancelGeneration();
            Generator.ProcessChanged -= OnProcessSessionChanged;
        }

    }
}
