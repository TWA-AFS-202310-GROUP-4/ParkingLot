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
        private ParkingLot parkingLot;
        private ParkingLot parkingLot2 = new ParkingLot();
        private int maxCapacity = 10;
        public ParkingBoy(ParkingLot parkingLot)
        {
            this.parkingLot = parkingLot;
        }

        public string Park(string car)
        {
            return parkingLot.GetCapacity() >= maxCapacity ? parkingLot2.Park(car) : parkingLot.Park(car);
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
