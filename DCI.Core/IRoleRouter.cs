using System;

namespace DCI.Core {
    public interface IRoleRouter {
        void SendTo<TRole>(object message);
    }
}