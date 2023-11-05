using ParkingLot.ParkingBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
