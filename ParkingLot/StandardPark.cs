using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking
{
    public class StandardPark : IPark
    {
        private ParkingLot parkingLot;
        private ParkingLot parkingLot2;
        private int maxCapacity = 10;

        public StandardPark(ParkingLot p1, ParkingLot p2)
        {
            this.parkingLot = p1;
            this.parkingLot2 = p2;
        }

        public string Park(string car)
        {
            return parkingLot.GetCapacity() >= maxCapacity ? parkingLot2.Park(car) : parkingLot.Park(car);
        }
    }
}
