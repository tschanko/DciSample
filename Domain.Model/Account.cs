namespace Domain.Model {
    public abstract class Account {
        public abstract void DecreaseBalance(double amount);
        public abstract void IncreaseBalance(double amount);
        public abstract void Log(string message);
    }
}