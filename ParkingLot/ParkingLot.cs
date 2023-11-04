using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking
{
    public class ParkingLot
    {
        private readonly Dictionary<string, string> parkedCarsInfo = new ();

        public string Fetch(string ticket)
        {
            string value;
            string fetchedCar = parkedCarsInfo.TryGetValue(ticket, out value) ? value : string.Empty;
            if (value != string.Empty)
            {
                parkedCarsInfo.Remove(ticket);
            }

            return fetchedCar;
        }

        public string Park(string carPlate)
        {
            string ticket = "ticket: " + carPlate;
            parkedCarsInfo.Add(ticket, carPlate);
            return ticket;
        }
    }
}
