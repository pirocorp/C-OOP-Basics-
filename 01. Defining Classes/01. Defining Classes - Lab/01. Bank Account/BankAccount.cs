public class BankAccount
{
    private int id;
    private decimal balance;

    public int Id
    {
        get { return this.id; } //get => this.id;
        set { this.id = value; }
    }

    public decimal Balance
    {
        get { return this.balance; } //get => this.balance;
        set { this.balance = value; }
    }

    public void Deposit(decimal amount)
    {
        this.Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        this.Balance -= amount;
    }

    public override string ToString()
    {
        return $"Account ID{this.Id}, balance {this.Balance:F2}";
    }
}

