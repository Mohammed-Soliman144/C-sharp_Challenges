using System;
using System.IO;
using System.Collections.Generic;
using System.Security.Cryptography;



namespace BankAccount
{
    class Program
    {
        public static void Main(string[] args)
        {
            BankAccountSystem bankQNB = new BankAccountSystem(100000, "");
            bankQNB.Deposit(11000);
            Console.WriteLine(bankQNB.ShowBalance());
            bankQNB.Withdraw(85000);
            Console.WriteLine(bankQNB.ShowBalance());
        }
    }

    class BankAccountSystem
    {
        private decimal bankBalance = 0;
        private string bankAccountNum;

        public BankAccountSystem(decimal initBal, string initAccNum)
        {
            this.bankBalance = initBal;
            // Guid.NewGuid().ToString() C# == crypto.randomUUID() in js
            this.bankAccountNum = String.IsNullOrEmpty(initAccNum) ? Guid.NewGuid().ToString() : initAccNum;
        }

        public void Deposit(decimal amount)
        {
            this.bankBalance += amount > 0 ? amount : 0;
        }

        public void Withdraw(decimal amount)
        {
            this.bankBalance -= amount <= this.bankBalance ? amount : 0;
        }

        public string ShowBalance()
        {
            return $"Your Current Balance = {this.bankBalance} - for account number ${this.bankAccountNum}";
        }
    }
}