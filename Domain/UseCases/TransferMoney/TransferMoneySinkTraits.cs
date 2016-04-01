using System.ComponentModel;

namespace Domain.UseCases.TransferMoney {
    public static class TransferMoneySinkTraits {
        public static void ReceiveFrom(this ITransferMoneySink self, ITransferMoneySource sender, double amount) {
            var accountSelf = self.Resolve(self);

            if (accountSelf == null) throw new InvalidEnumArgumentException();

            accountSelf.IncreaseBalance(amount);
            accountSelf.Log($"Depositing {amount} to {accountSelf.Id}");
        }
    }
}