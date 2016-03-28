namespace Domain.UseCases.TransferMoneyAdvanced {
    public interface IContext {
        IContextRouter ContextRouter { get; }
        IRoleResolver RoleResolver { get; }
    }
}