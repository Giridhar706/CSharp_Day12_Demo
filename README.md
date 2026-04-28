# Digital Wallet System (SOLID Principles in C#)

## 📌 Project Overview
This project is a console-based Digital Wallet system developed in C#. It demonstrates the application of SOLID principles to build a clean, maintainable, and extensible system.

Users can:
- Add money to wallet
- Make payments (UPI, Card, Net Banking)
- Receive notifications
- View transaction history

---

# 📁 Project Structure

- Program.cs → Handles user interaction and menu
- WalletClasses.cs → Contains all business logic, interfaces, and classes

---

# 🧠 SOLID Principles Implemented

## 1. Single Responsibility Principle (SRP)
- Wallet → Manages balance
- PaymentService → Handles payments
- Transaction → Stores transaction data

## 2. Open/Closed Principle (OCP)
- IPayment interface allows adding new payment methods without modifying existing code

## 3. Liskov Substitution Principle (LSP)
- All payment classes (UPI, Card, NetBanking) can be used interchangeably

## 4. Interface Segregation Principle (ISP)
- Separate interfaces: IPayment and INotification

## 5. Dependency Inversion Principle (DIP)
- PaymentService depends on abstractions (IPayment, INotification)

---

# ▶ How to Run

1. Open project in Visual Studio
2. Run the application
3. Choose options from menu:
   - Add Money
   - Make Payment
   - View Transactions
4. Enter required inputs

---

# ✅ Sample Output

==== DIGITAL WALLET SYSTEM ====
1. Add Money
2. Make Payment
3. View Transactions
4. Exit
   
Enter choice: 1
Enter amount: 1000
Money added: 1000. Current Balance: 1000

Enter choice: 2
Select Payment Method:
1. UPI
2. Card
3. Net Banking
   
Enter Choice: 1
Enter amount: 200
Paid 200 using UPI
Notification: Payment Successful!

Enter choice: 3
Transaction History:
Added : 1000
Payment : 200

---

# 🎯 Features

- Menu-driven program
- Multiple payment methods
- Transaction tracking
- Notification system
- Clean and modular design

---

# 🛠 Technologies Used

- C#
- .NET Console Application
- Visual Studio

---

# 📌 Conclusion

This project demonstrates how SOLID principles help in building scalable and maintainable applications. The system is loosely coupled, easy to extend, and follows best coding practices.
