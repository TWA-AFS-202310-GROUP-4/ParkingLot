﻿using System.Collections.Generic;

namespace ParkingLot.Parking
{
    public class Parking
    {
        private Dictionary<string, string> parkingRecord;
        public Parking()
        {
            parkingRecord = new Dictionary<string, string>();
        }

        public Parking(int capacity)
        {
            parkingRecord = new Dictionary<string, string>();
            this.Capacity = capacity;
        }

        public int Capacity { get; set; } = 10;

        public string Park(string car)
        {
            if (Capacity == 0)
            {
                throw new WrongTicketException("No available position.");
            }

            Capacity--;
            var ticket = car + "-ticket";
            parkingRecord.Add(ticket, car);
            return ticket;
        }

        public string FectchCar(string ticket)
        {
            if (ticket == null)
            {
                return null;
            }

            if (!parkingRecord.ContainsKey(ticket))
            {
                throw new WrongTicketException("Unrecognized parking ticket.");
            }

            var res = parkingRecord[ticket];
            parkingRecord.Remove(ticket);
            Capacity++;
            return res;
        }
    }
}
