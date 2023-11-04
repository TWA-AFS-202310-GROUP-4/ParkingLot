using System.Collections.Generic;

namespace Parking;
public class ParkingLot
{
    private Dictionary<string, string> parkingSpace = new Dictionary<string, string>(); //ticket : car
    private int capacity = 10;

    public int GetCapacity()
    {
        return capacity;
    }

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
