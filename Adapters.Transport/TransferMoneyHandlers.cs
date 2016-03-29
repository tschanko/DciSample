using DCI.Core;
using Domain.Model.Ports;
using Domain.UseCases.TransferMoney;
using Domain.UseCases.TransferMoney.Messages;
using NServiceBus;

namespace Adapters.Transport {
    public class TransferMoneyHandlers : IHandleMessages<TransferFromCommand>, IHandleMessages<ReceiveFromCommand> {
        private readonly IContextRouter _contextRouter;
        private readonly IAccountRepository _accountRepository;

        public TransferMoneyHandlers(IContextRouter contextRouter, IAccountRepository accountRepository) {
            _contextRouter = contextRouter;
            _accountRepository = accountRepository;
        }

        public void Handle(TransferFromCommand command) {
            new TransferMoneyContext(_contextRouter, _accountRepository).Execute(command);
        }

        public void Handle(ReceiveFromCommand command) {
            new TransferMoneyContext(_contextRouter, _accountRepository).Execute(command);
        }
    }
}