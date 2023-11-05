using Parking;
using Xunit;

namespace ParkingLotTest;

public class ParkingBoyTest
{
    [Fact]
    public void Should_return_a_parking_ticket_when_park_a_car_given_a_car_and_standard_parking()
    {
        ParkingBoy parkingBoy = new ParkingBoy();
        var ticket = parkingBoy.Park("car1", "standard");

        Assert.Equal("T-car1", ticket);
    }

    [Fact]
    public void Should_rerturn_car_correctly_when_fetch_the_car_given_a_parking_ticket_and_standard_parking()
    {
        ParkingBoy parkingBoy = new ParkingBoy();
        var ticket = parkingBoy.Park("car1", "standard");
        var myCar = parkingBoy.Fetch(ticket);

        Assert.Equal("car1", myCar);
    }

    [Fact]
    public void Should_return_cars_correctly_when_fetch_cars_given_parking_tickets_and_standard_parking()
    {
        ParkingBoy parkingBoy = new ParkingBoy();
        var ticket1 = parkingBoy.Park("car1", "standard");
        var ticket2 = parkingBoy.Park("car2", "standard");
        var car1 = parkingBoy.Fetch(ticket1);
        var car2 = parkingBoy.Fetch(ticket2);

        Assert.Equal("car1", car1);
        Assert.Equal("car2", car2);
    }

    [Fact]
    public void Should_throw_UnrecognizedParkingTicketException_when_fetch_the_car_given_a_wrong_ticket_and_standard_parking()
    {
        ParkingBoy parkingBoy = new ParkingBoy();
        parkingBoy.Park("car1", "standard");
        Assert.Throws<UnrecognizedParkingTicketException>(() => parkingBoy.Fetch("T-car2"));
    }

    [Fact]
    public void Should_throw_UnrecognizedParkingTicketException_when_fetch_the_car_given_a_used_ticket_and_standard_parking()
    {
        ParkingBoy parkingBoy = new ParkingBoy();
        parkingBoy.Park("car1", "standard");
        parkingBoy.Fetch("T-car1");

        Assert.Throws<UnrecognizedParkingTicketException>(() => parkingBoy.Fetch("T-car1"));
    }

    [Fact]
    public void Should_throw_NoAvailablePositionException_when_parking_lot_is_full_given_a_car_and_standard_parking()
    {
        ParkingBoy parkingBoy = new ParkingBoy();

        for (int i = 1; i <= 20; i++)
        {
            string carPlate = "car" + i.ToString();
            parkingBoy.Park(carPlate, "standard");
        }

        Assert.Throws<NoAvailablePositionException>(() => parkingBoy.Park("car21", "standard"));
    }

    [Fact]
    public void Should_park_to_first_parking_log_when_park_a_car_given_a_parking_boy_and_two_empty_lots_and_standard_parking()
    {
        ParkingBoy parkingBoy = new ParkingBoy();
        parkingBoy.Park("car1", "standard");
        Assert.Equal(9, parkingBoy.CheckParkingLot1Capacity());
        Assert.Equal(10, parkingBoy.CheckParkingLot2Capacity());
    }

    [Fact]
    public void Should_park_to_second_parking_log_when_park_a_car_given_a_parking_boy_and_first_lot_is_full_and_standard_parking()
    {
        ParkingBoy parkingBoy = new ParkingBoy();
        for (int i = 1; i <= 10; i++)
        {
            string carPlate = "car" + i.ToString();
            parkingBoy.Park(carPlate, "standard");
        }

        parkingBoy.Park("car11", "standard");
        Assert.Equal(0, parkingBoy.CheckParkingLot1Capacity());
        Assert.Equal(9, parkingBoy.CheckParkingLot2Capacity());
    }

    [Fact]
    public void Should_fetch_car_from_correct_lot_when_fetch_two_cars_given_a_parking_boy_and_both_lots_parked_car_and_standard_parking()
    {
        ParkingBoy parkingBoy = new ParkingBoy();
        for (int i = 1; i <= 10; i++)
        {
            string carPlate = "car" + i.ToString();
            parkingBoy.Park(carPlate, "standard");
        }

        parkingBoy.Park("car11", "standard");
        var car7 = parkingBoy.Fetch("T-car7");
        var car11 = parkingBoy.Fetch("T-car11");

        Assert.Equal("car7", car7);
        Assert.Equal("car11", car11);
    }

