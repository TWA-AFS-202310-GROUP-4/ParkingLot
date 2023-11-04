using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot;

public class NoAvailablePositionException : Exception
{
    public NoAvailablePositionException() : base("No available position.")
    {
    }
}
