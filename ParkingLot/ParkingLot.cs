namespace ParkingLot
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class ParkingLot
    {
        private SemaphoreSlim parkingSemaphore;
        public Guid Id { get; set; }
        public List<Car> ParkedCars { get; set; }
        public Dictionary<Guid, Ticket> Tickets { get; set; }

        public ParkingLot(int cap = 10)
        {
            Id = Guid.NewGuid();
            ParkedCars = new List<Car>();
            Tickets = new Dictionary<Guid, Ticket>();
            parkingSemaphore = new SemaphoreSlim(cap, cap);
        }

        public async Task<Ticket> ParkingCarAsync(Car car)
        {
            try
            {
                if (await parkingSemaphore.WaitAsync(0))
                {
                    lock (ParkedCars)
                    {
                        var ticket = new Ticket(car, this);
                        Tickets[ticket.Id] = ticket;
                        ParkedCars.Add(car);
                        return ticket;
                    }
                }

                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Car> FetchCarAsync(Ticket ticket)
        {
            lock (ParkedCars)
            {
                if (ticket != null && Tickets.ContainsKey(ticket.Id) && !ticket.IsUsed)
                {
                    var car = ticket.Car;
                    if (car != null && ParkedCars.Contains(car))
                    {
                        ticket.TransToUsed();
                        ParkedCars.Remove(car);
                        parkingSemaphore.Release();
                        return car;
                    }
                }

                return null;
            }
        }
    }
}
