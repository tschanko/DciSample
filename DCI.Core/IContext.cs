namespace DCI.Core {
    public interface IContext {
        void SendTo<TRole>(object message);
    }
}