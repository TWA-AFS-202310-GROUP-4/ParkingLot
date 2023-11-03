using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking
{
    public class ParkingLot
    {
        private Dictionary<string, string> parkedCarsInfo = new Dictionary<string, string>();

        public string Fetch(string ticket)
        {
            return parkedCarsInfo[ticket];
        }

        public string Park(string carPlate)
        {
            string ticket = "ticket: " + carPlate;
            parkedCarsInfo.Add(ticket, carPlate);
            return ticket;
        }
    }
}
