using ParkingLot.ParkingBase;

namespace ParkingLot.ParkingAttendant
{
    public class ParkingBoy
    {
        private Parking parkinglot;
        public ParkingBoy()
        {
            parkinglot = new Parking();
        }

        public string OfferParkingService(string car)
        {
            return parkinglot.Park(car);
        }

        public string OfferFetchingCarService(string ticket)
        {
            return parkinglot.FectchCar(ticket);
        }
    }
}

