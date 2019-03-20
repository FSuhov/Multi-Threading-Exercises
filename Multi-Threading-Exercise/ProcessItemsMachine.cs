using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multi_Threading_Exercise
{
    class ProcessItemsMachine
    {
        private int[] items;
        private int timeToSleep;

        public ProcessItemsMachine(int numberOfItems, int time)
        {
            items = Enumerable.Range(0, numberOfItems).ToArray();
            timeToSleep = time;
        }

        private void ProcessItem(int item)
        {
            Console.WriteLine($"Started Item {item}.");
            Thread.Sleep(timeToSleep);
            Console.WriteLine($"Finished Item {item}.");

        }

        public void ProcessItemsByInvoke()
        {
            if (items.Length == 0)
            {
                Console.WriteLine("No items");
                return;
            }
            Parallel.Invoke(()=>ProcessItem(items.First()), ()=>ProcessItem(items.Last()));
        }

        public void ProcessItemsByFor()
        {
            Parallel.For(0, items.Length, i => { ProcessItem(i); });
            Console.WriteLine("Parallel For done.");
            Console.WriteLine("==========================================");
        }

        public void ProcessItemsByForEach()
        {
            Parallel.ForEach(items, item => { ProcessItem(item); });
            Console.WriteLine("Parallel ForEach done.");
            Console.WriteLine("==========================================");
        }
    }
}
