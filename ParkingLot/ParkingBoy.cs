using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ParkingLotWork.ParkingBoy
{
    public class ParkingBoy
    {
        private List<ParkingLot> parkinglot = new List<ParkingLot>();
        public ParkingBoy(List<ParkingLot> parkingLot)
        {
            this.parkinglot = parkingLot;
        }

        public ParkingBoy(ParkingLot parkingLot)
        {
            parkinglot.Add(parkingLot);
        }

        public string Park(string car)
        {
            string ticket = string.Empty;
            foreach (var lot in parkinglot)
            {
                if (lot.Capacity < 10)
                {
                    ticket = parkinglot[0].Park(car);
                    break;
                }
            }

            return ticket;
        }

        public string Fetch(string ticket)
        {
            Exception exception = null;
            foreach (var lot in parkinglot)
           {
                try
                {
                    string msg = lot.Fetch(ticket);
                    return msg;
                }
                catch (Exception ex)
                {
                    exception = ex;
                }
           }

            if (exception != null)
            {
                throw exception;
            }

            return null;
        }
    }
}
