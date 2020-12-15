using System;

namespace CreditCard_PaymentSystem.Classes
{
    public abstract class Payment
    {
        private DateTime date;

        public DateTime Date { get; set; }

        public string CancelPayment()
        {

            Console.WriteLine();
            Console.WriteLine("Would you really like to cancel your purchase? [yes = 1] [no = 2]");
            int choice3 = int.Parse(Console.ReadLine().ToLower());

            if (choice3 == 1)
            {

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                return "Thank you for using our System";
            }

            else if (choice3 == 2)
            {

                return "y";

            }

            else { return "Invalid Option"; }
        }






    }
}