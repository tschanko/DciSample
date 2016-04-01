namespace DCI.Core {
    public interface IRole<TRole, out TActor> {
        IContext CurrentContext { get;  }
        TActor Resolve(TRole role);
    }
}