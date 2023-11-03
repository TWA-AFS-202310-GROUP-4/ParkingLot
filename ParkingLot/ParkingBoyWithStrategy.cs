using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class ParkingBoyWithStrategy
    {
        private IParkingStrategy parkingStrategy;
        private ParkingLot[] parkingLots;

        public ParkingBoyWithStrategy(ParkingLot[] parkingLots, IParkingStrategy parkingStrategy)
        {
            this.parkingStrategy = parkingStrategy;
            this.parkingLots = parkingLots;
        }

        public void ChangeStrategy(IParkingStrategy strategy)
        {
            this.parkingStrategy = strategy;
        }

        public string Park(string car)
        {
            return parkingStrategy.Park(car, parkingLots);
        }

        public string Fetch(string ticket)
        {
            return parkingStrategy.Fetch(ticket, parkingLots);
        }
    }
}
