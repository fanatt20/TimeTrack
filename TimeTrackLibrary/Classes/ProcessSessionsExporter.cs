using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TimeTrackLibrary.Interfaces;

namespace TimeTrackLibrary.Classes
{
    public sealed class ProcessSessionsExporter
    {
        static public void ExportAsText(IProcessSessionRepository repo, string pathAndName)
        {
            if (String.IsNullOrEmpty(pathAndName)) return;
            using (var streamWriter = new StreamWriter(pathAndName, true))
            {
                foreach (var session in repo.Get())
                {
                    streamWriter.Write("Process Name =" + session.ProcessName
                                       + "\t Window Title =" + session.WindowTitle.Trim()
                                       + "\t StartAt =" + session.StartAt
                                       + "\t Duration =" + session.Duration + "\n");
                }
            }
        }

        static public void ExportAsCSV(IProcessSessionRepository repo, string pathAndName)
        {
            if (pathAndName != "" && repo != null)
            {
                using (var streamWriter = new StreamWriter(pathAndName, true))
                {
                    foreach (var session in repo.Get())
                    {
                        streamWriter.WriteLine("\""+session.ProcessName
                            + "\",\"" + session.WindowTitle.Trim()
                            + "\",\"" + session.StartAt
                            + "\",\"" + session.Duration+"\"");
                    }
                }
            }
        }

        static public void SerializeIntoFile(IProcessSessionRepository repo, string pathAndName)
        {


            using (var stream = Stream.Synchronized(new FileStream(pathAndName,
                                                                FileMode.OpenOrCreate, FileAccess.Write,
                                                                FileShare.Write,
                                                                bufferSize: 4096, useAsync: true)))
                (new BinaryFormatter()).Serialize(stream, repo);

        }

    }
}
