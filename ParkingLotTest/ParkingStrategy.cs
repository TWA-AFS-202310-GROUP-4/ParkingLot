using ParkingLot;

using ParkingLotWork.ParkingBoy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
namespace ParkingLotTest
{
    using ParkingLotWork;
    public class ParkingStrategy
    {
        [Fact]
        public void Should_use_parkingboy_to_park()
        {
            ParkingContest parkingContest = new ParkingContest();
            ParkingLot parkingLot1 = new ParkingLot();
            ParkingLot parkingLot2 = new ParkingLot();
            List<ParkingLot> parkingLots = new List<ParkingLot>();
            parkingLots.Add(parkingLot1);
            parkingLots.Add(parkingLot2);
            parkingContest.SetStrategy(new ParkingBoy(parkingLots));
            string ticket = parkingContest.ExecuteStrategy("car1");
            string ticket2 = parkingContest.ExecuteStrategy("car2");
            Assert.Equal(9, parkingLot1.Capacity);
        }
    }
}
