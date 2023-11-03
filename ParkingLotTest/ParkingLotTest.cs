namespace ParkingLotTest
{
    using ParkingLot;
    using System;
    using Xunit;

    public class ParkingLotTest
    {
        [Fact]
        public void Should_return_ticket_when_parking_given_car()
        {
            // given
            var parkingLot = new ParkingLot(10);
            var car = "1";

            // when
            string ticket = parkingLot.Park(car);

            // then
            Assert.NotNull(ticket);
        }

        [Fact]
        public void Should_return_car_when_fetch_given_ticket()
        {
            var parkingLot = new ParkingLot(10);
            var car = "1";
            var ticket = parkingLot.Park(car);

            var carActual = parkingLot.Fetch(ticket);

            Assert.Equal(car, carActual);
        }

        [Fact]
        public void Should_return_car_when_fetch_given_ticket_many_customer()
        {
            var parkingLot = new ParkingLot();
            var car = "1";
            var car2 = "2";
            var ticket = parkingLot.Park(car);
            var t2 = parkingLot.Park(car2);

            var carActual = parkingLot.Fetch(ticket);
            var carActual2 = parkingLot.Fetch(t2);

            Assert.Equal(car, carActual);
            Assert.Equal(car2, carActual2);
        }

        [Fact]
        public void Should_error_when_fetch_given_wrong_ticket_many_customer()
        {
            var parkingLot = new ParkingLot();
            var car = "1";
            var car2 = "2";
            var ticket = parkingLot.Park(car);
            var t2 = parkingLot.Park(car2);

            Assert.Throws<WrongTicketException>(() => parkingLot.Fetch(ticket + " "));
            Assert.Throws<WrongTicketException>(() => parkingLot.Fetch(t2 + " "));
        }

        [Fact]
        public void Should_return_null_when_fetch_given_not_exist_ticket()
        {
            var parkingLot = new ParkingLot();
            var car = "1";
            var ticket = parkingLot.Park(car);

            Assert.Throws<WrongTicketException>(() => parkingLot.Fetch(ticket + " "));
        }

        [Fact]
        public void Should_return_null_when_park_given_no_capacity()
        {
            var parkingLot = new ParkingLot(1);
            var car = "1";
            var ticket = parkingLot.Park(car);

            Assert.Throws<NoPositionException>(() => parkingLot.Park("2"));
        }

        [Fact]
        public void Should_return_null_when_park_given_parked_car()
        {
            var parkingLot = new ParkingLot();
            var car = "1";
            parkingLot.Park(car);

            var ticket2 = parkingLot.Park(car);

            Assert.Null(ticket2);
        }

        [Fact]
        public void Should_return_null_when_park_given_null()
        {
            var parkingLot = new ParkingLot(1);

            var ticket = parkingLot.Park(null);

            Assert.Null(ticket);
        }

        [Fact]
        public void Should_error_msg_when_fetch_given_null()
        {
            var parkingLot = new ParkingLot(1);
            var ticket = parkingLot.Park("car");

            Assert.Throws<WrongTicketException>(() => parkingLot.Fetch(null));
        }
    }
}
