using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TimeTrackLibrary.Interfaces;
using Excel = Microsoft.Office.Interop.Excel;


namespace TimeTrackLibrary.Classes
{
    public sealed class ProcessSessionsExporter
    {
        static public void ExportAsText(IProcessSessionRepository repo, string pathAndName)
        {
            if (String.IsNullOrEmpty(pathAndName))
            {
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
        }

        static public void ExportAsExcel(IProcessSessionRepository repo, string pathAndName)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            int rCnt = 1;
            xlWorkSheet.Cells[rCnt, 1] = "Process Name";
            xlWorkSheet.Cells[rCnt, 2] = "Window Title";
            xlWorkSheet.Cells[rCnt, 3] = "Start At";
            xlWorkSheet.Cells[rCnt, 4] = "Duration";

            rCnt++;

            foreach (var session in repo.Get())
            {
                xlWorkSheet.Cells[rCnt, 1] = session.ProcessName;
                xlWorkSheet.Cells[rCnt, 2] = session.WindowTitle;
                xlWorkSheet.Cells[rCnt, 3] = session.StartAt.ToString();
                xlWorkSheet.Cells[rCnt, 4] = session.Duration.ToString();
                rCnt++;
            }

            xlWorkBook.SaveAs(pathAndName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);

            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();
        }
        static public void ExportAsCSV(IProcessSessionRepository repo, string pathAndName)
        {
            if (pathAndName != "" && repo != null)
            {
                using (var streamWriter = new StreamWriter(pathAndName, true))
                {
                    foreach (var session in repo.Get())
                    {
                        streamWriter.WriteLine(session.ProcessName
                            + "," + session.WindowTitle.Trim()
                            + "," + session.StartAt
                            + "," + session.Duration);
                    }
                }
            }
        }

        static public void SerializeIntoFile(IProcessSessionRepository repo, string pathAndName)
        {


            using (var stream = FileStream.Synchronized(new FileStream(pathAndName,
                                                                FileMode.OpenOrCreate, FileAccess.Write,
                                                                FileShare.Write,
                                                                bufferSize: 4096, useAsync: true)))
                (new BinaryFormatter()).Serialize(stream, repo);

        }

    }
}
