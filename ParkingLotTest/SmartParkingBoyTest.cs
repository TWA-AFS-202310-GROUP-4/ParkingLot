using Parking;
using Xunit;

namespace ParkingLotTest;

public class SmartParkingBoyTest
{
   /* [Fact]
    public void Should_return_a_parking_ticket_when_park_a_car_given_a_car()
    {
        SmartParkingBoy parkingBoy = new SmartParkingBoy();
        var ticket = parkingBoy.Park("car1");

        Assert.Equal("T-car1", ticket);
    }

    [Fact]
    public void Should_rerturn_car_correctly_when_fetch_the_car_given_a_parking_ticket()
    {
        SmartParkingBoy parkingBoy = new SmartParkingBoy();
        var ticket = parkingBoy.Park("car1");
        var myCar = parkingBoy.Fetch(ticket);

        Assert.Equal("car1", myCar);
    }

    [Fact]
    public void Should_return_cars_correctly_when_fetch_cars_given_parking_tickets()
    {
        SmartParkingBoy parkingBoy = new SmartParkingBoy();
        var ticket1 = parkingBoy.Park("car1");
        var ticket2 = parkingBoy.Park("car2");
        var car1 = parkingBoy.Fetch(ticket1);
        var car2 = parkingBoy.Fetch(ticket2);

        Assert.Equal("car1", car1);
        Assert.Equal("car2", car2);
    }

    [Fact]
    public void Should_catch_UnrecognizedParkingTicketException_when_fetch_the_car_given_a_wrong_ticket()
    {
        SmartParkingBoy parkingBoy = new SmartParkingBoy();
        parkingBoy.Park("car1");
        Assert.Throws<UnrecognizedParkingTicketException>(() => parkingBoy.Fetch("T-car2"));
    }

    [Fact]
    public void Should_catch_UnrecognizedParkingTicketException_when_fetch_the_car_given_a_used_ticket()
    {
        SmartParkingBoy parkingBoy = new SmartParkingBoy();
        parkingBoy.Park("car1");
        parkingBoy.Fetch("T-car1");

        Assert.Throws<UnrecognizedParkingTicketException>(() => parkingBoy.Fetch("T-car1"));
    }

    [Fact]
    public void Should_catch_NoAvailablePositionException_when_parking_lot_is_full_given_a_car()
    {
        SmartParkingBoy parkingBoy = new SmartParkingBoy();

        for (int i = 1; i <= 20; i++)
        {
            string carPlate = "car" + i.ToString();
            parkingBoy.Park(carPlate);
        }

        Assert.Throws<NoAvailablePositionException>(() => parkingBoy.Park("car21"));
    }

    [Fact]
    public void Should_park_to_second_parking_log_when_park_a_car_given_a_parking_boy_and_first_lot_is_full()
    {
        SmartParkingBoy parkingBoy = new SmartParkingBoy();
        for (int i = 1; i <= 20; i++)
        {
            string carPlate = "car" + i.ToString();
            parkingBoy.Park(carPlate);
        }

        parkingBoy.Fetch("T-car20");
        Assert.Equal(1, parkingBoy.CheckParkingLot2Capacity());
        parkingBoy.Park("newCar");
        Assert.Equal(0, parkingBoy.CheckParkingLot2Capacity());
    }

    [Fact]
    public void Should_fetch_car_from_correct_lot_when_fetch_two_cars_given_a_parking_boy_and_both_lots_parked_car()
    {
        SmartParkingBoy parkingBoy = new SmartParkingBoy();
        parkingBoy.Park("car1");
        parkingBoy.Park("car2");

        var car1 = parkingBoy.Fetch("T-car1");
        var car2 = parkingBoy.Fetch("T-car2");

        Assert.Equal("car1", car1);
        Assert.Equal("car2", car2);
    }

    [Fact]
    public void Should_park_car_to_more_space_lot_when_park_a_car_given_a_parking_boy_and_first_lot_has_more_space()
    {
        SmartParkingBoy parkingBoy = new SmartParkingBoy();
        parkingBoy.Park("car1");
        parkingBoy.Park("car2");
        parkingBoy.Park("car3");

        Assert.Equal(8, parkingBoy.CheckParkingLot1Capacity());
        Assert.Equal(9, parkingBoy.CheckParkingLot2Capacity());

        parkingBoy.Park("car4");
        Assert.Equal(8, parkingBoy.CheckParkingLot2Capacity());
    }*/
}
