using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Parking
{
    public class ParkingBoy
    {
        private ParkingLot parkingLot = new ParkingLot();
        private ParkingLot parkingLot2 = new ParkingLot();
        private int maxCapacity = 10;

        public string Park(string car, string strategy)
        {
            if (strategy.Equals("smart"))
            {
                var smartPark = new SmarkPark(parkingLot, parkingLot2);
                return smartPark.Park(car);
            }

            var standardPark = new StandardPark(parkingLot, parkingLot2);
            return standardPark.Park(car);
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

        public int GetParkingLot1Capacity()
        {
            return parkingLot.GetCapacity();
        }

        public int GetParkingLot2Capacity()
        {
            return parkingLot2.GetCapacity();
        }
    }
}
