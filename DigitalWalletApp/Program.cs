using System;
using System.Collections.Generic;

namespace DigitalWalletApp
{
    class Program
    {
        static void Main()
        {
            Wallet wallet = new Wallet();
            List<Transaction> transactions = new List<Transaction>();
            INotification notification = new EmailNotification();

            while (true)
            {
                Console.WriteLine("\n==== DIGITAL WALLET SYSTEM ====");
                Console.WriteLine("1. Add Money");
                Console.WriteLine("2. Make Payment");
                Console.WriteLine("3. View Transactions");
                Console.WriteLine("4. Exit");
                Console.Write("\nEnter choice: ");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter amount: ");
                        double addAmount = double.Parse(Console.ReadLine());

                        wallet.AddMoney(addAmount);
                        transactions.Add(new Transaction { Type = "Added", Amount = addAmount });
                        break;

                    case 2:
                        Console.WriteLine("Select Payment Method:");
                        Console.WriteLine("1. UPI");
                        Console.WriteLine("2. Card");
                        Console.WriteLine("3. Net Banking");
                        Console.Write("\nEnter choice: ");

                        int method = int.Parse(Console.ReadLine());

                        IPayment payment = PaymentFactory.GetPayment(method);

                        if (payment == null)
                        {
                            Console.WriteLine("Invalid Payment Method!");
                            break;
                        }

                        Console.Write("Enter amount: ");
                        double payAmount = double.Parse(Console.ReadLine());

                        PaymentService service = new PaymentService(payment, notification, wallet, transactions);
                        service.MakePayment(payAmount);
                        break;

                    case 3:
                        Console.WriteLine("\nTransaction History:");
                        foreach (var t in transactions)
                            t.Display();
                        break;

                    case 4:
                        Console.WriteLine("Thank you for using Digital Wallet!");
                        return;

                    default:
                        Console.WriteLine("Invalid Choice!");
                        break;
                }
            }
        }
    }
}
