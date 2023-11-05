namespace ParkingLotTest
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using ParkingLot;
    using Xunit;

    public class ParkingBoyTest
    {
        [Fact]
        public async Task Should_return_ticket_given_parkinglot_and_car_then_park_carAsync()
        {
            var parkingLot = new ParkingLot();
            var parkingBoy = new ParkingBoy(parkingLot);
            var car = new Car();
            var parkingInfo = await parkingBoy.ParkAsync(car);
            Assert.NotNull(parkingInfo.Item1);
        }

        [Fact]
        public async Task Should_return_parkedcar_given_parkingticket_and_car_then_fetch_carAsync()
        {
            var parkingLot = new ParkingLot();
            var parkingBoy = new ParkingBoy(parkingLot);
            var parkedCar = new Car();
            var parkingInfo = await parkingBoy.ParkAsync(parkedCar);
            var fetchedInfo = await parkingBoy.FetchAsync(parkingInfo.Item1);
            Assert.Equal(parkedCar.Id, fetchedInfo.Item1.Id);
        }

        [Fact]
        public async void Should_return_rightparked_car_given_parkingticket_and_car_then_fetch_car()
        {
            var parkingLot = new ParkingLot();
            var parkingBoy = new ParkingBoy(parkingLot);
            var parkedCar1 = new Car();
            var parkedCar2 = new Car();
            var parkingInfo1 = await parkingBoy.ParkAsync(parkedCar1);
            var parkingInfo2 = await parkingBoy.ParkAsync(parkedCar2);
            Assert.Equal(parkedCar1.Id, (await parkingLot.FetchCarAsync(parkingInfo1.Item1)).Item1.Id);
            Assert.Equal(parkedCar2.Id, (await parkingLot.FetchCarAsync(parkingInfo2.Item1)).Item1.Id);
        }

        [Fact]
        public async Task Should_return_null_given_wrong_parkingticket_then_fetch_carAsync()
        {
            var parkingLot = new ParkingLot();
            var parkingBoy = new ParkingBoy(parkingLot);
            var wrongTicket = new Ticket(new Car(), new ParkingLot());
            var fetchedInfo = await parkingBoy.FetchAsync(wrongTicket);
            Assert.Null(fetchedInfo.Item1);
            Assert.Equal("Unrecognized parking ticket", fetchedInfo.Item2 == StatusCode.FetchFailed ? Constants.UnrecognizedTicketMessage : Constants.DefaultMessage);
        }

        [Fact]
        public async Task Should_return_null_given_used_parkingticket_then_fetch_carAsync()
        {
            var parkingLot = new ParkingLot();
            var parkingBoy = new ParkingBoy(parkingLot);
            var parkedCar = new Car();
            var parkingInfo = await parkingBoy.ParkAsync(parkedCar);
            _ = await parkingBoy.FetchAsync(parkingInfo.Item1);
            var fetchedAgain = await parkingBoy.FetchAsync(parkingInfo.Item1);
            Assert.Null(fetchedAgain.Item1);
            Assert.Equal("Unrecognized parking ticket", fetchedAgain.Item2 == StatusCode.FetchFailed ? Constants.UnrecognizedTicketMessage : Constants.DefaultMessage);
        }

        [Fact]
        public async void Should_return_null_given_noposition_parkinglot_then_parking_car()
        {
            List<Thread> threadpool = new List<Thread>();
            var parkingLot = new ParkingLot();
            var parkingBoy = new ParkingBoy(parkingLot);
            for (var slot = 0; slot < 10; slot++)
            {
                Thread parking = new Thread(() =>
                {
                    var parkedCar = new Car();
                    _ = parkingBoy.ParkAsync(parkedCar);
                });
                threadpool.Add(parking);
                parking.Start();
            }

            foreach (var thread in threadpool)
            {
                thread.Join();
            }

            var parkedCar1 = new Car();
            var parkingInfoNew = await parkingBoy.ParkAsync(parkedCar1);
            Assert.Null(parkingInfoNew.Item1);
            Assert.Equal("No available position", parkingInfoNew.Item2 == StatusCode.OverCapacity ? Constants.NoAvailablePositionMessage : Constants.DefaultMessage);
        }
    }
}
