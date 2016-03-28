using System.ComponentModel;
using Domain.Model;

namespace Domain.UseCases.TransferMoneyAdvanced {
    public static class TransferMoneySourceTraits {
        public static void TransferFrom(this ITransferMoneySourceAdv self, ITransferMoneySinkAdv recipient, double amount) {
            var accountSelf =
                self
                .Context
                .RoleResolver
                .Resolve<Account, ITransferMoneySourceAdv>(self);

            if (accountSelf == null) throw new InvalidEnumArgumentException();

            accountSelf.DecreaseBalance(amount);
            accountSelf.Log($"Withdrawing {amount}");

            var receiveFrom = new ReceiveFromCommand {
                TransferMoneySourceId = self.Id,
                TransferMoneySinkId = recipient.Id,
                Amount = amount
            };

            self.Context.ContextRouter.Send(receiveFrom).To(recipient);

        }
    }
}