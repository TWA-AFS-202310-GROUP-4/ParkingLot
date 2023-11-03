namespace ParkingLot
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ParkingLot
    {
        private Dictionary<string, string> ticketCarDict = new ();
        private int capacity;

        public ParkingLot(int capacity = 10)
        {
            this.capacity = capacity;
        }

        public bool IsFull()
        {
            return ticketCarDict.Count == capacity;
        }

        public string Fetch(string ticket)
        {
            if (ticket == null)
            {
                return null;
            }

            string car;
            this.ticketCarDict.TryGetValue(ticket, out car);
            this.ticketCarDict.Remove(ticket);

            return car;
        }

        public string Park(string car)
        {
            if (IsFull())
            {
                return null;
            }

            if (car == null)
            {
                return null;
            }

            if (ticketCarDict.Where(item => item.Value == car).Any())
            {
                return null;
            }

            var ticket = Guid.NewGuid().ToString();
            this.ticketCarDict[ticket] = car;
            return ticket;
        }
    }
}
