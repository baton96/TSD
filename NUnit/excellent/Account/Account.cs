using System;
using System.Collections.Generic;
using System.Linq;

namespace Account
{
    public class Account
    {
        private static int accountNumberSeed = 1234567890;
        private List<Transaction> allTransactions = new List<Transaction>();
        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance
        {
            get
            {
                return GetBalance();
            }
        }

        private decimal GetBalance()
        {
            return allTransactions.Sum(t => t.Amount);
        }

        public Account(string name, decimal initialBalance)
        {
            accountNumberSeed++;
            Owner = name;
            allTransactions.Add(new Transaction(initialBalance));
        }

        public Account()
        {
            accountNumberSeed++;
            Owner = "";
        }

        public void Deposit(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            allTransactions.Add(new Transaction(amount));
        }

        public void Withdraw(decimal amount)
        {
            if (amount > Balance || amount < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            allTransactions.Add(new Transaction(-amount));
        }
        public static int GetAccountNumberSeed()
        {
            return accountNumberSeed;
        }
    }
}
