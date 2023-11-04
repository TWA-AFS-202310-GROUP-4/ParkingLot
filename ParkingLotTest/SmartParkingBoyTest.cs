using ParkingLot.ParkingAttendant;
using ParkingLot.ParkingBase;
using System.Net.Sockets;
using Xunit;
using Xunit.Sdk;

namespace ParkingLotTest
{
    public class SmartParkingBoyTest
    {
        [Theory]
        [InlineData(2, 3, "car1", "car1-ticket")]
        [InlineData(1, 10, "car2", "car2-ticket")]
        public void ShouldGetTheTicketWhenSmartParkingboyOfferParkingServiceGivenACarToParkingLots(int parkinglotsCount, int parkingCapacity, string car, string expectedTicket)
        {
            //given9
            var smartParkingboy = new SmartParkingBoy(parkinglotsCount, parkingCapacity);

            //when

            var ticket = smartParkingboy.OfferParkingService(car);

            //then
            Assert.Equal(expectedTicket, ticket);
        }

        [Theory]
        [InlineData(2, 3, new string[] { "car1", "car2", "car3", "car4" }, 1)]
        [InlineData(2, 2, new string[] { "car1", "car2", "car3", "car4" }, 0)]
        public void Should_parking_the_capacity_max_when_smartParkingboy_offerParkingService_given_a_car_to_parkingLots(int parkinglotsCount, int parkingCapacity, string[] cars, int expectedRes)
        {
            //given
            var smartParkingboy = new SmartParkingBoy(parkinglotsCount, parkingCapacity);

            //when
            foreach (var car in cars)
            {
                smartParkingboy.OfferParkingService(car);
            }

            //then
            foreach (var parking in smartParkingboy.ParkinglotList)
            {
                Assert.Equal(expectedRes, parking.Capacity);
            }
        }

        [Theory]
        [InlineData(2, 3, "car1", "car1-ticket")]
        [InlineData(1, 10, "car2", "car2-ticket")]
        public void Should_get_the_ticket_when_smartParkingboy_offerParkingService_given_a_car_to_parkingLots(int parkinglotsCount, int parkingCapacity, string car, string expectedTicket)
        {
            //given9
            var smartParkingboy = new SmartParkingBoy(parkinglotsCount, parkingCapacity);

            //when

            var ticket = smartParkingboy.OfferParkingService(car);

            //then
            Assert.Equal(expectedTicket, ticket);
        }

        [Theory]
        [InlineData(2, 3, "car1", "truck-ticket", "Unrecognized parking ticket.")]
        [InlineData(1, 10, "car2", "tank-ticket", "Unrecognized parking ticket.")]
        public void Should_get_error_message_when_smartParkingboy_offerFetchingCarService_given_a_wrong_ticket(int parkinglotsCount, int parkingCapacity, string car, string wrongTicket, string errorMessage)
        {
            //given9
            var smartParkingboy = new SmartParkingBoy(parkinglotsCount, parkingCapacity);
            smartParkingboy.OfferParkingService(car);

            //when
            WrongTicketException wrongTicketException = Assert.Throws<WrongTicketException>(() => smartParkingboy.OfferFetchingCarService(wrongTicket));

            //then
            Assert.Equal(errorMessage, wrongTicketException.Message);
        }

        [Theory]
        [InlineData(2, 5, new string[] { "car1", "car2", "car3", "car4", "car5", "car6", "car7", "car8", "car9", "car10" }, "No available position.")]
        public void Should_get_error_message_when_smartParkingboy_offerParkingService_given_fullfilled_parkinglots(int parkinglotsCount, int parkingCapacity, string[] cars, string errorMessage)
        {
            //given9
            var smartParkingboy = new SmartParkingBoy(parkinglotsCount, parkingCapacity);
            foreach (var car in cars)
            {
                smartParkingboy.OfferParkingService(car);
            }

            var comerCar = "comerCar";

            //when
            WrongTicketException wrongTicketException = Assert.Throws<WrongTicketException>(() => smartParkingboy.OfferParkingService(comerCar));

            Assert.Equal(errorMessage, wrongTicketException.Message);
        }
    }
}