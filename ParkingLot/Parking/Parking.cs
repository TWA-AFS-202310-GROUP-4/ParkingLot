using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Parking
{
    public class Parking
    {
        private Dictionary<string, string> parkingRecord;
        public Parking()
        {
            parkingRecord = new Dictionary<string, string>();
        }

        public string Park(string car)
        {
            var ticket = car + "-ticket";
            parkingRecord.Add(ticket, car);
            return ticket;
        }

        public string FectchCar(string ticket)
        {
            return parkingRecord[ticket];
        }
    }
}
