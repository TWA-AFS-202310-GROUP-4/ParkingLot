using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking;

public class ParkingLot
{
    private Dictionary<string, string> parkingSpace = new Dictionary<string, string>();

    public string Park(string inputCarPlate)
    {
        if (parkingSpace.ContainsKey(inputCarPlate))
        {
            return "duplicate car";
        }

        var ticket = "T-" + inputCarPlate;
        parkingSpace.Add(ticket, inputCarPlate);
        return ticket;
    }

    public string Fetch(string inputTicket)
    {
        if (inputTicket == null)
        {
            return "No car fetched";
        }

        if (parkingSpace.ContainsKey(inputTicket))
        {
            var carPlate = parkingSpace.GetValueOrDefault(inputTicket);
            parkingSpace.Remove(inputTicket);
            return carPlate;
        }
        else
        {
            return "Ticket not exist";
        }
    }
}
