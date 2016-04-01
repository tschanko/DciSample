using DCI.Core;
using NServiceBus;

namespace Adapters.Transport {
    public class NsbRoleRouter : IRoleRouter {
        private readonly ISendOnlyBus _bus;
        private readonly RoleRoutingTable _routingTable;

        public NsbRoleRouter(ISendOnlyBus bus, RoleRoutingTable routingTable) {
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