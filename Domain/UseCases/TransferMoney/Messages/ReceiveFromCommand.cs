namespace Domain.UseCases.TransferMoney.Messages {
    public class ReceiveFromCommand
    {
        public string TransferMoneySourceId { get; set; }
        public string TransferMoneySinkId { get; set; }
        public double Amount { get; set; }
    }
}