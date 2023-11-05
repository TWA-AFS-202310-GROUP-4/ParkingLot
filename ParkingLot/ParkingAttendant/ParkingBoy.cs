using ParkingLot.ParkingAttendant.ParkingStrategy;
using ParkingLot.ParkingAttendant.ParkingStrategy.Impl;
using ParkingLot.ParkingBase;
using System.Collections.Generic;
using System.Linq;

namespace ParkingLot.ParkingAttendant
{
    public class ParkingBoy
    {
        public ParkingBoy()
        {
            ParkingStrategy = new ParkingBoyStrategy();
            ParkinglotList = new List<Parking>
            {
                new Parking(),
            };
        }

        public ParkingBoy(int parkinglotsCount, int parkingCapacity)
        {
            ParkingStrategy = new ParkingBoyStrategy();
            ParkinglotList = Enumerable.Range(0, parkinglotsCount).Select(_ => new Parking(parkingCapacity)).ToList();
        }

        public IParkingStrategy ParkingStrategy { get; set; }

        public List<Parking> ParkinglotList { get; set; }

        public virtual string OfferParkingService(string car)
        {
            return ParkingStrategy.ParkingCar(car, ParkinglotList);
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