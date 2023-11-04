using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking
{
    public class SmartParkingBoy
    {
        private ParkingLot parkingLot = new ParkingLot();
        private ParkingLot parkingLot2 = new ParkingLot();
        private int maxCapacity = 10;

        public string Park(string car)
        {
            return parkingLot.GetCapacity() <= parkingLot2.GetCapacity() ? parkingLot.Park(car) : parkingLot2.Park(car);
        }

        public int GetParkingLot1Capacity()
        {
            return parkingLot.GetCapacity();
        }

        public int GetParkingLot2Capacity()
        {
            return parkingLot2.GetCapacity();
        }

        public string Fetch(string ticket)
        {
            try
            {
                return parkingLot.Fetch(ticket);
            }
            catch
            {
                return parkingLot2.Fetch(ticket);
            }
        }
    }
}
