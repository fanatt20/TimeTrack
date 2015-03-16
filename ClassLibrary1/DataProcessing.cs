using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ClassLibrary1
{
    class ProcessInfoHandler<T> : IProcessInfoHandler<T> where T : IProcessInfoCategory,new()
    {
        Timer timer;
        IProcessStorage<T> coll;
        IProcessInfoGenerator gen = null;
        int interval;
        public void StartTrack(IProcessInfoGenerator generator, IProcessStorage<T> collection, int intervals)
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
                using (IProcessInfoCategory Category = coll[nameProcess])
                {
                    if (Category.ContainsKey(gen.GetCurrentProcessTitle()))
                        Category[currentWindowTitle].Duration += new TimeSpan(0, 0, interval);
                    else
                    {
                        Category.AddToCollection(currentWindowTitle, new ProcessInfo(currentWindowTitle, new TimeSpan(0, 0, interval)));
                        //неправильно, но что поделать, надо заменить ProcessInfo на абстакцию
                        DateTime dt;
                        if (gen.GetStartTimeOfCurrentProcess(out dt))
                            Category[currentWindowTitle].StartTime = dt;
                        else
                            Category[currentWindowTitle].StartTime = DateTime.Now;
                    }
                    
                }

            }
            else
            {
                coll.AddToCollection(nameProcess, new T());

                coll[nameProcess].AddToCollection(currentWindowTitle, new ProcessInfo());
                //та же тема
            }
            DateTime date;
            if (gen.GetStartTimeOfCurrentProcess(out date))
                coll[nameProcess][currentWindowTitle].StartTime = date;
            else
                coll[nameProcess][currentWindowTitle].StartTime = DateTime.Now;


        }
        public void FinishTrack()
        {
            if (timer != null)
            {
                timer.Dispose();
                timer = null;
            }
            if (coll!= null)
            {
                coll.Dispose();
                coll = null;
            }
            if (gen != null)
                gen = null;
        }
    }
}
