namespace ParkingLotTest
{
    using ParkingLot.Exception;
    using ParkingLotWork;
    using Xunit;
    public class ReminderMessageTest
    {
        [Fact]
        public void Should_return_reminder_message_when_ticket_wrong()
        {
            ParkingLot parkingLot = new ParkingLot();

            Assert.Throws<ParkingException>(() => parkingLot.Fetch("wrongticket"));
        }

        [Fact]
        public void Should_return_reminder_message_when_no_position()
        {
            ParkingLot parkingLot = new ParkingLot();

            for (int i = 0; i < 10; i++)
            {
                parkingLot.Park("car" + i);
            }

            Assert.Throws<ParkingException>(() => parkingLot.Fetch("car11"));
        }
    }
}
