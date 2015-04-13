using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using TimeTrackLibrary.Interfaces;

namespace TimeTrackLibrary.Classes
{
    public class ProcessSessionsImporter
    {
        public static void ImportFromCSV(IProcessSessionRepository repo, string pathAndName)
        {
            if (String.IsNullOrEmpty(pathAndName)) return;

            using (var streamReader = new StreamReader(pathAndName))
            {
                while (!streamReader.EndOfStream)
                {
                    var str = streamReader.ReadLine().Split(new string[] { "\",\"" }, StringSplitOptions.None);
                    repo.Add(new ProcessSession(str[0].Remove(0, 1), str[1], DateTime.Parse(str[2]), TimeSpan.Parse(str[3].Remove(str[3].Length - 1))));
                }
            }

        }
        static public void DeserializeFromFile(IProcessSessionRepository repo, string pathAndName)
        {
            if (String.IsNullOrEmpty(pathAndName) || !File.Exists(pathAndName)) return;
            using (var stream = new FileStream(pathAndName, FileMode.Open))
            {

                try
                {
                    var repository =
                       (IProcessSessionRepository)(new BinaryFormatter()).Deserialize(stream);
                    foreach (var sesion in repository.Get())
                        repo.Add(sesion);
                }
                catch (SerializationException) { }
                catch (ArgumentNullException) { }
            }
        }
    }
}

