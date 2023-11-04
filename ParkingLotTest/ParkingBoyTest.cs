using ParkingLot.ParkingAttendant;
using Xunit;

namespace ParkingLotTest
{
    public class ParkingBoyTest
    {
        [Theory]
        [InlineData("minicar")]
        public void Should_get_a_ticket_when_parkingboy_ServeParking_with_ticket(string car)
        {
            //given
            ParkingBoy parkingboy = new ParkingBoy();

            //when
            string ticket = parkingboy.OfferParkingService(car);

            //then
            Assert.NotNull(ticket);
        }
    }
}
