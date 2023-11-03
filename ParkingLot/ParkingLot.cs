namespace ParkingLot
{
    using System;
    using System.Collections.Generic;

    public class ParkingLot
    {
        private Dictionary<string, string> ticket2car = new Dictionary<string, string>();   
        public string Fetch(string ticket)
        {
            return ticket2car[ticket];
        }

        public string Park(string car)
        {
            string ticket = "T-" + car;
            ticket2car[ticket] = car;
            return ticket;
        }
    }
}
