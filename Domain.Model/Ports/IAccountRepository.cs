namespace Domain.Model.Ports {
    public interface IAccountRepository {
        Account Load(string id);
        Account Store(Account account);
    }
}