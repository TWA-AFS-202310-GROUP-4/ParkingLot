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
            if (!ticketCarMap.ContainsKey(ticket))
            {
                throw new WrongTicketException("Unrecognized parking ticket.");
            }

            string fetchedCar = ticketCarMap[ticket];
            ticketCarMap.Remove(ticket);

            return fetchedCar;
        }

        public string Park(string carPlate)
        {
            if (currentCapacity >= maxCapacity)
            {
                throw new NoPositionAvaiableException("No available position.");
            }

            currentCapacity++;
            string ticket = "ticket: " + carPlate;
            ticketCarMap.Add(ticket, carPlate);
            return ticket;
        }
    }
}
