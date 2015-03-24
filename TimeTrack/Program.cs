using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeTrack
{
    class Program
    {
        static void Main(string[] args)
        {
            ISessionRepository repo = null;

            var sessions = repo.Get()
                .GroupBy(s => s.ProcessName, s => new
                {
                   s.WindowTitle,
                   s.StartAt,
                   DueTo = s.StartAt.Add(s.Duration)
                })
                .OrderBy(g => g.Key);

            repo.Get().Where(s => s.Duration > new TimeSpan(0, 5, 0));
                


            foreach (var item in sessions)
            {
                foreach (Session i in item)
                {

                }
            }
                

        }
    }
}
