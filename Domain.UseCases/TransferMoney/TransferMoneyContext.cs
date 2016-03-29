using DCI.Core;
using Domain.Model;
using Domain.UseCases.TransferMoney.Messages;

namespace Domain.UseCases.TransferMoney {
    public class TransferMoneyContext : DciContext, ITransferMoneySource, ITransferMoneySink {

        public ITransferMoneySource Source => this;
        private string _sourceId;
        string ITransferMoneySource.Id => _sourceId;
        public Account Resolve(ITransferMoneySource role) {
            return new SavingsAccount {Id = role.Id};
        }

        public ITransferMoneySink Sink => this;
        private string _sinkId;
        string ITransferMoneySink.Id => _sinkId;
        public Account Resolve(ITransferMoneySink role) {
            return new SavingsAccount {Id = role.Id};
        }

        public double Amount { get; private set; }

        public TransferMoneyContext(IContextRouter contextRouter) : base(contextRouter) {
        }

        public TransferMoneyContext(string sourceId, string sinkId, double amount, IContextRouter contextRouter)
            : base(contextRouter) {
            Initialize(sourceId, sinkId, amount);
        }
        
        public void Execute() {
            var transferFrom = new TransferFromCommand {
                TransferMoneySourceId = Source.Id,
                TransferMoneySinkId = Sink.Id,
                Amount = Amount
            };

            SendTo<ITransferMoneySource>(transferFrom);
        }

        public void Execute(TransferFromCommand command) {
            Initialize(command.TransferMoneySourceId, command.TransferMoneySinkId, command.Amount);
            Source.TransferFrom(Sink, Amount);
        }

        public void Execute(ReceiveFromCommand command) {
            Initialize(command.TransferMoneySourceId, command.TransferMoneySinkId, command.Amount);
            Sink.ReceiveFrom(Source, Amount);
        }

        private void Initialize(string sourceId, string sinkId, double amount)
        {
            _sourceId = sourceId;
            _sinkId = sinkId;
            Amount = amount;
        }


    }
}