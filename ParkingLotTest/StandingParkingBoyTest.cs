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
    }
}
