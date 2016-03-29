namespace DCI.Core {
    public interface IRole<TRole, out TActor> {
        IDciContext Context { get;  }
        TActor Resolve(TRole role);
    }
}