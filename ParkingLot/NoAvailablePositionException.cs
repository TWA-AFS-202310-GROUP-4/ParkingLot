using System;

namespace Parking;

public class NoAvailablePositionException : Exception
{
    public NoAvailablePositionException() : base("No available position.")
    {
    }
}
