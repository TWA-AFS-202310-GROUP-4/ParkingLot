namespace ParkingLot
{
    using System;
    public class ParkingLot
    {
        private string car;
        public string Fetch(string ticket)
        {
            return car;
        }

        public string Park(string car)
        {
            this.car = car;
            return "T-" + car;
        }
    }
}
