using ParkingLot.Parking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
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
    }
}
