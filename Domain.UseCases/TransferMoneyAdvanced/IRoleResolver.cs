namespace Domain.UseCases.TransferMoneyAdvanced {
    public interface IRoleResolver {
        TActor Resolve<TActor, TRole>(TRole role) where TRole : IRole;
    }
}