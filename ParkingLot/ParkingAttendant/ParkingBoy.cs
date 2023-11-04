using ParkingLot.ParkingBase;
using System.Collections.Generic;
using System.Linq;

namespace ParkingLot.ParkingAttendant
{
    public class ParkingBoy
    {
        public ParkingBoy()
        {
            ParkinglotList = new List<Parking>
            {
                new Parking(),
            };
        }

        public ParkingBoy(int parkinglotsCount, int parkingCapacity)
        {
            ParkinglotList = Enumerable.Range(0, parkinglotsCount).Select(_ => new Parking(parkingCapacity)).ToList();
        }

        public List<Parking> ParkinglotList { get; set; }
        public virtual string OfferParkingService(string car)
        {
            foreach (var parkinglot in ParkinglotList)
            {
                if (parkinglot.IsAvailable())
                {
                    return parkinglot.Park(car);
                }
            }

            throw new WrongTicketException("No available position.");
        }

        public string OfferFetchingCarService(string ticket)
        {
            foreach (var parkinglot in ParkinglotList)
            {
                if (parkinglot.IsAvailable())
                {
                    return parkinglot.FectchCar(ticket);
                }
            }

            throw new WrongTicketException("Unrecognized parking ticket.");
        }
    }
}