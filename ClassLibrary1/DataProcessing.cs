using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ClassLibrary1
{
   public class ProcessInfoHandler: IProcessInfoHandler<ProcessInfoCategory>
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
            if (nameProcess == null || nameProcess == "")
                nameProcess = "Nothing";
            string currentWindowTitle = gen.GetCurrentProcessTitle();
            if (coll.ContainsKey(nameProcess))
            {
                var Category=coll[nameProcess];
                    if (Category.ContainsKey(gen.GetCurrentProcessTitle()))
                        (Category as IProcessInfoCategory)[currentWindowTitle] .Duration += new TimeSpan(0, 0, interval);
                    else
                    {
                        Category.AddToCollection(currentWindowTitle, new ProcessInfo(currentWindowTitle, new TimeSpan(0, 0, interval)));
                        //неправильно, но что поделать, надо заменить ProcessInfo на абстакцию
                        DateTime dt;
                        if (gen.GetStartTimeOfCurrentProcess(out dt))
                            (Category as IProcessInfoCategory)[currentWindowTitle].StartTime = dt;
                        else
                            (Category as IProcessInfoCategory)[currentWindowTitle].StartTime = DateTime.Now;
                    }

                
            }
            else
            {
                coll.AddToCollection(nameProcess, new ProcessInfoCategory(nameProcess));

                //coll[nameProcess].AddToCollection(currentWindowTitle, new ProcessInfo(currentWindowTitle,new TimeSpan(0,0,interval)));
                coll[nameProcess].Data.Add(currentWindowTitle, new ProcessInfo(currentWindowTitle, new TimeSpan(0, 0, interval)));
                //та же тема
                DateTime dt;
                if (gen.GetStartTimeOfCurrentProcess(out dt))
                    (coll[nameProcess] as IProcessInfoCategory)[currentWindowTitle].StartTime = dt;
                else
                    (coll[nameProcess] as IProcessInfoCategory)[currentWindowTitle].StartTime = DateTime.Now;
            }
          //  DateTime date;
            //if (gen.GetStartTimeOfCurrentProcess(out date))
              //  (coll[nameProcess] as IProcessInfoCategory).[currentWindowTitle].StartTime = date;
           // else
             //   (coll[nameProcess] as IProcessInfoCategory)[currentWindowTitle].StartTime = DateTime.Now;

            //StorageHasUpdated(this, new ProcessInfoEventArgs(currentWindowTitle, nameProcess, new TimeSpan(0, 0, interval)));

        }
        public void FinishTrack()
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
