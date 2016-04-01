using DCI.Core;
using Domain.Ports;
using Domain.UseCases.TransferMoney.Messages;

namespace Domain.UseCases.TransferMoney {
    public class TransferMoneyContextFactory {
        private readonly IRoleRouter _roleRouter;
        private readonly IAccountRepository _accountRepository;

        public TransferMoneyContextFactory(IRoleRouter roleRouter, IAccountRepository accountRepository) {
            // Technical dependency/infrastucture  for every Context
            _roleRouter = roleRouter;

            // Dependency for the TransferMoneyContext
            _accountRepository = accountRepository;
        }

        public TransferMoneyContext CreateContext(string sourceId, string sinkId, double amount) {
            return new TransferMoneyContext(sourceId, sinkId, amount, _roleRouter, _accountRepository);
        }

        public TransferMoneyContext ReconstituteContextFrom(TransferFromCommand command)
        {
            return new TransferMoneyContext(
                command.TransferMoneySourceId,
                command.TransferMoneySinkId,
                command.Amount, 
                _roleRouter, 
                _accountRepository);
        }

        public TransferMoneyContext ReconstituteContextFrom(ReceiveFromCommand command)
        {
            return new TransferMoneyContext(
                command.TransferMoneySourceId,
                command.TransferMoneySinkId,
                command.Amount,
                _roleRouter,
                _accountRepository);
        }
    }
}