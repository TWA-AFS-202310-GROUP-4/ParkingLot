using ParkingLot.Exception;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace ParkingLotWork.ParkingBoy
{
    public class ParkingBoy
    {
        private List<ParkingLot> parkinglots;
        public ParkingBoy(List<ParkingLot> parkingLot)
        {
            this.parkinglots = parkingLot;
        }

        public ParkingBoy(ParkingLot parkingLot)
        {
            parkinglots = new List<ParkingLot>();
            parkinglots.Add(parkingLot);
        }

        public string Park(string car)
        {
            parkinglots = parkinglots.OrderByDescending(pa => pa.Capacity).ToList();
            Exception exception = null;
            foreach (var lot in parkinglots)
            {
                Console.WriteLine(lot.Capacity);
                try
                {
                    if (lot.Capacity > 0)
                    {
                        string ticket = lot.Park(car);
                        return ticket;
                    }
                }
                catch (Exception e)
                {
                    exception = e;
                }
            }

            if (exception != null)
            {
                throw exception;
            }

            return null;
        }

        public string Fetch(string ticket)
        {
            Exception exception = null;
            foreach (var lot in parkinglots)
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

            return string.Empty;
        }
    }
}
