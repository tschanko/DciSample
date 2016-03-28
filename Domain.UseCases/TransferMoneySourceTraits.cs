using System.ComponentModel;
using Domain.Model;

namespace Domain.UseCases {
    public static class TransferMoneySourceTraits {
        public static void TransferFrom(this ITransferMoneySource self, ITransferMoneySink recipient, double amount) {
            var accountSelf = self as Account;
            var accountRecipient = recipient as Account;

            if(accountSelf == null || accountRecipient == null) throw new InvalidEnumArgumentException();

            accountSelf.DecreaseBalance(amount);
            accountSelf.Log($"Withdrawing {amount}");
            accountRecipient.IncreaseBalance(amount);
            accountRecipient.Log($"Depositing {amount}");

        }
    }
}