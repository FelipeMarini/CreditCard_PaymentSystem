using System;

namespace CreditCard_PaymentSystem.Classes
{
    public abstract class Card : Payment
    {

        public string number;
        public string flag;
        public string cardHolder;
        public string cvv;

        Debit deb = new Debit();

        Credit cred = new Credit();



        public void SaveCard(string number, string flag, string cvv)
        {

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Which flag is your card? [v = Visa] [m = MasterCard]");
            deb.flag = Console.ReadLine().ToLower();

            Console.WriteLine();
            Console.WriteLine("Please type your card number: ");
            deb.number = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Please type the card holder´s name: ");
            deb.cardHolder = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Please type your verification code (cvv):");
            deb.cvv = Console.ReadLine();
        }


    }
}