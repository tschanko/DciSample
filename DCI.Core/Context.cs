using System;

namespace DCI.Core {
    public abstract class Context : IContext {
        private readonly IRoleRouter _roleRouter;
        public IContext CurrentContext => this;

        protected Context(IRoleRouter roleRouter) {
            _roleRouter = roleRouter;
        }

        public void SendTo<TRole>(object message) {
            _roleRouter.SendTo<TRole>(message);
        }


    }
}