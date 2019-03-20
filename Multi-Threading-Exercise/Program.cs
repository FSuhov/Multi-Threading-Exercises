using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Threading_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            //ProcessItemsMachine service = new ProcessItemsMachine(5, 100);
            //service.ProcessItemsByInvoke();
            //service.ProcessItemsByFor();
            //service.ProcessItemsByForEach();

            //LuckyTicketCounter ticketCounter = new LuckyTicketCounter(6);
            //ticketCounter.PrintNumberOfLuckyTickets();

            Gladiatrix tanya = new Gladiatrix("Tanya Danielle", 9, 7);
            Gladiatrix goldie = new Gladiatrix("Goldie Blair", 8, 9);
            Gladiatrix amber = new Gladiatrix("Amber Michaelle", 8, 6);
            Gladiatrix shyla = new Gladiatrix("Shyla Stylez", 8, 8);
            Gladiatrix christina= new Gladiatrix("Christina Carter", 9, 7);
            Gladiatrix paige = new Gladiatrix("Paige Delight", 8, 7);

            Fight club = new Fight();
            club.Fighters.Add(tanya);
            club.Fighters.Add(goldie);
            club.Fighters.Add(amber);
            club.Fighters.Add(shyla);
            club.Fighters.Add(christina);
            club.Fighters.Add(paige);

            club.Tournament();
            club.PrintLatestResult();

        }
    }
}
