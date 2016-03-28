using Domain.Model;

namespace Domain.UseCases.TransferMoneyBasic {
    public class TransferMoneyContext {
        public ITransferMoneySource Source { get; private set; }
        public ITransferMoneySink Sink { get; private set; }

        public double Amount { get; private set; }

        public TransferMoneyContext() {
            
        }
        public TransferMoneyContext(ITransferMoneySource source, ITransferMoneySink sink, double amount) {
            Source = source;
            Sink = sink;
            Amount = amount;
        }

        public void DoIt() {
            Source.TransferFrom(Sink, Amount);
        }
    }
}