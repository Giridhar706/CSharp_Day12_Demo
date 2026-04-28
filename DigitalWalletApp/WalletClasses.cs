using System;
using System.Collections.Generic;

namespace DigitalWalletApp
{

    // OCP + DIP → PAYMENT ABSTRACTION
    public interface IPayment
    {
        void Pay(double amount);
    }

    // UPI Payment
    public class UPIPayment : IPayment
    {
        public void Pay(double amount)
        {
            Console.WriteLine($"Paid {amount} using UPI");
        }
    }

    // Card Payment
    public class CardPayment : IPayment
    {
        public void Pay(double amount)
        {
            Console.WriteLine($"Paid {amount} using Card");
        }
    }
    // Net Banking Payment
    public class NetBankingPayment : IPayment
    {
        public void Pay(double amount)
        {
            Console.WriteLine($"Paid {amount} using Net Banking");
        }
    }

    // FACTORY (OCP IMPLEMENTED)
    public class PaymentFactory
    {
        public static IPayment GetPayment(int choice)
        {
            switch (choice)
            {
                case 1: return new UPIPayment();
                case 2: return new CardPayment();
                case 3: return new NetBankingPayment();
                default: return null;
            }
        }
    }

    // ISP → NOTIFICATION
    public interface INotification
    {
        void Send(string message);
    }

    public class EmailNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine("Notification: " + message);
        }
    }

    // SRP → WALLET
    public class Wallet
    {
        public double Balance { get; private set; }

        public void AddMoney(double amount)
        {
            Balance += amount;
            Console.WriteLine($"Money added: {amount}. Current Balance: {Balance}");
        }

        public void Deduct(double amount)
        {
            Balance -= amount;
        }
    }

    // TRANSACTION CLASS
    public class Transaction
    {
        public string Type { get; set; }
        public double Amount { get; set; }

        public void Display()
        {
            Console.WriteLine($"{Type} : {Amount}");
        }
    }

    // DIP → PAYMENT SERVICE
    public class PaymentService
    {
        private readonly IPayment payment;
        private readonly INotification notification;
        private readonly Wallet wallet;
        private readonly List<Transaction> transactions;

        public PaymentService(IPayment payment, INotification notification, Wallet wallet, List<Transaction> transactions)
        {
            this.payment = payment;
            this.notification = notification;
            this.wallet = wallet;
            this.transactions = transactions;
        }

        public void MakePayment(double amount)
        {
            if (wallet.Balance < amount)
            {
                Console.WriteLine("Insufficient Balance!");
                return;
            }

            payment.Pay(amount);
            wallet.Deduct(amount);

            transactions.Add(new Transaction
            {
                Type = "Payment",
                Amount = amount
            });

            notification.Send("Payment Successful!");
        }
    }
}
