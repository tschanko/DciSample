using DCI.Core;
using Domain.UseCases.TransferMoney;
using Domain.UseCases.TransferMoney.Messages;
using NServiceBus;

namespace Domain.NServiceBus {
    public class TransferMoneyHandlers : IHandleMessages<TransferFromCommand>, IHandleMessages<ReceiveFromCommand> {
        private readonly IContextRouter _contextRouter;

        public TransferMoneyHandlers(IContextRouter contextRouter) {
            _contextRouter = contextRouter;
        }

        public void Handle(TransferFromCommand command) {
            new TransferMoneyContext(_contextRouter).Execute(command);
        }

        public void Handle(ReceiveFromCommand command) {
            new TransferMoneyContext(_contextRouter).Execute(command);
        }
    }
}