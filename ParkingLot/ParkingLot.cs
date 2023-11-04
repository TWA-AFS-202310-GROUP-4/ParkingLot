namespace ParkingLotWork
{
    using global::ParkingLot.Exception;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public class ParkingLot
    {
        private Dictionary<string, string> ticket2car = new Dictionary<string, string>();
        private int capacity = 10;
        public string Fetch(string ticket)
        {
            string carmessage;
            if (ticket2car.ContainsKey(ticket))
            {
                carmessage = ticket2car[ticket];
                ticket2car.Remove(ticket);
                capacity++;
            }
            else
            {
                throw new ParkingException("Unrecognized parking ticket.");
            }

            return carmessage;
        }

        public string Park(string car)
        {
            if (capacity <= 0)
            {
                throw new ParkingException("No available position.");
            }

            capacity--;
            string ticket = "T-" + car;
            ticket2car[ticket] = car;
            return ticket;
        }
    }
}
