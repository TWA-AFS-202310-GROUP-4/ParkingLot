using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;

namespace Parking;

public class ParkingBoy
{
    private ParkingLot parkingLot1 = new ParkingLot();
    private ParkingLot parkingLot2 = new ParkingLot();

    public string Park(string inputCarPlate, string parkingStrategy)
    {
        if (parkingStrategy.Equals("standard"))
        {
            var standardParking = new StandardParking();
            return standardParking.Park(inputCarPlate, parkingLot1, parkingLot2);
        }
        else if (parkingStrategy.Equals("smart"))
        {
            var smartParking = new SmartParking();
            return smartParking.Park(inputCarPlate, parkingLot1 , parkingLot2);
        }

        return null;
    }

    public string Fetch(string inputTicket)
    {
       try
       {
            return parkingLot1.Fetch(inputTicket);
       }
       catch
       {
            return parkingLot2.Fetch(inputTicket);
       }
    }

    public int CheckParkingLot1Capacity()
    {
        return parkingLot1.GetCapacity();
    }

    public int CheckParkingLot2Capacity()
    {
        return parkingLot2.GetCapacity();
    }
}
