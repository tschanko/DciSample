namespace Domain.UseCases.TransferMoneyAdvanced {
    public abstract class DciContext : IContext {
        public IContext Context => this;
        public IContextRouter ContextRouter { get; }
        public IRoleResolver RoleResolver { get; }
    }
}