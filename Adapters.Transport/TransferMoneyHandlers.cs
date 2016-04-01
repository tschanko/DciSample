using DCI.Core;
using Domain.Model.Ports;
using Domain.UseCases.TransferMoney;
using Domain.UseCases.TransferMoney.Messages;
using NServiceBus;

namespace Adapters.Transport {
    public class TransferMoneyHandlers : IHandleMessages<TransferFromCommand>, IHandleMessages<ReceiveFromCommand> {
        private readonly IRoleRouter _roleRouter;
        private readonly IAccountRepository _accountRepository;

        public TransferMoneyHandlers(IRoleRouter roleRouter, IAccountRepository accountRepository) {
            _roleRouter = roleRouter;
            _accountRepository = accountRepository;
        }

        public void Handle(TransferFromCommand command) {
            new TransferMoneyContext(command, _roleRouter, _accountRepository).Execute(command);
        }

        public void Handle(ReceiveFromCommand command) {
            new TransferMoneyContext(command, _roleRouter, _accountRepository).Execute(command);
        }
    }
}