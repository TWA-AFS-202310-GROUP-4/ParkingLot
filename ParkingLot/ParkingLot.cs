namespace ParkingLotWork
{
    using global::ParkingLot.Exception;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Reflection.Metadata.Ecma335;

    public class ParkingLot
    {
        private Dictionary<string, string> ticket2car = new Dictionary<string, string>();
        private int capacity = 10;
        public int Capacity
        {
            get => capacity;
            set
            {
                capacity = value;
            }
        }

        public string Fetch(string ticket)
        {
            string car;
            if (ticket2car.ContainsKey(ticket))
            {
                car = ticket2car[ticket];
                ticket2car.Remove(ticket);
                capacity++;
            }
            else
            {
                throw new ParkingException("Unrecognized parking ticket.");
            }

            return car;
        }

        public string Park(string car)
        {
            if (capacity <= 0)
            {
                throw new ParkingException("No available position.");
            }

            string ticket = "T-" + car;
            ticket2car[ticket] = car;
            capacity--;
            return ticket;
        }
    }
}
