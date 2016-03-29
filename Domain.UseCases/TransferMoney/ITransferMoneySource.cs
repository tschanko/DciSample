using DCI.Core;
using Domain.Model;

namespace Domain.UseCases.TransferMoney {
    public interface ITransferMoneySource : IRole<ITransferMoneySource, Account> {
        string Id { get; }
    }
}