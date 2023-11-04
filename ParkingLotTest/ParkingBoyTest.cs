using Parking;
using Xunit;

namespace ParkingLotTest;

public class ParkingBoyTest
{
    [Fact]
    public void Should_return_a_parking_ticket_when_park_a_car_given_a_car()
    {
        ParkingBoy parkingBoy = new ParkingBoy();
        var ticket = parkingBoy.Park("car1");

        Assert.Equal("T-car1", ticket);
    }

    [Fact]
    public void Should_rerturn_car_correctly_when_fetch_the_car_given_a_parking_ticket()
    {
        ParkingBoy parkingLot = new ParkingBoy();
        var ticket = parkingLot.Park("car1");
        var myCar = parkingLot.Fetch(ticket);

        Assert.Equal("car1", myCar);
    }

    [Fact]
    public void Should_return_cars_correctly_when_fetch_cars_given_parking_tickets()
    {
        ParkingBoy parkingLot = new ParkingBoy();
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
        ParkingBoy parkingLot = new ParkingBoy();
        parkingLot.Park("car1");
        Assert.Throws<UnrecognizedParkingTicketException>(() => parkingLot.Fetch("T-car2"));
    }

    [Fact]
    public void Should_return_null_when_fetch_the_car_given_a_used_ticket()
    {
        ParkingBoy parkingLot = new ParkingBoy();
        parkingLot.Park("car1");
        parkingLot.Fetch("T-car1");

        Assert.Throws<UnrecognizedParkingTicketException>(() => parkingLot.Fetch("T-car1"));
    }

    [Fact]
    public void Should_return_null_when_parking_lot_is_full_given_a_car()
    {
        ParkingBoy parkingLot = new ParkingBoy();

        for (int i = 1; i <= 10; i++)
        {
            string carPlate = "car" + i.ToString();
            parkingLot.Park(carPlate);
        }

        Assert.Throws<NoAvailablePositionException>(() => parkingLot.Park("car11"));
    }
}
