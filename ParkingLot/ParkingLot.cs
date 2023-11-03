namespace ParkingLot
{
    using System;
    using System.Collections.Generic;

    public class ParkingLot
    {
        private Dictionary<string, string> ticketCarDict = new ();

        public string Fetch(string ticket)
        {
            string car;
            this.ticketCarDict.TryGetValue(ticket, out car);
            this.ticketCarDict.Remove(ticket);

            return car;
        }

        public string Park(string car)
        {
            var ticket = Guid.NewGuid().ToString();
            this.ticketCarDict[ticket] = car;
            return ticket;
        }
    }
}
