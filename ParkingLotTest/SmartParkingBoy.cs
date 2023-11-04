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
    public class SmartParkingBoy
    {
        [Fact]
        public void Should_always_park_cars_to_the_parking_lot_which_contains_more_empty_positions()
        {
            List<ParkingLot> parkingLots = new List<ParkingLot>();
            ParkingLot parkingLot1 = new ParkingLot();
            ParkingLot parkingLot2 = new ParkingLot();
            parkingLots.Add(parkingLot1);
            parkingLots.Add(parkingLot2);
            ParkingBoy parkboy = new ParkingBoy(parkingLots);
            string ticket1 = parkboy.Park("car1");
            string ticket2 = parkboy.Park("car2");

            Assert.Equal(9, parkingLot1.Capacity);
        }
    }
}
