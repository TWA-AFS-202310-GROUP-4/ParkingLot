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

        public int Capacity { get; set; } = 10;

        public string Park(string car)
        {
            if (Capacity == 0)
            {
                return null;
            }

            Capacity--;
            var ticket = car + "-ticket";
            parkingRecord.Add(ticket, car);
            return ticket;
        }

        public string FectchCar(string ticket)
        {
            if (ticket == null || !parkingRecord.ContainsKey(ticket))
            {
                return null;
            }

            var res = parkingRecord[ticket];
            parkingRecord.Remove(ticket);
            Capacity++;
            return res;
        }
    }
}
