namespace Parking;

public class ParkingBoy
{
    private ParkingLot parkingLot = new ParkingLot();

    public string Park(string inputCarPlate)
    {
        return parkingLot.Park(inputCarPlate);
    }

    public string Fetch(string inputTicket)
    {
       return parkingLot.Fetch(inputTicket);
    }
}
