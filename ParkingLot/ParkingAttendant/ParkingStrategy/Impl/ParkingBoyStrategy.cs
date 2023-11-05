using ParkingLot.ParkingBase;
using System.Collections.Generic;

namespace ParkingLot.ParkingAttendant.ParkingStrategy.Impl
{
    public class ParkingBoyStrategy : IParkingStrategy
    {
        public string ParkingCar(string car, List<Parking> parkinglotList)
        {
            foreach (var parkinglot in parkinglotList)
            {
                if (parkinglot.IsAvailable())
                {
                    return parkinglot.Park(car);
                }
            }

            throw new WrongTicketException("No available position.");
        }
    }
}
