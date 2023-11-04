using System.Linq;

namespace ParkingLot.ParkingAttendant
{
    public class SmartParkingBoy : ParkingBoy
    {
        public SmartParkingBoy(int parkinglotsCount, int parkingCapacity) : base(parkinglotsCount, parkingCapacity)
        {
        }

        public override string OfferParkingService(string car)
        {
            int maxIndex = ParkinglotList.Select((parkinglot, index) => new { Index = index, Value = parkinglot.Capacity }).OrderByDescending(item => item.Value).First().Index;
            return ParkinglotList[maxIndex].Park(car);
        }
    }
}
