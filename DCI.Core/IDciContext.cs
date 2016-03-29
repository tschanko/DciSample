namespace DCI.Core {
    public interface IDciContext {
        void SendTo<TRole>(object message);
    }
}