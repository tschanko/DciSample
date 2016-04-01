using Domain.Model;

namespace Domain.Ports {
    public interface IAccountRepository {
        Account Load(string id);
        Account Store(Account account);
    }
}