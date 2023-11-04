using ParkingLot.ParkingBase;
using Xunit;

namespace ParkingLotTest
{
    public class ParkingLotTest
    {
        [Fact]
        public void Should_fetch_a_car_when_fetchCar_with_ticket()
        {
            //given
            Parking park = new Parking();
            string ticket = park.Park("car");

            //when
            string car = park.FectchCar(ticket);

            //then
            Assert.Equal("car", car);
        }

        [Theory]
        [InlineData("car1")]
        [InlineData("car2")]
        public void Should_fetch_corresponding_car_when_fetchCar_with_ticket(string car)
        {
            //given
            var park = new Parking();
            string ticket = park.Park(car);

            //when
            string fetchedCar = park.FectchCar(ticket);

            //then
            Assert.Equal(car, fetchedCar);
        }

        [Theory]
        [InlineData(null)]
        public void Should_get_null_when_fetchCar_with_a_wrong_ticket(string faketicket)
        {
            //given
            var park = new Parking();

            //when
            string fetchedCar = park.FectchCar(faketicket);

            //then
            Assert.Null(fetchedCar);
        }

        [Theory]
        [InlineData("car1", "Unrecognized parking ticket.")]
        [InlineData("car2", "Unrecognized parking ticket.")]
        [InlineData("car3", "Unrecognized parking ticket.")]
        public void Should_get_error_message_when_fetchCar_with_a_used_ticket(string car, string errorMessage)
        {
            //given
            var park = new Parking();
            var ticktet = park.Park(car);
            park.FectchCar(ticktet);
            //when
            WrongTicketException wrongTicketException = Assert.Throws<WrongTicketException>(() => park.FectchCar(ticktet));

            //then
            Assert.Equal(errorMessage, wrongTicketException.Message);
        }

        [Theory]
        [InlineData("truck", "Unrecognized parking ticket.")]
        [InlineData("notticket", "Unrecognized parking ticket.")]
        [InlineData("abccar", "Unrecognized parking ticket.")]
        public void Should_get_error_message_when_fetchCar_with_a_wrong_ticket(string wrongTicket, string errorMessage)
        {
            //given
            var park = new Parking();
            //when
            WrongTicketException wrongTicketException = Assert.Throws<WrongTicketException>(() => park.FectchCar(wrongTicket));

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
    }
}