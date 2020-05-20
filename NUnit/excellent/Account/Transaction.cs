namespace Account
{
    public class Transaction
    {
        public decimal Amount { get; }
        public Transaction(decimal amount)
        {
            this.Amount = amount;
        }
    }
}
