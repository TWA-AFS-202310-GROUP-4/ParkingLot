﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public interface IParkingStrategy
    {
        public string Park(string car, ParkingLot[] parkingLots);

        public string Fetch(string ticket, ParkingLot[] parkingLots);
    }
}
