using System;

public class SmartMeterAccount
{
    private int balance;

    public void Recharge(int amount)
    {
        balance += amount;
        Console.WriteLine("Balance after recharge: " + balance);
    }

    public void Consume(int amount)
    {
        if (amount <= balance)
        {
            balance -= amount;
            Console.WriteLine("Balance after consumption: " + balance);
        }
        else
        {
            Console.WriteLine("Insufficient balance");
        }
    }
}

class Program_Q2
{
    static void Main()
    {
        SmartMeterAccount account = new SmartMeterAccount();

        Console.Write("Enter recharge amount: ");
        int recharge = Convert.ToInt32(Console.ReadLine());
        account.Recharge(recharge);

        Console.Write("Enter first consumption: ");
        int consume1 = Convert.ToInt32(Console.ReadLine());
        account.Consume(consume1);

        Console.Write("Enter second consumption: ");
        int consume2 = Convert.ToInt32(Console.ReadLine());
        account.Consume(consume2);
    }
}
