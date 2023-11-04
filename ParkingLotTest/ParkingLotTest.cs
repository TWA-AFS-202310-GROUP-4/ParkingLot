namespace ParkingLotTest
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using ParkingLot;
    using Xunit;

    public class ParkingLotTest
    {
        [Fact]
        public async Task Should_return_ticket_given_parkinglot_and_car_then_park_carAsync()
        {
            var parkingLot = new ParkingLot();
            var car = new Car();
            var ticket = await parkingLot.ParkingCarAsync(car);
            Console.Write(ticket.Id);
            Assert.NotNull(ticket);
        }

        [Fact]
        public async Task Should_return_parked_car_given_parkingticket_and_car_then_fetch_carAsync()
        {
            var parkingLot = new ParkingLot();
            var parkedCar = new Car();
            var ticket = await parkingLot.ParkingCarAsync(parkedCar);
            Assert.Equal(parkedCar, await parkingLot.FetchCarAsync(ticket));
        }

        [Fact]
        public async void Should_return_rightparked_car_given_parkingticket_and_car_then_fetch_car()
        {
            var parkingLot = new ParkingLot();
            var parkedCar1 = new Car();
            var parkedCar2 = new Car();
            var ticket1 = await parkingLot.ParkingCarAsync(parkedCar1);
            var ticket2 = await parkingLot.ParkingCarAsync(parkedCar2);
            Assert.Equal(parkedCar1, await parkingLot.FetchCarAsync(ticket1));
            Assert.Equal(parkedCar2, await parkingLot.FetchCarAsync(ticket2));
        }

        [Fact]
        public async Task Should_return_null_given_wrong_parkingticket_then_fetch_carAsync()
        {
            var parkingLot = new ParkingLot();
            var parkedCar1 = new Car();
            var wrongTicket = new Ticket(new Car(), new ParkingLot());
            Assert.Null(await parkingLot.FetchCarAsync(wrongTicket));
        }

        [Fact]
        public async Task Should_return_null_given_used_parkingticket_then_fetch_carAsync()
        {
            var parkingLot = new ParkingLot();
            var parkedCar = new Car();
            var ticket = await parkingLot.ParkingCarAsync(parkedCar);
            var fetchCar = await parkingLot.FetchCarAsync(ticket);
            Assert.Null(await parkingLot.FetchCarAsync(ticket));
        }

        [Fact]
        public async void Should_return_null_given_noposition_parkinglot_then_parking_car()
        {
            List<Thread> threadpool = new List<Thread>();
            var parkingLot = new ParkingLot();
            for (var slot = 0; slot < 10; slot++)
            {
                Thread parking = new Thread(() =>
                {
                    var parkedCar = new Car();
                    _ = parkingLot.ParkingCarAsync(parkedCar);
                });
                threadpool.Add(parking);
                parking.Start();
            }

            foreach (var thread in threadpool)
            {
                thread.Join();
            }

            var parkedCar1 = new Car();
            Assert.Null(await parkingLot.ParkingCarAsync(parkedCar1));
        }
    }
}
