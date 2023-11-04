using ParkingLot.ParkingAttendant;
using ParkingLot.ParkingBase;
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

        [Theory]
        [InlineData("car1", "Unrecognized parking ticket.")]
        [InlineData("car2", "Unrecognized parking ticket.")]
        [InlineData("car3", "Unrecognized parking ticket.")]
        public void Should_error_message_parkingboy_OfferFetchingCar_given_used_ticket(string car, string errorMessage)
        {
            //given
            ParkingBoy parkingboy = new ParkingBoy();
            var ticktet = parkingboy.OfferParkingService(car);
            parkingboy.OfferFetchingCarService(ticktet);
            //when
            WrongTicketException wrongTicketException = Assert.Throws<WrongTicketException>(() => parkingboy.OfferFetchingCarService(ticktet));

            //then
            Assert.Equal(errorMessage, wrongTicketException.Message);
        }

        [Theory]
        [InlineData("truck", "Unrecognized parking ticket.")]
        [InlineData("notticket", "Unrecognized parking ticket.")]
        [InlineData("abccar", "Unrecognized parking ticket.")]
        public void Should_error_message_parkingboy_OfferFetchingCar_given_wrong_ticket(string ticket, string errorMessage)
        {
            //given
            ParkingBoy parkingboy = new ParkingBoy();

            //when
            WrongTicketException wrongTicketException = Assert.Throws<WrongTicketException>(() => parkingboy.OfferFetchingCarService(ticket));

            //then
            Assert.Equal(errorMessage, wrongTicketException.Message);
        }

        [Theory]
        [InlineData("car1", "car2", "car3", "car4", "car5", "car6", "car7", "car8", "car9", "car10")]
        [InlineData("car1", "car2", "car3", "car4")]
        public void Should_get_null_ticket_when_park_given_default_capacity_10_no_position(params string[] cars)
        {
            //given
            var park = new Parking(cars.Length);
            foreach (var car in cars)
            {
                park.Park(car);
            }

            var comerCar = "no-position-car";

            //when
            WrongTicketException wrongTicketException = Assert.Throws<WrongTicketException>(() => park.Park(comerCar));

            Assert.Equal("No available position.", wrongTicketException.Message);
        }

        [Theory]
        [InlineData("car1", "car2", "car3", "car4", "car5", "car6", "car7", "car8", "car9", "car10")]
        public void Should_get_null_ticket_when_parkingboy_offerParking_given_default_capacity_10_no_position(params string[] cars)
        {
            //given
            var parkingboy = new ParkingBoy();
            foreach (var car in cars)
            {
                parkingboy.OfferParkingService(car);
            }

            var comerCar = "no-position-car";

            //when
            WrongTicketException wrongTicketException = Assert.Throws<WrongTicketException>(() => parkingboy.OfferParkingService(comerCar));

            Assert.Equal("No available position.", wrongTicketException.Message);
        }
    }
}
