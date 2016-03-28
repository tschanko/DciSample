namespace Domain.UseCases.TransferMoneyAdvanced {
    public class TransferMoneyContext : DciContext, ITransferMoneySourceAdv, ITransferMoneySinkAdv {
        public ITransferMoneySourceAdv Source => this;
        private string _sourceId;
        string ITransferMoneySourceAdv.Id => _sourceId;

        public ITransferMoneySinkAdv Sink => this;
        private string _sinkId;
        string ITransferMoneySinkAdv.Id => _sinkId;

        public double Amount { get; private set; }

        public TransferMoneyContext() {
        }

        public TransferMoneyContext(string sourceId, string sinkId, double amount) {
            Initialize(sourceId, sinkId, amount);
        }

        private void Initialize(string sourceId, string sinkId, double amount) {
            _sourceId = sourceId;
            _sinkId = sinkId;
            Amount = amount;
        }


        public void Start() {
            var transferFrom = new TransferFromCommand {
                TransferMoneySourceId = Source.Id,
                TransferMoneySinkId = Sink.Id,
                Amount = Amount
            };

            ContextRouter.Send(transferFrom).To(Source);
        }

        public void Execute(TransferFromCommand command) {
            Initialize(command.TransferMoneySourceId, command.TransferMoneySinkId, command.Amount);
            Source.TransferFrom(Sink, Amount);
        }

        public void Execute(ReceiveFromCommand command) {
            Initialize(command.TransferMoneySourceId, command.TransferMoneySinkId, command.Amount);
            Sink.ReceiveFrom(Source, Amount);
        }
    }
}