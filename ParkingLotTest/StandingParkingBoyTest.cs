namespace ParkingLotTest
{
    using ParkingLot;
    using System;
    using Xunit;

    public class StandParkingBoyTest
    {
        [Fact]
        public void Should_park_in_first_lot_when_parking_given_two_parkingLot()
        {
            // given
            var p1 = new ParkingLot();
            var p2 = new ParkingLot();
            var parkingBoy = new StandParkingBoy(p1, p2);
            var car = "1";

            // when
            string ticket = parkingBoy.Park(car);
            var carActual = p1.Fetch(ticket);

            // then
            Assert.Equal(car, carActual);
        }

        [Fact]
        public void Should_park_in_second_when_parking_given_two_parkingLot_first_full()
        {
            // given
            var p1 = new ParkingLot(0);
            var p2 = new ParkingLot();
            var parkingBoy = new StandParkingBoy(p1, p2);
            var car = "1";

            // when
            string ticket = parkingBoy.Park(car);
            var carActual = p2.Fetch(ticket);

            // then
            Assert.Equal(car, carActual);
        }

        [Fact]
        public void Should_fetch_right_when_fetch_twice_given_two_lots_each_have_a_car()
        {
            // given
            var p1 = new ParkingLot();
            var p2 = new ParkingLot();
            var parkingBoy = new StandParkingBoy(p1, p2);
            var car1 = "1";
            var car2 = "2";

            // when
            var t1 = p1.Park(car1);
            var t2 = p2.Park(car2);
            var car1Actual = parkingBoy.Fetch(t1);
            var car2Actual = parkingBoy.Fetch(t2);

            // then
            Assert.Equal(car1, car1Actual);
            Assert.Equal(car2, car2Actual);
        }

        [Fact]
        public void Should_error_when_fetch_given_wrong_ticket()
        {
            // given
            var p1 = new ParkingLot();
            var p2 = new ParkingLot();
            var parkingBoy = new StandParkingBoy(p1, p2);
            var car = "1";

            // when
            string ticket = parkingBoy.Park(car);

            Assert.Throws<WrongTicketException>(() => parkingBoy.Fetch(ticket + " "));
        }

        [Fact]
        public void Should_error_when_fetch_given_used_ticket()
        {
            // given
            var p1 = new ParkingLot();
            var p2 = new ParkingLot();
            var parkingBoy = new StandParkingBoy(p1, p2);
            var car = "1";

            // when
            string ticket = parkingBoy.Park(car);
            parkingBoy.Fetch(ticket);

            Assert.Throws<WrongTicketException>(() => p2.Fetch(ticket));
        }

        [Fact]
        public void Should_error_when_park_given_no_capacity()
        {
            // given
            var p1 = new ParkingLot(0);
            var p2 = new ParkingLot(0);
            var parkingBoy = new StandParkingBoy(p1, p2);
            var car = "1";

            Assert.Throws<NoPositionException>(() => parkingBoy.Park(car));
        }
    }
}
