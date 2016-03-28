using NServiceBus;

namespace Domain.UseCases.TransferMoneyAdvanced {
    public interface IContextRouter {
        IContextRouter Send(ICommand command);
        void To(IRole recipient);
    }
}