namespace ParkingLotWork.ParkingBoy
{
    public class ParkingBoy
    {
        private ParkingLot parkinglot;

        public ParkingBoy(ParkingLot parkingLot)
        {
            this.parkinglot = parkingLot;
        }

        public string Park(string car)
        {
            return parkinglot.Park(car);
        }

        public string Fetch(string ticket)
        {
            return parkinglot.Fetch(ticket);
        }
    }
}
