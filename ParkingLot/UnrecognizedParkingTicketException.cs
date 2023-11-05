using System;

namespace Parking;

public class UnrecognizedParkingTicketException : Exception
{
    public UnrecognizedParkingTicketException() : base("Unrecognized parking ticket")
    {
    }
}
