using DCI.Core;
using Domain.Model;

namespace Domain.UseCases.TransferMoney {
    public interface ITransferMoneySink : IRole<ITransferMoneySink, Account> {
        string Id { get; }
    }
}