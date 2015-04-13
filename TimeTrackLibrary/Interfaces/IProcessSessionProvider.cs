namespace TimeTrackLibrary.Interfaces
{
    public interface IProcessSessionProvider
    {
        IProcessSession GetCurrentProcessSession();
    }
}