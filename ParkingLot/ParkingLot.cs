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
        public Dictionary<Guid, Ticket> TicketMap { get; set; }

        public ParkingLot(int cap = 10)
        {
            Id = Guid.NewGuid();
            ParkedCars = new List<Car>();
            TicketMap = new Dictionary<Guid, Ticket>();
            parkingSemaphore = new SemaphoreSlim(cap, cap);
        }

        public async Task<(Ticket, StatusCode)> ParkingCarAsync(Car car)
        {
            try
            {
                if (await parkingSemaphore.WaitAsync(0))
                {
                    lock (TicketMap)
                    {
                        var ticket = new Ticket(car, this);
                        TicketMap[ticket.Id] = ticket;
                        ParkedCars.Add(car);
                        return (ticket, StatusCode.ParkingSuccess);
                    }
                }
                else
                {
                    return (null, StatusCode.OverCapacity);
                }
            }
            catch (Exception)
            {
                return (null, StatusCode.ParkingFailed);
            }
        }

        public async Task<(Car, StatusCode)> FetchCarAsync(Ticket ticket)
        {
            lock (TicketMap)
            {
                if (ticket != null && TicketMap.ContainsKey(ticket.Id) && !ticket.IsUsed)
                {
                    var car = ticket.Car;
                    if (car != null && ParkedCars.Contains(car))
                    {
                        ticket.TransToUsed();
                        ParkedCars.Remove(car);
                        parkingSemaphore.Release();
                        return (car, StatusCode.FetchSuccess);
                    }
                }

                return (null, StatusCode.FetchFailed);
            }
        }
    }
}
