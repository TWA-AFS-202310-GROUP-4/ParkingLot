﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class Car
    {
        public Guid Id { get; set; }

        public Car()
        {
            Id = Guid.NewGuid();
        }
    }
}
