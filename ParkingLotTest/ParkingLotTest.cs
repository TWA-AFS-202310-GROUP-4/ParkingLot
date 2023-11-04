using Parking;
using Xunit;

namespace ParkingLotTest
{
    public class ParkingLotTest
    {
        [Fact]
        public void Should_get_same_car_when_fetch_car_by_ticket()
        {
            string car = "car1";
            var parkingLot = new ParkingLot();
            string ticket = parkingLot.Park(car);
            string result = parkingLot.Fetch(ticket);

            Assert.Equal("car1", result);
        }

        [Fact]
        public void Should_get_ticket_when_park_given_a_car()
        {
            string car = "car1";
            var parkingLot = new ParkingLot();
            string ticket = parkingLot.Park(car);

            Assert.Equal("ticket: car1", ticket);
        }

        [Fact]
        public void Should_get_same_car_when_fetch_car_by_ticket_gvien_two_customers()
        {
            string car = "car1";
            string car2 = "car2";

            var parkingLot = new ParkingLot();
            string ticket = parkingLot.Park(car);
            string ticket2 = parkingLot.Park(car2);

            string result1 = parkingLot.Fetch(ticket);
            string result2 = parkingLot.Fetch(ticket2);

            Assert.Equal("car1", result1);
            Assert.Equal("car2", result2);
        }

        [Fact]
        public void Should_get_empty_when_fetch_car_with_wrong_ticket_given_one_car()
        {
            var parkingLot = new ParkingLot();
            string wrongTicket = "wrong";

            string result1 = parkingLot.Fetch(wrongTicket);

            Assert.Equal(string.Empty, result1);
        }

        [Fact]
        public void Should_return_nothing_when_fetch_given_a_used_ticket()
        {
            //Given
            var parkingLot = new ParkingLot();
            string car = "car";
            string ticket = parkingLot.Park(car);
            parkingLot.Fetch(ticket);

            //When
            string fetchedCar = parkingLot.Fetch(ticket);

            //Then
            Assert.Equal(string.Empty, fetchedCar);
        }
    }
}
