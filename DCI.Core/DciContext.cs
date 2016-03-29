using System;

namespace DCI.Core {
    public abstract class DciContext : IDciContext {
        private readonly IContextRouter _contextRouter;
        public IDciContext Context => this;

        protected DciContext(IContextRouter contextRouter) {
            _contextRouter = contextRouter;
        }

        public void SendTo<TRole>(object message) {
            _contextRouter.SendTo<TRole>(message);
        }


    }
}