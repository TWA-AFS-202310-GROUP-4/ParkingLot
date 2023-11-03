namespace ParkingLotTest;

using Parking;
using Xunit;

public class ParkingLotTest
{
    [Fact]
    public void Should_fetch_car_correctly_when_one_customer_parking()
    {
        ParkingLot parkingLot = new ParkingLot();
        var ticket = parkingLot.Park("car1");
        var myCar = parkingLot.Fetch(ticket);

        Assert.Equal("car1", myCar);
    }

    [Fact]
    public void Should_fetch_car_correctly_when_serveal_customer_parking()
    {
        ParkingLot parkingLot = new ParkingLot();
        var ticket1 = parkingLot.Park("car1");
        var ticket2 = parkingLot.Park("car2");
        var car1 = parkingLot.Fetch(ticket1);
        var car2 = parkingLot.Fetch(ticket2);

        Assert.Equal("car1", car1);
        Assert.Equal("car2", car2);
    }

    [Fact]
    public void Should_show_ticket_not_exist_when_ticket_is_wrong()
    {
        ParkingLot parkingLot = new ParkingLot();
        parkingLot.Park("car1");
        var myCar = parkingLot.Fetch("T-car2");

        Assert.Equal("Ticket not exist", myCar);
    }

    [Fact]
    public void Should_show_no_car_fetched_when_no_ticket_provided()
    {
        ParkingLot parkingLot = new ParkingLot();
        parkingLot.Park("car1");
        var myCar = parkingLot.Fetch(null);

        Assert.Equal("No car fetched", myCar);
    }
}
