using DCI.Core;
using Domain.Ports;
using Domain.UseCases.TransferMoney;
using Domain.UseCases.TransferMoney.Messages;
using NServiceBus;

namespace Adapters.Transport {
    public class TransferMoneyHandlers : IHandleMessages<TransferFromCommand>, IHandleMessages<ReceiveFromCommand> {
        private readonly TransferMoneyContextFactory _contextFactory;


        public TransferMoneyHandlers(TransferMoneyContextFactory contextFactory) {
            _contextFactory = contextFactory;
        }

        public void Handle(TransferFromCommand command) {
            _contextFactory
                .ReconstituteContextFrom(command)
                .Execute(command);
        }

        public void Handle(ReceiveFromCommand command) {
            _contextFactory
                .ReconstituteContextFrom(command)
                .Execute(command);
        }
    }
}