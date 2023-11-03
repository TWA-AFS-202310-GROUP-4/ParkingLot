using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class SmartParkingBoy
    {
        private ParkingLot[] parkingLots;

        public SmartParkingBoy(params ParkingLot[] parkingLots)
        {
            this.parkingLots = parkingLots;
        }

        public string Park(string car)
        {
            return parkingLots.MaxBy(pl => pl.GetCapacityLeft()).Park(car);
        }

        public string Fetch(string ticket)
        {
            Exception exception = null;

            foreach (var par in parkingLots)
            {
                try
                {
                    return par.Fetch(ticket);
                }
                catch (Exception ex) { exception = ex; }
            }

            throw exception;
        }
    }
}
