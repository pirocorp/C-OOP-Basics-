using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.InteropServices;

public class Lab
{
    public static void Main(string[] args)
    {
        var accounts = new Dictionary<int, BankAccount>();

        var inputLine = string.Empty;

        while ((inputLine = Console.ReadLine()) != "End")
        {
            var tokens = inputLine.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);

            var command = tokens[0];

            switch (command)
            {
                case "Create":
                    Create(tokens, accounts);
                    break;
                case "Deposit":
                    Deposit(tokens, accounts);
                    break;
                case "Withdraw":
                    Withdraw(tokens, accounts);
                    break;
                case "Print":
                    Print(tokens, accounts);
                    break;
            }
        }
    }

    private static void Print(string[] args, Dictionary<int, BankAccount> accounts)
    {
        var id = int.Parse(args[1]);

        if (!accounts.ContainsKey(id))
        {
            Console.WriteLine($"Account does not exist");
        }
        else
        {
            Console.WriteLine(accounts[id].ToString());
        }
    }

    private static void Withdraw(string[] args, Dictionary<int, BankAccount> accounts)
    {
        var id = int.Parse(args[1]);

        if (!accounts.ContainsKey(id))
        {
            Console.WriteLine($"Account does not exist");
        }
        else
        {
            var amount = decimal.Parse(args[2]);
            var balance = accounts[id].Balance;

            if (amount > balance)
            {
                Console.WriteLine($"Insufficient balance");
            }
            else
            {
                accounts[id].Withdraw(amount);
            }
        }
    }

    private static void Deposit(string[] args, Dictionary<int, BankAccount> accounts)
    {
        var id = int.Parse(args[1]);

        if (!accounts.ContainsKey(id))
        {
            Console.WriteLine($"Account does not exist");
        }
        else
        {
            var amount = decimal.Parse(args[2]);
            accounts[id].Deposit(amount);
        }
    }

    private static void Create(string[] args, Dictionary<int, BankAccount> accounts)
    {
        var id = int.Parse(args[1]);

        if (accounts.ContainsKey(id))
        {
            Console.WriteLine($"Account already exists");
        }
        else
        {
            var currentAccount = new BankAccount();
            currentAccount.Id = id;
            accounts.Add(id, currentAccount);
        }
    }
}

