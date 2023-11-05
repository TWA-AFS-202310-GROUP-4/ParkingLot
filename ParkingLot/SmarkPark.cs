using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Parking
{
    public class SmarkPark : IPark
    {
        private ParkingLot parkingLot;
        private ParkingLot parkingLot2;

        public SmarkPark(ParkingLot p1, ParkingLot p2)
        {
            this.parkingLot = p1;
            this.parkingLot2 = p2;
        }

        public string Park(string car)
        {
            return parkingLot.GetCapacity() <= parkingLot2.GetCapacity() ? parkingLot.Park(car) : parkingLot2.Park(car);
        }
    }
}
