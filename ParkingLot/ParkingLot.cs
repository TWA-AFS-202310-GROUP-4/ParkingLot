using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking
{
    public class ParkingLot
    {
        private readonly int maxCapacity = 10;
        private Dictionary<string, string> ticketCarMap = new ();
        private int currentCapacity = 0;

        public string Fetch(string ticket)
        {
            string value;
            string fetchedCar = ticketCarMap.TryGetValue(ticket, out value) ? value : string.Empty;
            if (value != string.Empty)
            {
                ticketCarMap.Remove(ticket);
            }

            return fetchedCar;
        }

        public string Park(string carPlate)
        {
            if (currentCapacity >= maxCapacity)
            {
                return string.Empty;
            }

            currentCapacity++;
            string ticket = "ticket: " + carPlate;
            ticketCarMap.Add(ticket, carPlate);
            return ticket;
        }
    }
}
