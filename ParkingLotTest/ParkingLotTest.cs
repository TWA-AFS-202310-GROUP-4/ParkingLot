namespace ParkingLotTest
{
    using ParkingLot;
    using Xunit;

    public class ParkingLotTest
    {
        [Fact]
        public void Should_return_ticket_when_parking_given_car()
        {
            // given
            var parkingLot = new ParkingLot();
            var car = "1";

            // when
            string ticket = parkingLot.Park(car);

            // then
            Assert.NotNull(ticket);
        }

        [Fact]
        public void Should_return_car_when_fetch_given_ticket()
        {
            var parkingLot = new ParkingLot();
            var car = "1";
            var ticket = parkingLot.Park(car);

            var carActual = parkingLot.Fetch(ticket);

            Assert.Equal(car, carActual);
        }
    }
}
