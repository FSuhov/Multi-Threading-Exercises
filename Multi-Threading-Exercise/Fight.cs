using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multi_Threading_Exercise
{
    class Fight
    {
        public List<Gladiatrix> Fighters { get; set; } = new List<Gladiatrix>();

        public void FuckOneMilf(Gladiatrix milf)
        {
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            int healthRemaining = 100;
            Stopwatch timer = new Stopwatch();
            timer.Start();
            while (healthRemaining > 0)
            {
                int impact = rnd.Next(11);
                if (impact > milf.Resistance)
                {
                    healthRemaining -= impact;
                }
                Thread.Sleep(50);
            }
            timer.Stop();
            Console.WriteLine($"{milf.Name} done.");
            milf.LatestResult = timer.ElapsedMilliseconds;
        }

        public void Tournament()
        {
            Parallel.ForEach(Fighters, fighter => { FuckOneMilf(fighter); });
            Console.WriteLine("All done");
        }

        public void PrintLatestResult()
        {
            var rankedList = Fighters.OrderByDescending(f => f.LatestResult);
            foreach (var girl in rankedList)
            {
                Console.WriteLine($"{girl.Name} - {girl.LatestResult}.");
            }

            foreach (var girl in Fighters)
            {
                girl.LatestResult = 0;
            }
        }
    }
}
