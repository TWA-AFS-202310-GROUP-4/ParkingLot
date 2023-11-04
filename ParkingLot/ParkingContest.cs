using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class ParkingContest
    {
        private IParkingStrategy parkingStrategy;
        public void SetStrategy(IParkingStrategy parkingStrategy)
        {
            this.parkingStrategy = parkingStrategy;
        }

        public string ExecuteStrategy(string car)
        {
            return parkingStrategy.Park(car);
        }
    }
}
