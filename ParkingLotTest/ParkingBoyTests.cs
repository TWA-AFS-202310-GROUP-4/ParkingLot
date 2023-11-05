using Parking;
using System;
using System.Collections.Generic;
using Xunit;

namespace ParkingLotTest
{
    public class ParkingBoyTests
    {
        [Fact]
        public void Should_get_same_car_when_fetch_car_by_ticket_given_standard_parking_boy()
        {
            //Given
            string car = "car1";
            var parkingBoy = new ParkingBoy();
            string ticket = parkingBoy.Park(car, "standard");
            //When
            string result = parkingBoy.Fetch(ticket);
            //Then
            Assert.Equal("car1", result);
        }

        [Fact]
        public void Should_get_ticket_when_park_given_a_car_a_standard_parking_boy()
        {
            //Given
            string car = "car1";
            var parkingBoy = new ParkingBoy();
            //When
            string ticket = parkingBoy.Park(car, "standard");
            //Then
            Assert.Equal("ticket: car1", ticket);
        }

        [Fact]
        public void Should_get_same_car_when_fetch_car_by_ticket_given_two_cars_a_standard_parking_boy()
        {
            //Given
            string car = "car1";
            string car2 = "car2";

            var parkingBoy = new ParkingBoy();
            string ticket = parkingBoy.Park(car, "standard");
            string ticket2 = parkingBoy.Park(car2, "standard");
            //When
            string result1 = parkingBoy.Fetch(ticket);
            string result2 = parkingBoy.Fetch(ticket2);
            //Then
            Assert.Equal("car1", result1);
            Assert.Equal("car2", result2);
        }

        [Fact]
        public void Should_get_error_msg_when_fetch_car_with_wrong_ticket_given_one_car_a_standard_parking_boy()
        {
            //Given
            var parkingBoy = new ParkingBoy();
            string wrongTicket = "wrong";
            //When
            //Then
            Assert.Throws<WrongTicketException>(() => parkingBoy.Fetch(wrongTicket));
        }

        [Fact]
        public void Should_return_error_msg_when_fetch_given_a_used_ticket_a_standard_parking_boy()
        {
            //Given
            var parkingBoy = new ParkingBoy();
            string car = "car";
            string ticket = parkingBoy.Park(car, "standard");
            parkingBoy.Fetch(ticket);

            //When
            //Then
            Assert.Throws<WrongTicketException>(() => parkingBoy.Fetch(ticket));
        }

        [Fact]
        public void Should_return_nothing_when_park_given_without_position_a_standard_parking_boy()
        {
            //Given
            var parkingBoy = new ParkingBoy();
            int parkCarNum = 20;
            for (int i = 0; i < parkCarNum; i++)
            {
                string car = $"car{i}";
                parkingBoy.Park(car, "standard");
            }

            //When
            //Then
            Assert.Throws<NoPositionAvaiableException>(() => parkingBoy.Park("car111", "standard"));
        }

        [Fact]
        public void Should_park_first_parking_lot_when_park_car_given_first_parking_lot_not_full_standard_way()
        {
            //Given
            string car = "car1";
            var parkingBoy = new ParkingBoy();
            //When
            Assert.Equal(0, parkingBoy.GetParkingLot1Capacity());
            string ticket = parkingBoy.Park(car, "standard");

            //Then
            Assert.Equal(1, parkingBoy.GetParkingLot1Capacity());
            Assert.Equal(0, parkingBoy.GetParkingLot2Capacity());
        }

        [Fact]
        public void Should_parked_second_parking_lot_when_park_car_given_first_parking_lot_full_standard_way()
        {
            //Given
            var parkingBoy = new ParkingBoy();
            int parkCarNum = 10;
            for (int i = 0; i < parkCarNum; i++)
            {
                string car = $"car{i}";
                parkingBoy.Park(car, "standard");
            }

            Assert.Equal(10, parkingBoy.GetParkingLot1Capacity());
            //Then
            parkingBoy.Park("car11", "standard");
            Assert.Equal(1, parkingBoy.GetParkingLot2Capacity());
        }

        [Fact]
        public void Should_correct_car_when_fetch_two_cars_given_first_parking_lot_full_standard_way()
        {
            //Given
            var parkingBoy = new ParkingBoy();
            int parkCarNum = 3;

            string car = "car1";
            string ticket = parkingBoy.Park(car, "standard");

            string car2 = "car2";
            string ticket2 = parkingBoy.Park(car2, "standard");

            string fetchedCar = parkingBoy.Fetch(ticket);
            string fetchedCar2 = parkingBoy.Fetch(ticket2);

            //Then
            Assert.Equal("car1", fetchedCar);
            Assert.Equal("car2", fetchedCar2);
        }

        [Fact]
        public void Should_get_error_msg_when_fetch_car_with_wrong_ticket_given_two_parking_lots_standard_way()
        {
            //Given
            var parkingBoy = new ParkingBoy();
            string wrongTicket = "wrong";
            //When
            //Then
            Assert.Throws<WrongTicketException>(() => parkingBoy.Fetch(wrongTicket));
        }

