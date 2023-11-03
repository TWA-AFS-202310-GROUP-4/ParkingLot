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
            if (ticket == null || !ticketCarDict.ContainsKey(ticket))
            {
                throw new WrongTicketException("Unrecognized parking ticket.");
            }

            this.ticketCarDict.TryGetValue(ticket, out string car);
            this.ticketCarDict.Remove(ticket);

            return car;
        }

        public string Park(string car)
        {
            if (IsFull())
            {
                throw new NoPositionException("No available position");
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

    public class NoPositionException : Exception
    {
        public NoPositionException(string message) : base(message)
        {
        }
    }

    public class WrongTicketException : Exception
    {
        public WrongTicketException(string message) : base(message)
        {
        }
    }
}
