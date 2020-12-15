using System;

namespace CreditCard_PaymentSystem.Classes
{
    public class Credit : Card
    {
        private float limit_Initial_Credit = 5000;

        public float Limit_Initial_Credit { get; set; }

        private float current_Limit;

        public float Current_Limit { get; set; }

        public float i;  // interest rate per month
        public int k;  // number of parcels if paid with credit card
        public double parcel;  // value of each parcel (with interest) due to pay each month


        public string PayCredit(float purchase, float limit_Initial_Credit, float current_Limit, float i, double parcel, int k)
        {




            if (k >= 0 && k <= 6 && purchase < limit_Initial_Credit)
            {

                i = 0.05f;

                double c = Math.Pow(1.05, k);

                double CF = 0.05 / 1 - (1 / c);

                parcel = purchase * CF;

                return $"PAYMENT SUCCESSFULLY MADE.The value of each parcel per month ({k} parcels) due to pay with 5% interest will be ${parcel.ToString("F")}";
            }

            else if (k >= 7 && k <= 12 && purchase < limit_Initial_Credit)
            {

                i = 0.08f;

                double c = Math.Pow(1.08, k);

                double CF = 0.08 / 1 - (1 / c);

                parcel = purchase * CF;

                return $"PAYMENT SUCCESSFULLY MADE.The value of each parcel per month ({k} parcels) due to pay with 8% interest will be ${parcel.ToString("F")}";
            }

            else { return "Number of parcels cannot be greater than 12 or purchase is above credit card limit"; }


        }
    }
}