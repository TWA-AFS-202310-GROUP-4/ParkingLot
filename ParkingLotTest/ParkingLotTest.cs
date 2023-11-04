using Parking;
using Xunit;

namespace ParkingLotTest
{
    public class ParkingLotTest
    {
        [Fact]
        public void Should_get_same_car_when_fetch_car_by_ticket()
        {
            //Given
            string car = "car1";
            var parkingLot = new ParkingLot();
            string ticket = parkingLot.Park(car);
            //When
            string result = parkingLot.Fetch(ticket);
            //Then
            Assert.Equal("car1", result);
        }

        [Fact]
        public void Should_get_ticket_when_park_given_a_car()
        {
            //Given
            string car = "car1";
            var parkingLot = new ParkingLot();
            //When
            string ticket = parkingLot.Park(car);
            //Then
            Assert.Equal("ticket: car1", ticket);
        }

        [Fact]
        public void Should_get_same_car_when_fetch_car_by_ticket_gvien_two_customers()
        {
            //Given
            string car = "car1";
            string car2 = "car2";

            var parkingLot = new ParkingLot();
            string ticket = parkingLot.Park(car);
            string ticket2 = parkingLot.Park(car2);
            //When
            string result1 = parkingLot.Fetch(ticket);
            string result2 = parkingLot.Fetch(ticket2);
            //Then
            Assert.Equal("car1", result1);
            Assert.Equal("car2", result2);
        }

        [Fact]
        public void Should_get_error_msg_when_fetch_car_with_wrong_ticket_given_one_car()
        {
            //Given
            var parkingLot = new ParkingLot();
            string wrongTicket = "wrong";
            //When
            //Then
            Assert.Throws<WrongTicketException>(() => parkingLot.Fetch(wrongTicket));
        }

        [Fact]
        public void Should_return_error_msg_when_fetch_given_a_used_ticket()
        {
            //Given
            var parkingLot = new ParkingLot();
            string car = "car";
            string ticket = parkingLot.Park(car);
            parkingLot.Fetch(ticket);

            //When
            //Then
            Assert.Throws<WrongTicketException>(() => parkingLot.Fetch(ticket));
        }

        [Fact]
        public void Should_return_nothing_when_park_given_without_position()
        {
            //Given
            var parkingLot = new ParkingLot();
            int parkCarNum = 10;
            for (int i = 0; i < parkCarNum; i++)
            {
                string car = $"car{i}";
                parkingLot.Park(car);
            }

            //When
            //Then
            Assert.Throws<NoPositionAvaiableException>(() => parkingLot.Park("car11"));
        }
    }
}
