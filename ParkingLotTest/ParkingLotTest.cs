namespace ParkingLotTest;

using Parking;
using Xunit;

public class ParkingLotTest
{
    [Fact]
    public void Should_return_a_parking_ticket_when_park_a_car()
    {
        ParkingLot parkingLot = new ParkingLot();
        var ticket = parkingLot.Park("car1");

        Assert.Equal("T-car1", ticket);
    }

    [Fact]
    public void Should_fetch_car_correctly_when_one_customer_parking()
    {
        ParkingLot parkingLot = new ParkingLot();
        var ticket = parkingLot.Park("car1");
        var myCar = parkingLot.Fetch(ticket);

        Assert.Equal("car1", myCar);
    }

    [Fact]
    public void Should_fetch_cars_correctly_when_serveal_customers_parking()
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
    public void Should_return_null_when_fetch_the_car_given_a_wrong_ticket()
    {
        ParkingLot parkingLot = new ParkingLot();
        parkingLot.Park("car1");
        var myCar = parkingLot.Fetch("T-car2");

        Assert.Null(myCar);
    }
}
