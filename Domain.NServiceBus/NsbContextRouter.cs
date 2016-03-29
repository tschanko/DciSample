using System;
using DCI.Core;
using Domain.UseCases.TransferMoney;
using NServiceBus;

namespace Domain.NServiceBus {
    public class NsbContextRouter : IContextRouter {
        private readonly ISendOnlyBus _bus;
        private readonly RoleRoutingTable _routingTable;

        public NsbContextRouter(ISendOnlyBus bus, RoleRoutingTable routingTable) {
            _bus = bus;
            _routingTable = routingTable;
        }

        public void SendTo<TRole>(object message) {
            var route = _routingTable.GetRoute(typeof (TRole));
            var endpointAdress = Address.Parse(route);
            _bus.Send(endpointAdress, message);
        }



        
    }
}