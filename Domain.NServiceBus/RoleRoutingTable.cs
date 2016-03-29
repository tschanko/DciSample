using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Domain.NServiceBus {
    public class RoleRoutingTable {
        private readonly ConcurrentDictionary<Type, string> _routes = new ConcurrentDictionary<Type, string>();

        public void RegisterRoute(Type roleType, string route) {
            _routes.TryAdd(roleType, route);
        }

        public string GetRoute(Type roleType) {
            return _routes[roleType];
        }
    }
}