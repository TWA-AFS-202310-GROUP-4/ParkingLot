using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking;

public class SmartParking : IParkingStrategy
{
    public string Park(string inputCarPlate, ParkingLot parkingLot1, ParkingLot parkingLot2)
    {
        if (parkingLot1.GetCapacity() == 0 && parkingLot2.GetCapacity() == 0)
        {
            throw new NoAvailablePositionException();
        }

        if (parkingLot1.GetCapacity() >= parkingLot2.GetCapacity())
        {
            return parkingLot1.Park(inputCarPlate);
        }
        else
        {
            return parkingLot2.Park(inputCarPlate);
        }
    }
}
