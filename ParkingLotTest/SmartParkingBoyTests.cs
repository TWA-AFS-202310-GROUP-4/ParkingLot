using Parking;
using System;
using System.Collections.Generic;
using Xunit;

namespace ParkingLotTest
{
    public class SmartParkingBoyTests
    {
        [Fact]
        public void Should_return_3_capacity_for_each_lot_when_park_six_cars_given_smart_parking_boy()
        {
            // Given
            // When
            var smartParkingBoy = new SmartParkingBoy();
            for (int i = 0; i < 6; i++)
            {
                string car = $"car{i}";
                smartParkingBoy.Park(car);
            }

            // Then
            Assert.Equal(3, smartParkingBoy.GetParkingLot1Capacity());
            Assert.Equal(3, smartParkingBoy.GetParkingLot2Capacity());
        }

        [Fact]
        public void Should_return_different_capacity_for_each_lot_when_park_13_cars_given_smart_parking_boy()
        {
            // Given
            // When
            var smartParkingBoy = new SmartParkingBoy();
            for (int i = 0; i < 13; i++)
            {
                string car = $"car{i}";
                smartParkingBoy.Park(car);
            }

            // Then
            Assert.Equal(7, smartParkingBoy.GetParkingLot1Capacity());
            Assert.Equal(6, smartParkingBoy.GetParkingLot2Capacity());
        }

        [Fact]
        public void Should_return_corrected_cars_when_fetch_two_cars_given_smart_parking_boy()
        {
            // Given
            var smartParkingBoy = new SmartParkingBoy();
            List<string> tickets = new List<string>();
            for (int i = 0; i < 13; i++)
            {
                string car = $"car{i}";
                tickets.Add(smartParkingBoy.Park(car));
            }

            // When
            string car0 = smartParkingBoy.Fetch(tickets[0]);
            string car7 = smartParkingBoy.Fetch(tickets[7]);
            string car10 = smartParkingBoy.Fetch(tickets[10]);
            // Then
            Assert.Equal("car0", car0);
            Assert.Equal("car7", car7);
            Assert.Equal("car10", car10);
        }

        [Fact]
        public void Should_return_wrong_msg_when_fetch_used_ticket_given_smart_parking_boy()
        {
            //Given
            var smartParkingBoy = new SmartParkingBoy();
            string car = "car";
            string ticket = smartParkingBoy.Park(car);
            smartParkingBoy.Fetch(ticket);

            //When
            //Then
            Assert.Throws<WrongTicketException>(() => smartParkingBoy.Fetch(ticket));
        }

        [Fact]
        public void Should_return_wrong_msg_when_fetch_wrong_ticket_given_smart_parking_boy()
        {
            //Given
            var smartParkingBoy = new SmartParkingBoy();

            //When
            //Then
            Assert.Throws<WrongTicketException>(() => smartParkingBoy.Fetch("wrong"));
        }

        [Fact]
        public void Should_return_nothing_when_park_given_smart_parking_boy()
        {
            //Given
            var smartParkingBoy = new SmartParkingBoy();
            int parkCarNum = 20;
            for (int i = 0; i < parkCarNum; i++)
            {
                string car = $"car{i}";
                smartParkingBoy.Park(car);
            }

            //When
            //Then
            Assert.Throws<NoPositionAvaiableException>(() => smartParkingBoy.Park("car111"));
        }
    }
}
