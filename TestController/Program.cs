using System;
using Adapters.Persistence;
using Adapters.Transport;
using Domain.UseCases.TransferMoney;
using NServiceBus;

namespace TestController {
    class Program {
        private static ISendOnlyBus _bus;

        static void Main(string[] args) {
            SetupBus();

            var routingTable = CreateRoutingTable();
            var router = new NsbContextRouter(_bus, routingTable);

            var accountRepository = new AccountRepositoryMock();

            Console.WriteLine("Press <Enter> to run transfer:");
            Console.ReadLine();

            var sourceId = "Account/1";
            var sinkId = "Account/2";

            new TransferMoneyContext(sourceId, sinkId, 1000, router, accountRepository).Execute();

            Console.WriteLine("Context started!");
            Console.ReadLine();
        }

        static void SetupBus() {
            BusConfiguration busConfiguration = new BusConfiguration();
            EndpointConfiguration.Customize(busConfiguration);
            _bus = Bus.CreateSendOnly(busConfiguration);
        }

        static RoleRoutingTable CreateRoutingTable() {
            var rt = new RoleRoutingTable();
            rt.RegisterRoute(typeof(ITransferMoneySource), "EndpointA");
            rt.RegisterRoute(typeof(ITransferMoneySink), "EndpointB");
            return rt;
        }
    }
}