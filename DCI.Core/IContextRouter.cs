using System;

namespace DCI.Core {
    public interface IContextRouter {
        void SendTo<TRole>(object message);
    }
}