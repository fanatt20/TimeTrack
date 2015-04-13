namespace TimeTrackLibrary.Interfaces
{
    public interface IProcessSessionWatcher
    {
        bool Watching { get; }
        void StartWatch(IProcessSessionRepository repo, IProcessSessionGenerator gen);
        void StopWatch();
    }
}