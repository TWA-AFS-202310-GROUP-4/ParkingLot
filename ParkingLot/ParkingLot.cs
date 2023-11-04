namespace ParkingLot
{
    using System;
    using System.Collections.Generic;

    public class ParkingLot
    {
        private Dictionary<string, string> ticket2car = new Dictionary<string, string>();
        private int capacity = 10;
        public string Fetch(string ticket)
        {
            string carmessage = string.Empty;
            if (ticket2car.ContainsKey(ticket))
            {
                carmessage = ticket2car[ticket];
                ticket2car.Remove(ticket);
                capacity++;
            }
            else
            {
                carmessage = "wrong tickets";
            }

            return carmessage;
        }

        public string Park(string car)
        {
            if (capacity > 0)
            {
                capacity--;
                string ticket = "T-" + car;
                ticket2car[ticket] = car;
                return ticket;
            }

            return "no position";
        }
    }
}
