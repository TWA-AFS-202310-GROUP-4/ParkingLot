namespace ParkingLotTest;

using Parking;
using ParkingLot;
using System.Net.Sockets;
using Xunit;
using Xunit.Sdk;

public class ParkingLotTest
{
    [Fact]
    public void Should_return_a_parking_ticket_when_park_a_car_given_a_car()
    {
        ParkingLot parkingLot = new ParkingLot();
        var ticket = parkingLot.Park("car1");

        Assert.Equal("T-car1", ticket);
    }

    [Fact]
    public void Should_rerturn_car_correctly_when_fetch_the_car_given_a_parking_ticket()
    {
        ParkingLot parkingLot = new ParkingLot();
        var ticket = parkingLot.Park("car1");
        var myCar = parkingLot.Fetch(ticket);

        Assert.Equal("car1", myCar);
    }

    [Fact]
    public void Should_return_cars_correctly_when_fetch_cars_given_parking_tickets()
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
        Assert.Throws<UnrecognizedParkingTicketException>(() => parkingLot.Fetch("T-car2"));
    }

    [Fact]
    public void Should_return_null_when_fetch_the_car_given_a_used_ticket()
    {
        ParkingLot parkingLot = new ParkingLot();
        parkingLot.Park("car1");
        parkingLot.Fetch("T-car1");

        Assert.Throws<UnrecognizedParkingTicketException>(() => parkingLot.Fetch("T-car1"));
    }

    [Fact]
    public void Should_return_null_when_parking_lot_is_full_given_a_car()
    {
        ParkingLot parkingLot = new ParkingLot();

        for (int i = 1; i <= 10; i++)
        {
            string carPlate = "car" + i.ToString();
            parkingLot.Park(carPlate);
        }

        var ticket = parkingLot.Park("car11");
        Assert.Null(ticket);
    }
}
