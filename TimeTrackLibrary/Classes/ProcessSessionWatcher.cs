using TimeTrackLibrary.Interfaces;

namespace TimeTrackLibrary.Classes
{
    public class ProcessSessionWatcher : IProcessSessionWatcher
    {
        public IProcessSessionRepository Repository { get; private set; }
        public IProcessSessionGenerator Generator { get; private set; }

        public void StartWatch(IProcessSessionRepository repo, IProcessSessionGenerator gen)
        {
            if (Watching) return;

            Watching = true;

            Repository = repo;
            Generator = gen;
            Generator.ProcessChanged += OnProcessSessionChanged;
        }

        public void StopWatch()
        {
            if (!Watching) return;

            Generator.CancelGeneration();
            Generator.ProcessChanged -= OnProcessSessionChanged;

            Watching = false;
        }

        public bool Watching { get; private set; }

        private void OnProcessSessionChanged(IProcessSession session)
        {
            Repository.Add(session);
        }
    }
}