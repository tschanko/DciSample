using Domain.Model;
using Domain.Model.Ports;

namespace Adapters.Persistence {
    public class AccountRepositoryMock : IAccountRepository{
        public Account Load(string id) {
            switch (id) {
                case "Account/1":
                case "Account/2":
                    return new SavingsAccount { Id = id };
                default:
                    return null;
            }
        }

        public Account Store(Account account) {
            throw new System.NotImplementedException();
        }
    }
}