using ParkingLot.ParkingAttendant;
using System.Linq;
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

        [Theory]
        [InlineData("minicar")]
        [InlineData("car1", "car2", "car3", "car5")]
        public void Should_get_the_parked_car_when_parkingboy_OfferFetchingCar_given_right_ticket(params string[] cars)
        {
            //given
            ParkingBoy parkingboy = new ParkingBoy();
            string[] tickets = cars.Select(car => parkingboy.OfferParkingService(car)).ToArray();

            //when
            string[] fetchedcar = tickets.Select(ticket => parkingboy.OfferFetchingCarService(ticket)).ToArray();

            //then
            for (int i = 0; i < fetchedcar.Length; i++)
            {
                Assert.Equal(cars[i], fetchedcar[i]);
            }
        }

        [Theory]
        [InlineData("minicar")]
        [InlineData("car1", "car2", "car3", "car5")]
        public void Should_error_when_parkingboy_OfferFetchingCar_given_right_ticket(params string[] cars)
        {
            //given
            ParkingBoy parkingboy = new ParkingBoy();
            string[] tickets = cars.Select(car => parkingboy.OfferParkingService(car)).ToArray();

            //when
            string[] fetchedcar = tickets.Select(ticket => parkingboy.OfferFetchingCarService(ticket)).ToArray();

            //then
            for (int i = 0; i < fetchedcar.Length; i++)
            {
                Assert.Equal(cars[i], fetchedcar[i]);
            }
        }
    }
}
