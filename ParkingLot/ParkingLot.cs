using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking;

public class ParkingLot
{
    private string carPlate;
    private string ticket;

    public string Park(string carPlate)
    {
        this.carPlate = carPlate;
        ticket = "T-" + carPlate;
        return ticket;
    }

    public string Fetch(string inputTicket)
    {
        if (inputTicket.Equals(ticket))
        {
            return carPlate;
        }
        else
        {
            return "Ticket not exist";
        }
    }
}