    [Fact]
    public void Should_return_a_parking_ticket_when_park_a_car_given_a_car_and_smart_parking()
    {
        ParkingBoy parkingBoy = new ParkingBoy();
        var ticket = parkingBoy.Park("car1", "smart");

        Assert.Equal("T-car1", ticket);
    }

    [Fact]
    public void Should_rerturn_car_correctly_when_fetch_the_car_given_a_parking_ticket_and_smart_parking()
    {
        ParkingBoy parkingBoy = new ParkingBoy();
        var ticket = parkingBoy.Park("car1", "smart");
        var myCar = parkingBoy.Fetch(ticket);

        Assert.Equal("car1", myCar);
    }

    [Fact]
    public void Should_return_cars_correctly_when_fetch_cars_given_parking_tickets_and_smart_parking()
    {
        ParkingBoy parkingBoy = new ParkingBoy();
        var ticket1 = parkingBoy.Park("car1", "smart");
        var ticket2 = parkingBoy.Park("car2", "smart");
        var car1 = parkingBoy.Fetch(ticket1);
        var car2 = parkingBoy.Fetch(ticket2);

        Assert.Equal("car1", car1);
        Assert.Equal("car2", car2);
    }

    [Fact]
    public void Should_throw_UnrecognizedParkingTicketException_when_fetch_the_car_given_a_wrong_ticket_and_smart_parking()
    {
        ParkingBoy parkingBoy = new ParkingBoy();
        parkingBoy.Park("car1", "smart");
        Assert.Throws<UnrecognizedParkingTicketException>(() => parkingBoy.Fetch("T-car2"));
    }

    [Fact]
    public void Should_throw_UnrecognizedParkingTicketException_when_fetch_the_car_given_a_used_ticket_and_smart_parking()
    {
        ParkingBoy parkingBoy = new ParkingBoy();
        parkingBoy.Park("car1", "smart");
        parkingBoy.Fetch("T-car1");

        Assert.Throws<UnrecognizedParkingTicketException>(() => parkingBoy.Fetch("T-car1"));
    }

    [Fact]
    public void Should_throw_NoAvailablePositionException_when_parking_lot_is_full_given_a_car_and_smart_parking()
    {
        ParkingBoy parkingBoy = new ParkingBoy();

        for (int i = 1; i <= 20; i++)
        {
            string carPlate = "car" + i.ToString();
            parkingBoy.Park(carPlate, "smart");
        }

        Assert.Throws<NoAvailablePositionException>(() => parkingBoy.Park("car21", "smart"));
    }

    [Fact]
    public void Should_park_to_second_parking_log_when_park_a_car_given_a_parking_boy_and_first_lot_is_full_and_smart_parking()
    {
        ParkingBoy parkingBoy = new ParkingBoy();
        for (int i = 1; i <= 20; i++)
        {
            string carPlate = "car" + i.ToString();
            parkingBoy.Park(carPlate, "smart");
        }

        parkingBoy.Fetch("T-car20");
        Assert.Equal(1, parkingBoy.CheckParkingLot2Capacity());
        parkingBoy.Park("newCar", "smart");
        Assert.Equal(0, parkingBoy.CheckParkingLot2Capacity());
    }

    [Fact]
    public void Should_fetch_car_from_correct_lot_when_fetch_two_cars_given_a_parking_boy_and_both_lots_parked_car_and_smart_parking()
    {
        ParkingBoy parkingBoy = new ParkingBoy();
        parkingBoy.Park("car1", "smart");
        parkingBoy.Park("car2", "smart");

        var car1 = parkingBoy.Fetch("T-car1");
        var car2 = parkingBoy.Fetch("T-car2");

        Assert.Equal("car1", car1);
        Assert.Equal("car2", car2);
    }

    [Fact]
    public void Should_park_car_to_more_space_lot_when_park_a_car_given_a_parking_boy_and_first_lot_has_more_space_and_smart_parking()
    {
        ParkingBoy parkingBoy = new ParkingBoy();
        parkingBoy.Park("car1", "smart");
        parkingBoy.Park("car2", "smart");
        parkingBoy.Park("car3", "smart");

        Assert.Equal(8, parkingBoy.CheckParkingLot1Capacity());
        Assert.Equal(9, parkingBoy.CheckParkingLot2Capacity());

        parkingBoy.Park("car4", "smart");
        Assert.Equal(8, parkingBoy.CheckParkingLot2Capacity());
    }
}
