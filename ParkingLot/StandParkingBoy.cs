using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class StandParkingBoy
    {
        private ParkingLot[] parkingLots;

        public StandParkingBoy(params ParkingLot[] parkingLots)
        {
            this.parkingLots = parkingLots;
        }

        public string Park(string car)
        {
            Exception exception = null;

            foreach (var par in parkingLots)
            {
                try
                {
                    var ticket = par.Park(car);
                    return ticket;
                }
                catch (Exception ex) { exception = ex; }
            }

            throw exception;
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
