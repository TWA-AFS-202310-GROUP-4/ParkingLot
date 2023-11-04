using ParkingLotWork.ParkingBoy;
using Xunit;
namespace ParkingLotTest
{
    using ParkingLot.Exception;
    using ParkingLotWork;
    using System.Collections.Generic;

    public class ParkingBoyTest
    {
        [Fact]
        public void Should_use_parkingboy_park_and_fetch_car()
        {
            ParkingBoy parkingBoy = new ParkingBoy(new ParkingLot());
            string ticket = parkingBoy.Park("car1");
            string car = parkingBoy.Fetch(ticket);
            Assert.Equal("car1", car);
        }

        [Fact]
        public void Should_return_right_car_given_the_correlation_ticket()
        {
            ParkingBoy parkingBoy = new ParkingBoy(new ParkingLot());
            string ticket1 = parkingBoy.Park("car1");
            string ticket2 = parkingBoy.Park("car2");
            string car1 = parkingBoy.Fetch(ticket1);
            string car2 = parkingBoy.Fetch(ticket2);
            Assert.Equal("car1", car1);
            Assert.Equal("car2", car2);
        }

        [Fact]
        public void Should_return_no_car_and_error_message_given_the_wrong_ticket()
        {
            ParkingBoy parkingBoy = new ParkingBoy(new ParkingLot());
            Assert.Throws<ParkingException>(() => parkingBoy.Fetch("wrongticket"));
        }

        [Fact]
        public void Should_return_no_position_error_message_when_no_position()
        {
            ParkingBoy parkingBoy = new ParkingBoy(new ParkingLot());
            for (int i = 0; i < 10; i++)
            {
                parkingBoy.Park("car" + i);
            }

            Assert.Throws<ParkingException>(() => parkingBoy.Fetch("car11"));
        }
    }
}
