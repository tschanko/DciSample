using System.ComponentModel;
using Domain.UseCases.TransferMoney.Messages;

namespace Domain.UseCases.TransferMoney {
    public static class TransferMoneySourceTraits {
        public static void TransferFrom(this ITransferMoneySource self, ITransferMoneySink recipient, double amount) {
            var accountSelf = self.Resolve(self);

            if (accountSelf == null) throw new InvalidEnumArgumentException();

            accountSelf.DecreaseBalance(amount);
            accountSelf.Log($"Withdrawing {amount} from {accountSelf.Id}");

            var receiveFrom = new ReceiveFromCommand {
                TransferMoneySourceId = self.Id,
                TransferMoneySinkId = recipient.Id,
                Amount = amount
            };

            self.CurrentContext.SendTo<ITransferMoneySink>(receiveFrom);

        }
    }
}