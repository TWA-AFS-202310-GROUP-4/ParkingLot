using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using static ParkingLot.StrategyRegister;

namespace ParkingLot
{
    public class ParkingBoy
    {
        private SelectParkingLotDelegate selectParkingLotDelegate;
        public List<ParkingLot> ParkingLots { get; set; }

        public ParkingBoy(List<ParkingLot> parkinglots, SelectParkingLotDelegate selectParkingLotDelegate)
        {
            ParkingLots = parkinglots;
            this.selectParkingLotDelegate = selectParkingLotDelegate;
        }

        public virtual async Task<(Ticket, StatusCode)> ParkAsync(Car car)
        {
            var parkingLot = selectParkingLotDelegate(ParkingLots);
            if (parkingLot != null)
            {
                return await parkingLot.ParkingCarAsync(car);
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
