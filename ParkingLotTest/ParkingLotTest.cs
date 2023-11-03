namespace ParkingLotTest;

using Parking;
using Xunit;

public class ParkingLotTest
{
    [Fact]
    public void Should_fetch_car_correctly()
    {
        ParkingLot parkingLot = new ParkingLot();
        var ticket = parkingLot.Park("car1");
        var myCar = parkingLot.Fetch(ticket);

        Assert.Equal("car1", myCar);
    }

    [Fact]
    public void Should_show_ticket_not_exist()
    {
        ParkingLot parkingLot = new ParkingLot();
        parkingLot.Park("car1");
        var myCar = parkingLot.Fetch("T-car2");

        Assert.Equal("Ticket not exist", myCar);
    }
}
