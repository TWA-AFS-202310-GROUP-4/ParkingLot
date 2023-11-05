using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace ParkingLot
{
    public class ParkingBoy
    {
        public List<ParkingLot> ParkingLots { get; set; }
        // choosenParkingLot
        public ParkingBoy(List<ParkingLot> parkinglots)
        {
            ParkingLots = parkinglots;
        }

        public virtual async Task<(Ticket, StatusCode)> ParkAsync(Car car)
        {
            foreach (var parkingLot in ParkingLots)
            {
                (Ticket ticket, StatusCode statuscode) = await parkingLot.ParkingCarAsync(car);
                if (statuscode == StatusCode.ParkingSuccess)
                {
                    return (ticket, statuscode);
                }
            }

            return (null, StatusCode.ParkingFailed);
        }

        public virtual async Task<(Car, StatusCode)> FetchAsync(Ticket ticket)
        {
            foreach (var parkingLot in ParkingLots)
            {
                (Car car, StatusCode statuscode) = await parkingLot.FetchCarAsync(ticket);
                if (statuscode == StatusCode.FetchSuccess)
                {
                    return (car, statuscode);
                }
            }

            return (null, StatusCode.FetchFailed);
        }
    }
}
