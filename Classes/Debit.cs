using System;

namespace CreditCard_PaymentSystem.Classes
{
    public class Debit : Card
    {

        private float balance_Initial_Debit = 6000;

        public float Balance_Initial_Debit { get; set; }


        private float current_Balance;

        public float Current_Balance { get; set; }


        public string Pay(float purchase, float balance_Initial_Debit, float current_Balance)
        {

            if (purchase < current_Balance)
            {

                current_Balance = balance_Initial_Debit - purchase;

                balance_Initial_Debit = current_Balance;

                return "PAYMENT SUCCESSFULLY MADE. YOUR RECEIPT CAN BE PRINTED OR SENT TO YOUR EMAIL";

            }

            else
            {

                Console.ResetColor();

                return "PAYMENT DENIED DUE TO INSUFFICIENT BALANCE";
            }

        }
    }
}