using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multi_Threading_Exercise
{
    class LuckyTicketCounter
    {
        private int _digits;
        private long maxNumber;

        public LuckyTicketCounter(int digits)
        {
            _digits = digits;
            if (_digits % 2 != 0)
            {
                _digits++;
            }
            this.maxNumber = this.GetMaxNumber(digits);
        }
        public bool IsLuckyTicket(Ticket ticket)
        {
            long leftSum = 0;
            long rightSum = 0;
            int digits = ticket.GetNumberLength();

            for (int i = 0, j = digits / 2; i < digits / 2 && j < digits; i++, j++)
            {
                leftSum += ticket[i];
                rightSum += ticket[j];
            }

            return leftSum == rightSum;
        }

        public int CountNumberOfLuckyTickets()
        {
            int counter = 0;
            for (long i = 1; i <= this.maxNumber; i++)
            {
                if (IsLuckyTicket(new Ticket(i, this._digits)))
                {
                    counter++;
                }
            }

            return counter;
        }

        public int CountNumberOfLuckyTicketsParallel()
        {
            object sync = new object();
            int counter = 0;

            Parallel.For(1, maxNumber+1, i =>
            {
                if (IsLuckyTicket(new Ticket(i, this._digits)))
                {
                    lock (sync)
                    {
                        counter++;
                    }
                }
            });

            return counter;
        }

        public void PrintNumberOfLuckyTickets()
        {
            long TimeElapsed = 0;
            Stopwatch timer = new Stopwatch();
            timer.Start();
            int number = CountNumberOfLuckyTickets();
            timer.Stop();
            TimeElapsed += timer.ElapsedMilliseconds;
            Console.WriteLine($"There are {number} possible lucky tickets.");
            Console.WriteLine($"Time elapsed {TimeElapsed} milliseconds in simple mode.");

            TimeElapsed = 0;
            timer = new Stopwatch();
            timer.Start();
            number = CountNumberOfLuckyTicketsParallel();
            timer.Stop();
            TimeElapsed += timer.ElapsedMilliseconds;
            Console.WriteLine($"There are {number} possible lucky tickets.");
            Console.WriteLine($"Time elapsed {TimeElapsed} milliseconds in parallel mode.");

        }

        private long GetMaxNumber(int digits)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < digits; i++)
            {
                result.Append('9');
            }

            return long.Parse(result.ToString());
        }
    }

    class Ticket
    {
        private byte[] numberAsArray;

        public Ticket(long number, int digits)
        {
            this.numberAsArray = this.NumberToArray(number, digits);
        }

        public byte this[int index]
        {
            get
            {
                try
                {
                    return this.numberAsArray[index];
                }
                catch (IndexOutOfRangeException)
                {
                    throw;
                }
            }
        }

        public int GetNumberLength()
        {
            return this.numberAsArray.Length;
        }

        private byte[] NumberToArray(long number, int digits)
        {
            byte[] numberAsArray = new byte[digits];
            long j = 10;
            for (int i = digits - 1; i >= 0; i--)
            {
                numberAsArray[i] = (byte)(number % j);
                number /= j;
            }

            return numberAsArray;
        }

        
    }
}
