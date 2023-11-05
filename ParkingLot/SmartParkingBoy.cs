using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ParkingLot.StrategyRegister;

namespace ParkingLot
{
    public class SmartParkingBoy : ParkingBoy
    {
        public SmartParkingBoy(List<ParkingLot> parkinglots, SelectParkingLotDelegate selectParkingLotDelegate) : base(parkinglots, selectParkingLotDelegate)
        {
        }

        /*public override async Task<(Ticket, StatusCode)> ParkAsync(Car car)
        {
            var filterPakingLot = ParkingLots.Where(parkingLot => parkingLot.EmptySlots > 0).ToList();
            var selectedParkingLot = filterPakingLot.Any() ? filterPakingLot.OrderByDescending(parkingLot => parkingLot.EmptySlots).First() : null;
            if (selectedParkingLot != null)
            {
                return await selectedParkingLot.ParkingCarAsync(car);
            }

            return (null, StatusCode.ParkingFailed);
        }

        public override async Task<(Car, StatusCode)> FetchAsync(Ticket ticket)
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
        }*/
    }
}
