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

        [Fact]
        public void Should_return_right_car_given_correlation_tickets()
        {
            var parkinglot = new ParkingLot();
            string ticket1 = parkinglot.Park("car1");
            string ticket2 = parkinglot.Park("car2");
            string car1 = parkinglot.Fetch(ticket1);
            string car2 = parkinglot.Fetch(ticket2);

            Assert.Equal("car1", car1);
            Assert.Equal("car2", car2);
        }

        [Fact]
        public void Should_return_no_car_given_wrong_tickets()
        {
            var parkinglot = new ParkingLot();
            string ticket1 = parkinglot.Park("car1");
            string car1 = parkinglot.Fetch(ticket1 + "2");

            Assert.Equal("wrong ticket", car1);
        }

        [Fact]
        public void Should_return_ticket_wrong_given_used_tickets()
        {
            var parkinglot = new ParkingLot();
            string ticket1 = parkinglot.Park("car1");
            string car1 = parkinglot.Fetch(ticket1);
            string car1again = parkinglot.Fetch(ticket1);

            Assert.Equal("wrong ticket", car1again);
        }
    }
}
