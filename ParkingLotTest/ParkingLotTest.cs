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
            var parkingLot = new Parking.ParkingLot();
            string ticket = parkingLot.Park(car);
            string result = parkingLot.Fetch(ticket);

            Assert.Equal("car1", result);
        }
    }
}
