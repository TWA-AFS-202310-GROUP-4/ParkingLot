using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class Ticket
    {
        public Guid Id { get; set; }
        public Car Car { get; set; }
        public ParkingLot ParkingLot { get; set; }
        public bool IsUsed { get; set; }

        public Ticket(Car car, ParkingLot parkingLot)
        {
            Id = Guid.NewGuid();
            Car = car;
            ParkingLot = parkingLot;
            IsUsed = false;
        }

        public void TransToUsed()
        {
            IsUsed = true;
        }
    }
}
