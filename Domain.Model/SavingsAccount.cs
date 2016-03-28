using System;

namespace Domain.Model {
    public class SavingsAccount : Account, ITransferMoneySource, ITransferMoneySink {
        public SavingsAccount() {
            _balance = 10000;
        }

        private double _balance;

        public override void DecreaseBalance(double amount) {
            _balance -= amount;
        }

        public override void IncreaseBalance(double amount) {
            _balance += amount;
        }

        public override void Log(string message) {
            Console.WriteLine(message);
        }

        public override string ToString() {
            return $"Balance: {_balance}";
        }
    }
}