using ParkingLot.ParkingAttendant.ParkingStrategy.Impl;

namespace ParkingLot.ParkingAttendant
{
    public class SmartParkingBoy : ParkingBoy
    {
        public SmartParkingBoy(int parkinglotsCount, int parkingCapacity) : base(parkinglotsCount, parkingCapacity)
        {
            ParkingStrategy = new SmartParkingBoyStrategy();
        }

        public override string OfferParkingService(string car)
        {
            return ParkingStrategy.ParkingCar(car, ParkinglotList);
        }
    }
}
