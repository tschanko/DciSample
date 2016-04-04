namespace DCI.Core {
    /// <summary>
    /// For now, this is somewhat like the connection between the methodless role (identifier) and 
    /// the actor playing the role at runtime. Strange ...!?
    /// </summary>
    /// <typeparam name="TRole">The methodless role (identifier)</typeparam>
    /// <typeparam name="TActor"></typeparam>
    public interface IRole<TRole, out TActor> {
        IContext CurrentContext { get;  }
        TActor Resolve(TRole role);
    }
}