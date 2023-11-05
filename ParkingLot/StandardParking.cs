using Parking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking;

public class StandardParking : IParkingStrategy
{
    public string Park(string inputCarPlate, ParkingLot parkingLot1, ParkingLot parkingLot2)
    {
        if (parkingLot1.GetCapacity() > 0)
        {
            return parkingLot1.Park(inputCarPlate);
        }

        return parkingLot2.Park(inputCarPlate);
    }
}
