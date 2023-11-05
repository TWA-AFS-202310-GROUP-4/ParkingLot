using ParkingLot.ParkingBase;
using System.Collections.Generic;
using System.Linq;

namespace ParkingLot.ParkingAttendant.ParkingStrategy.Impl
{
    public class SmartParkingBoyStrategy : IParkingStrategy
    {
        public string ParkingCar(string car, List<Parking> parkinglotList)
        {
            int maxIndex = parkinglotList.Select((parkinglot, index) => new { Index = index, Value = parkinglot.Capacity }).OrderByDescending(item => item.Value).First().Index;
            return parkinglotList[maxIndex].Park(car);
        }
    }
}
