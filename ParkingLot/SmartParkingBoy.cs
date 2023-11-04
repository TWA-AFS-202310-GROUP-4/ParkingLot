using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking;

public class SmartParkingBoy
{
    private ParkingLot parkingLot1 = new ParkingLot();
    private ParkingLot parkingLot2 = new ParkingLot();

    public string Park(string inputCarPlate)
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
