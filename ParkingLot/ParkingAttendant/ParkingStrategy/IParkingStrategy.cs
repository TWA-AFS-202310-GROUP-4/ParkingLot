using ParkingLot.ParkingBase;
using System.Collections.Generic;

namespace ParkingLot.ParkingAttendant.ParkingStrategy
{
    public interface IParkingStrategy
    {
        string ParkingCar(string car, List<Parking> parkinglotList);
    }
}
