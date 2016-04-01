using System;

namespace DCI.Core {
    public abstract class DciContext : IDciContext {
        private readonly IRoleRouter _roleRouter;
        public IDciContext Context => this;

        protected DciContext(IRoleRouter roleRouter) {
            _roleRouter = roleRouter;
        }

        public void SendTo<TRole>(object message) {
            _roleRouter.SendTo<TRole>(message);
        }


    }
}