        [Fact]
        public void Should_return_error_msg_when_fetch_given_a_used_ticket_a_parking_boy_two_parking_lots_standard_Way()
        {
            //Given
            var parkingBoy = new ParkingBoy();
            string car = "car";
            string ticket = parkingBoy.Park(car, "standard");
            parkingBoy.Fetch(ticket);

            //When
            //Then
            Assert.Throws<WrongTicketException>(() => parkingBoy.Fetch(ticket));
        }

        [Fact]
        public void Should_return_nothing_when_park_given_without_position_a_parking_boy_two_parking_lots_standard_way()
        {
            //Given
            var parkingBoy = new ParkingBoy();
            int parkCarNum = 20;
            for (int i = 0; i < parkCarNum; i++)
            {
                string car = $"car{i}";
                parkingBoy.Park(car, "standard");
            }

            //When
            //Then
            Assert.Throws<NoPositionAvaiableException>(() => parkingBoy.Park("car111", "standard"));
        }

        [Fact]
        public void Should_return_3_capacity_for_each_lot_when_park_six_cars_given_smart_parking_boy()
        {
            // Given
            // When
            var parkingBoy = new ParkingBoy();
            for (int i = 0; i < 6; i++)
            {
                string car = $"car{i}";
                parkingBoy.Park(car, "smart");
            }

            // Then
            Assert.Equal(3, parkingBoy.GetParkingLot1Capacity());
            Assert.Equal(3, parkingBoy.GetParkingLot2Capacity());
        }

        [Fact]
        public void Should_return_different_capacity_for_each_lot_when_park_13_cars_given_smart_parking_boy()
        {
            // Given
            // When
            var parkingBoy = new ParkingBoy();
            for (int i = 0; i < 13; i++)
            {
                string car = $"car{i}";
                parkingBoy.Park(car, "smart");
            }

            // Then
            Assert.Equal(7, parkingBoy.GetParkingLot1Capacity());
            Assert.Equal(6, parkingBoy.GetParkingLot2Capacity());
        }

        [Fact]
        public void Should_return_corrected_cars_when_fetch_two_cars_given_smart_parking_boy()
        {
            // Given
            var parkingBoy = new ParkingBoy();
            List<string> tickets = new List<string>();
            for (int i = 0; i < 13; i++)
            {
                string car = $"car{i}";
                tickets.Add(parkingBoy.Park(car, "smart"));
            }

            // When
            string car0 = parkingBoy.Fetch(tickets[0]);
            string car7 = parkingBoy.Fetch(tickets[7]);
            string car10 = parkingBoy.Fetch(tickets[10]);
            // Then
            Assert.Equal("car0", car0);
            Assert.Equal("car7", car7);
            Assert.Equal("car10", car10);
        }

        [Fact]
        public void Should_return_wrong_msg_when_fetch_used_ticket_given_smart_parking_boy()
        {
            //Given
            var parkingBoy = new ParkingBoy();
            string car = "car";
            string ticket = parkingBoy.Park(car, "smart");
            parkingBoy.Fetch(ticket);

            //When
            //Then
            Assert.Throws<WrongTicketException>(() => parkingBoy.Fetch(ticket));
        }

        [Fact]
        public void Should_return_wrong_msg_when_fetch_wrong_ticket_given_smart_parking_boy()
        {
            //Given
            var parkingBoy = new ParkingBoy();

            //When
            //Then
            Assert.Throws<WrongTicketException>(() => parkingBoy.Fetch("wrong"));
        }

        [Fact]
        public void Should_return_nothing_when_park_given_smart_parking_boy()
        {
            //Given
            var parkingBoy = new ParkingBoy();
            int parkCarNum = 20;
            for (int i = 0; i < parkCarNum; i++)
            {
                string car = $"car{i}";
                parkingBoy.Park(car, "smart");
            }

            //When
            //Then
            Assert.Throws<NoPositionAvaiableException>(() => parkingBoy.Park("car111", "smart"));
        }

        [Fact]
        public void Should_return_correct_parking_lot_capacity_when_park_given_two_strategy_used()
        {
            //Given
            var parkingBoy = new ParkingBoy();
            int parkCarNum = 3;
            for (int i = 0; i < parkCarNum; i++)
            {
                string car = $"car{i}";
                parkingBoy.Park(car, "smart");
            }

            for (int i = 0; i < 5; i++)
            {
                string car = $"car{i + 3}";
                parkingBoy.Park(car, "standard");
            }

            //When
            //Then
            Assert.Equal(7, parkingBoy.GetParkingLot1Capacity());
            Assert.Equal(1, parkingBoy.GetParkingLot2Capacity());
        }

        [Fact]
        public void Should_return_corrected_cars_when_fetch_two_cars_given_two_parking_strategy_used()
        {
            // Given
            var parkingBoy = new ParkingBoy();
            List<string> tickets = new List<string>();
            for (int i = 0; i < 13; i++)
            {
                string car = $"car{i}";
                tickets.Add(parkingBoy.Park(car, "smart"));
            }

            for (int i = 0; i < 5; i++)
            {
                string car = $"car{i + 13}";
                parkingBoy.Park(car, "standard");
            }

            // When
            string car0 = parkingBoy.Fetch(tickets[0]);
            string car7 = parkingBoy.Fetch(tickets[7]);
            string car10 = parkingBoy.Fetch(tickets[10]);
            // Then
            Assert.Equal("car0", car0);
            Assert.Equal("car7", car7);
            Assert.Equal("car10", car10);
        }
    }
}
