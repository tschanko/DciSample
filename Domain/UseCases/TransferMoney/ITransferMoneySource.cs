using DCI.Core;
using Domain.Model;

namespace Domain.UseCases.TransferMoney {
    public interface ITransferMoneySource : IRole<ITransferMoneySource, Account> {
        // A methodless role is an identifier, hence...
        string Id { get; }
    }
}