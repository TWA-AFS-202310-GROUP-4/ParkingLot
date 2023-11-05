using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class ParkingBoy
    {
        public ParkingLot ParkingLot { get; set; }
        // choosenParkingLot
        public ParkingBoy(ParkingLot parkinglot)
        {
            ParkingLot = parkinglot;
        }

        public async Task<(Ticket, StatusCode)> ParkAsync(Car car)
        {
            return await ParkingLot?.ParkingCarAsync(car);
        }

        public async Task<(Car, StatusCode)> FetchAsync(Ticket ticket)
        {
            return await ParkingLot?.FetchCarAsync(ticket);
        }
    }
}
