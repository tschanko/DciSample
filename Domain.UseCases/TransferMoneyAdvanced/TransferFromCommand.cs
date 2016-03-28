using NServiceBus;

namespace Domain.UseCases.TransferMoneyAdvanced {
    public class TransferFromCommand : ICommand {
        public string TransferMoneySourceId { get; set; }
        public string TransferMoneySinkId { get; set; }
        public double Amount { get; set; }
    }
}