using System;

namespace CreditCard_PaymentSystem.Classes
{
    public class PaymentSlip : Payment
    {
        private int barCode;

        public int BarCode
        {

            get { return barCode; }
        }


        public int Register()
        {

            Random randomic = new Random();
            return this.barCode = randomic.Next(0, 999999999);
        }


        public void GenerateSlip(double purchase)
        {

            double total = purchase * 0.88f;
            Console.WriteLine($"Value of purchase without Payment Slip discount is: ${purchase.ToString("F")}");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Value of your Payment Slip (12% discount) is: ${total.ToString("F")}");
            Console.WriteLine();
            Console.WriteLine($"Date: {this.Date}");
            Console.WriteLine();
            Console.WriteLine($"Payment Deadline: {this.Date.AddDays(10)}");
            Console.WriteLine();
            Console.WriteLine($"Bar Code: {this.BarCode}");
            Console.ResetColor();

        }




    }
}