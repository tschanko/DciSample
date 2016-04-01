using DCI.Core;
using Domain.Model;
using Domain.Ports;
using Domain.UseCases.TransferMoney.Messages;

namespace Domain.UseCases.TransferMoney {
    public class TransferMoneyContext : Context, ITransferMoneySource, ITransferMoneySink {
        private readonly IAccountRepository _accountRepository;

        private readonly string _sourceId;
        private readonly string _sinkId;
        private readonly double _amount;

        public ITransferMoneySource Source => this;
        string ITransferMoneySource.Id => _sourceId;

        public Account Resolve(ITransferMoneySource role) {
            return _accountRepository.Load(role.Id);
        }

        public ITransferMoneySink Sink => this;
        string ITransferMoneySink.Id => _sinkId;

        public Account Resolve(ITransferMoneySink role) {
            return _accountRepository.Load(role.Id);
        }

        public double Amount => _amount;

        public void Start() {
            var transferFrom = new TransferFromCommand {
                TransferMoneySourceId = Source.Id,
                TransferMoneySinkId = Sink.Id,
                Amount = Amount
            };

            SendTo<ITransferMoneySource>(transferFrom);
        }

        public void Execute(TransferFromCommand command) {
            Source.TransferFrom(Sink, Amount);
        }

        public void Execute(ReceiveFromCommand command) {
            Sink.ReceiveFrom(Source, Amount);
        }

        internal TransferMoneyContext(string sourceId, string sinkId, double amount, IRoleRouter roleRouter,
            IAccountRepository accountRepository)
            : base(roleRouter) {
            _sourceId = sourceId;
            _sinkId = sinkId;
            _amount = amount;
            _accountRepository = accountRepository;
        }
    }
}