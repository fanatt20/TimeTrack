using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TimeTrackLibrary
{
    public class ProcessInfoHandler : IProcessInfoHandler<ProcessInfoCategory>,IDisposable
    {
        public delegate void ProcessInfoEventHandler(Object sender, ProcessInfoEventArgs e);
        public event ProcessInfoEventHandler StorageHasUpdated;
        Timer timer;
        IProcessStorage<ProcessInfoCategory> coll;
        IProcessInfoGenerator gen = null;
        int interval;

        public void StartTrack(IProcessInfoGenerator generator, IProcessStorage<ProcessInfoCategory> collection, int intervals)
        {
            coll = collection;
            interval = intervals;
            gen = generator;
            timer = new Timer(new TimerCallback(Track), null, new TimeSpan(0, 0, 0), new TimeSpan(0, 0, intervals));


        }

        private void Track(object state)
        {
            string nameProcess = gen.GetCurrentProcessName();
            if (nameProcess==null || nameProcess=="")
                nameProcess = "Nothing";
            string currentWindowTitle = gen.GetCurrentProcessTitle();

            if (nameProcess == "explorer" && currentWindowTitle == "") // Desktop don't have title
                currentWindowTitle = "Desktop";

            DateTime dt;
            if (!gen.TryGetStartTimeOfCurrentProcess(out dt))
                dt = DateTime.Now;

            if (coll.ContainsKey(nameProcess))
            {

                if (coll[nameProcess].ContainsKey(currentWindowTitle))
                    (coll[nameProcess] as IProcessInfoCategory)[currentWindowTitle].Sum(new ProcessInfo(currentWindowTitle, new TimeSpan(0, 0, interval), dt));
                else
                    (coll[nameProcess] as IProcessInfoCategory).AddToCollection(currentWindowTitle, new ProcessInfo(currentWindowTitle, new TimeSpan(0, 0, interval), dt));

            }
            else
                coll.AddToCollection(nameProcess, new ProcessInfoCategory(nameProcess, new ProcessInfo(currentWindowTitle, new TimeSpan(0, 0, interval), dt)));
            //StorageHasUpdated(this, new ProcessInfoEventArgs(currentWindowTitle, nameProcess, new TimeSpan(0, 0, interval)));
        }
        public void FinishTrack()
        {
            Dispose();
        }



        public void Dispose()
        {
            if (timer != null)
            {
                timer.Dispose();
                timer = null;
            }
            if (coll != null)
            {
                coll = null;
            }
            if (gen != null)
                gen = null;
            GC.Collect();
        }
    }
}
