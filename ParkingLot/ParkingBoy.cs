using System.Reflection.Metadata.Ecma335;

namespace Parking;

public class ParkingBoy
{
    private ParkingLot parkingLot1 = new ParkingLot();
    private ParkingLot parkingLot2 = new ParkingLot();

    public string Park(string inputCarPlate)
    {
        if (parkingLot1.GetCapacity() > 0)
        {
            return parkingLot1.Park(inputCarPlate);
        }

        return parkingLot2.Park(inputCarPlate);
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
