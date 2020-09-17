using NUnit.Framework;
using System;

namespace Account.Test
{
    [TestFixture]
    public class AccountTest
    {
        [Test]
        public void SeedIncrement_Test()
        {
            //TODO: accountNumberSeed is incremented after each Account initialization
            Account account1 = new Account();
            Account account2 = new Account();
            Assert.AreEqual(int.Parse(account1.Number) + 1, int.Parse(account2.Number));
        }

        [Test]
        public void EmptyConstructor_Test()
        {
            //TODO: account initialized with empty constructor returns Balance equal to 0 and Owner as empty string
            Account account = new Account();
            Assert.AreEqual(0, account.Balance);
            Assert.AreEqual("", account.Owner);
        }

        [Test]
        public void Deposit_Test()
        {
            //TODO: Deposit method increases Balance with given amount
            Account account = new Account();
            decimal before = account.Balance;
            int amount = 1;            
            account.Deposit(amount);
            Assert.AreEqual(before+amount, account.Balance);
        }

        [Test]
        public void NotEmptyConstructor_Test()
        {
            //TODO: account initialized with not empty constructor returns Balance equal to initialBalance and Owner 
            //equal to given name
            decimal initialBalance = 1;
            string name = "Name";
            Account account = new Account(name, initialBalance);
            Assert.AreEqual(initialBalance, account.Balance);
            Assert.AreEqual(name, account.Owner);
        }

        [Test]
        public void DepositException_Test()
        {
            //TODO: negative amount parameter passed to Deposit method throws ArgumentOutOfRangeException exception         ;
            Assert.Throws<ArgumentOutOfRangeException>(
                () => new Account().Deposit(-1)
            );
        }

        [Test]
        public void Withdraw_Test()
        {
            //TODO: Withdraw method decreases Balance with given amount
            Account account = new Account("", 1);
            decimal before = account.Balance;
            int amount = 1;
            account.Withdraw(amount);
            Assert.AreEqual(before - amount, account.Balance);
        }

        [Test]
        public void WithDrawExceptionOutOfRange_Test()
        {
            //TODO: negative amount parameter passed to Withdraw method throws ArgumentOutOfRangeException exception
            Assert.Throws<ArgumentOutOfRangeException>(
                () => new Account().Withdraw(-1)
            );
        }

        [Test]
        public void WithDrawExceptionInvalidOperation_Test()
        {
            //TODO: amount parameter greater than Balance passed to Withdraw method throws InvalidOperationException exception           
            var account = new Account();
            Assert.Throws<ArgumentOutOfRangeException>(
                () => account.Withdraw(account.Balance+1)
            );
        }
    }
}