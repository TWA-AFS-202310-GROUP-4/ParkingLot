using Parking;
using System;
using Xunit;

namespace ParkingLotTest
{
    public class ParkingBoyTests
    {
        [Fact]
        public void Should_get_same_car_when_fetch_car_by_ticket_given_parking_boy()
        {
            //Given
            string car = "car1";
            var parkingBoy = new ParkingBoy(new ParkingLot());
            string ticket = parkingBoy.Park(car);
            //When
            string result = parkingBoy.Fetch(ticket);
            //Then
            Assert.Equal("car1", result);
        }

        [Fact]
        public void Should_get_ticket_when_park_given_a_car_a_parking_boy()
        {
            //Given
            string car = "car1";
            var parkingBoy = new ParkingBoy(new ParkingLot());
            //When
            string ticket = parkingBoy.Park(car);
            //Then
            Assert.Equal("ticket: car1", ticket);
        }

        [Fact]
        public void Should_get_same_car_when_fetch_car_by_ticket_given_two_cars_a_parking_boy()
        {
            //Given
            string car = "car1";
            string car2 = "car2";

            var parkingBoy = new ParkingBoy(new ParkingLot());
            string ticket = parkingBoy.Park(car);
            string ticket2 = parkingBoy.Park(car2);
            //When
            string result1 = parkingBoy.Fetch(ticket);
            string result2 = parkingBoy.Fetch(ticket2);
            //Then
            Assert.Equal("car1", result1);
            Assert.Equal("car2", result2);
        }

        [Fact]
        public void Should_get_error_msg_when_fetch_car_with_wrong_ticket_given_one_car_a_parking_boy()
        {
            //Given
            var parkingBoy = new ParkingBoy(new ParkingLot());
            string wrongTicket = "wrong";
            //When
            //Then
            Assert.Throws<WrongTicketException>(() => parkingBoy.Fetch(wrongTicket));
        }

        [Fact]
        public void Should_return_error_msg_when_fetch_given_a_used_ticket_a_parking_boy()
        {
            //Given
            var parkingBoy = new ParkingBoy(new ParkingLot());
            string car = "car";
            string ticket = parkingBoy.Park(car);
            parkingBoy.Fetch(ticket);

            //When
            //Then
            Assert.Throws<WrongTicketException>(() => parkingBoy.Fetch(ticket));
        }

        [Fact]
        public void Should_return_nothing_when_park_given_without_position_a_parking_boy()
        {
            //Given
            var parkingBoy = new ParkingBoy(new ParkingLot());
            int parkCarNum = 20;
            for (int i = 0; i < parkCarNum; i++)
            {
                string car = $"car{i}";
                parkingBoy.Park(car);
            }

            //When
            //Then
            Assert.Throws<NoPositionAvaiableException>(() => parkingBoy.Park("car111"));
        }

        [Fact]
        public void Should_park_first_parking_lot_when_park_car_given_first_parking_lot_not_full()
        {
            //Given
            string car = "car1";
            var parkingBoy = new ParkingBoy(new ParkingLot());
            //When
            Assert.Equal(0, parkingBoy.GetParkingLot1Capacity());
            string ticket = parkingBoy.Park(car);

            //Then
            Assert.Equal(1, parkingBoy.GetParkingLot1Capacity());
            Assert.Equal(0, parkingBoy.GetParkingLot2Capacity());
        }

        [Fact]
        public void Should_parked_second_parking_lot_when_park_car_given_first_parking_lot_full()
        {
            //Given
            var parkingBoy = new ParkingBoy(new ParkingLot());
            int parkCarNum = 10;
            for (int i = 0; i < parkCarNum; i++)
            {
                string car = $"car{i}";
                parkingBoy.Park(car);
            }

            Assert.Equal(10, parkingBoy.GetParkingLot1Capacity());
            //Then
            parkingBoy.Park("car11");
            Assert.Equal(1, parkingBoy.GetParkingLot2Capacity());
        }

        [Fact]
        public void Should_correct_car_when_fetch_two_cars_given_first_parking_lot_full()
        {
            //Given
            var parkingBoy = new ParkingBoy(new ParkingLot());
            int parkCarNum = 3;

            string car = "car1";
            string ticket = parkingBoy.Park(car);

            string car2 = "car2";
            string ticket2 = parkingBoy.Park(car2);

            string fetchedCar = parkingBoy.Fetch(ticket);
            string fetchedCar2 = parkingBoy.Fetch(ticket2);

            //Then
            Assert.Equal("car1", fetchedCar);
            Assert.Equal("car2", fetchedCar2);
        }

        [Fact]
        public void Should_get_error_msg_when_fetch_car_with_wrong_ticket_given_two_parking_lots()
        {
            //Given
            var parkingBoy = new ParkingBoy(new ParkingLot());
            string wrongTicket = "wrong";
            //When
            //Then
            Assert.Throws<WrongTicketException>(() => parkingBoy.Fetch(wrongTicket));
        }

        [Fact]
        public void Should_return_error_msg_when_fetch_given_a_used_ticket_a_parking_boy_two_parking_lots()
        {
            //Given
            var parkingBoy = new ParkingBoy(new ParkingLot());
            string car = "car";
            string ticket = parkingBoy.Park(car);
            parkingBoy.Fetch(ticket);

            //When
            //Then
            Assert.Throws<WrongTicketException>(() => parkingBoy.Fetch(ticket));
        }

        [Fact]
        public void Should_return_nothing_when_park_given_without_position_a_parking_boy_two_parking_lots()
        {
            //Given
            var parkingBoy = new ParkingBoy(new ParkingLot());
            int parkCarNum = 20;
            for (int i = 0; i < parkCarNum; i++)
            {
                string car = $"car{i}";
                parkingBoy.Park(car);
            }

            //When
            //Then
            Assert.Throws<NoPositionAvaiableException>(() => parkingBoy.Park("car111"));
        }
    }
}
