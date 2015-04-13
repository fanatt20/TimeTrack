using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TimeTrackLibrary.Interfaces;

namespace TimeTrackLibrary.Classes
{
    public class ProcessSessionsImporter
    {
        public static void ImportFromText(IProcessSessionRepository repo, string pathAndName)
        {
            if (!String.IsNullOrEmpty(pathAndName))
                using (var streamReader = new StreamReader(pathAndName))
                {
                    String[] sessions;

                    while (!streamReader.EndOfStream)
                    {
                        sessions = (streamReader.ReadLine() + streamReader.ReadLine()).Split('=', '\t', '\n');
                        repo.Add(new ProcessSession(sessions[1], sessions[3], DateTime.Parse(sessions[5]), TimeSpan.Parse(sessions[7])));

                    }
                }
        }

        public static void ImportFromCSV(IProcessSessionRepository repo, string pathAndName)
        {

        }
        static public void DeserializeFromFile(IProcessSessionRepository repo, string pathAndName)
        {
            if (!String.IsNullOrEmpty(pathAndName))
            {

                using (var stream = new FileStream(pathAndName, FileMode.OpenOrCreate))
                {
                    try
                    {
                        foreach (var sesion in ((IProcessSessionRepository)(new BinaryFormatter()).Deserialize(stream)).Get())
                            repo.Add(sesion);
                    }
                    catch (System.Runtime.Serialization.SerializationException) { }

                }
            }
        }
    }
}

