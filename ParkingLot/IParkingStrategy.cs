using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking;

public interface IParkingStrategy
{
    public string Park(string inputCarPlate, ParkingLot parkingLot1, ParkingLot parkingLot2);
}
