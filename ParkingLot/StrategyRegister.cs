using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class StrategyRegister
    {
        public delegate ParkingLot SelectParkingLotDelegate(List<ParkingLot> parkingLots);

        public static ParkingLot SelectParkingLotStandard(List<ParkingLot> parkingLots)
        {
            var filteredParkingLot = parkingLots.Where(parkingLot => parkingLot.EmptySlots > 0).ToList();
            return filteredParkingLot.Any() ? filteredParkingLot.First() : null;
        }

        public static ParkingLot SelectParkingLotSmart(List<ParkingLot> parkingLots)
        {
            var filteredParkingLot = parkingLots.Where(parkingLot => parkingLot.EmptySlots > 0).ToList();
            return filteredParkingLot.Any() ? filteredParkingLot.OrderByDescending(parkingLot => parkingLot.EmptySlots).First() : null;
        }
    }
}
