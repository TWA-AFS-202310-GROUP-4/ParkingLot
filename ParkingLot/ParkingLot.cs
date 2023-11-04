using ParkingLot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking;
public class ParkingLot
{
    private Dictionary<string, string> parkingSpace = new Dictionary<string, string>(); //ticket : car
    private int capacity = 10;

    public string Park(string inputCarPlate)
    {
        if (capacity <= 0)
        {
            throw new NoAvailablePositionException();
        }

        var ticket = "T-" + inputCarPlate;
        parkingSpace.Add(ticket, inputCarPlate);
        capacity--;
        return ticket;
    }

    public string Fetch(string inputTicket)
    {
        if (inputTicket == null)
        {
            return null;
        }

        if (parkingSpace.ContainsKey(inputTicket))
        {
            var carPlate = parkingSpace.GetValueOrDefault(inputTicket);
            parkingSpace.Remove(inputTicket);
            capacity++;
            return carPlate;
        }

        throw new UnrecognizedParkingTicketException();
    }
}
