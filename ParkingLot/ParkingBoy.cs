﻿using ParkingLot;
using ParkingLot.Exception;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace ParkingLotWork.ParkingBoy
{
    public class ParkingBoy : IParkingStrategy
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
            return parkinglots.OrderByDescending(pa => pa.Capacity).FirstOrDefault().Park(car);
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

            throw exception;
        }
    }
}
