namespace ParkingLotTest
{
    using ParkingLot;
    using Xunit;

    public class ParkingLotTest
    {
        [Fact]
        public void Should_return_right_car_given_tickets()
        {
            var parkinglot = new ParkingLot();
            string ticket = parkinglot.Park("car1");
            string car = parkinglot.Fetch(ticket);
            Assert.Equal("car1", car);
        }
    }
}
