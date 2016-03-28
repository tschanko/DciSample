using System.ComponentModel;
using Domain.Model;

namespace Domain.UseCases.TransferMoneyAdvanced {
    public static class TransferMoneySinkTraits {
        public static void ReceiveFrom(this ITransferMoneySinkAdv self, ITransferMoneySourceAdv sender, double amount) {
            var accountSelf = 
                self
                    .Context
                    .RoleResolver
                    .Resolve<Account, ITransferMoneySinkAdv>(self);

            if (accountSelf == null) throw new InvalidEnumArgumentException();

            accountSelf.IncreaseBalance(amount);
            accountSelf.Log($"Depositing {amount}");
        }
    }
}