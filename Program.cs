using System;
using CreditCard_PaymentSystem.Classes;

namespace CreditCard_PaymentSystem
{
    class Program
    {

        static void Main(string[] args)
        {

            float purchase;
            int choice;
            int choice2;
            string answer = "";
            int answer2;



            PaymentSlip slip = new PaymentSlip();

            Debit deb = new Debit();

            Credit cred = new Credit();


            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("----Welcome to our Payment Paypal System----");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Please type the value of your purchase: $ ");
            purchase = float.Parse(Console.ReadLine());
            Console.WriteLine();


            do
            {

                Console.Clear();
                Console.WriteLine("-----MAIN MENU-----");
                Console.WriteLine();
                Console.WriteLine("[1] Payment slip");
                Console.WriteLine();
                Console.WriteLine("[2] Pay with card");
                Console.WriteLine();
                Console.WriteLine("[3] Show registered cards");
                Console.WriteLine();
                Console.WriteLine("[4] Cancel payment and exit main menu");
                Console.WriteLine();
                Console.Write("Please select an option above: ");
                choice = int.Parse(Console.ReadLine());


                switch (choice)

                {

                    case 1:

                        Console.Clear();
                        Console.WriteLine();
                        slip.Register();
                        Console.WriteLine();

                        slip.Date = DateTime.Now;

                        slip.GenerateSlip(purchase);
                        Console.WriteLine();

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Print in PDF or use barcode/QRcode to pay your slip");
                        Console.ResetColor();
                        Console.WriteLine();

                        Console.WriteLine("Would you like to return to the main menu? [yes = y] [no = n]");
                        answer = Console.ReadLine().ToLower();

                        break;


                    case 2:

                        do
                        {

                            Console.Clear();
                            Console.WriteLine();
                            Console.WriteLine("[5] Pay with Debit Card");
                            Console.WriteLine();
                            Console.WriteLine("[6] Pay with Credit Card");
                            Console.WriteLine();
                            Console.WriteLine("[7] Return to Main Menu");
                            Console.WriteLine();

                            Console.WriteLine("Please choose an option above:");
                            choice2 = int.Parse(Console.ReadLine());


                            switch (choice2)

                            {

                                case 5:

                                    bool confirm;

                                    do
                                    {

                                        deb.SaveCard(deb.number, deb.flag, deb.cvv);

                                        if (deb.number.Length == 16 && (deb.flag == "v" || deb.flag == "m") && deb.cvv.Length == 3)
                                        {

                                            Console.WriteLine();
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("Card successfully registered");
                                            Console.ResetColor();
                                            confirm = true;
                                        }

                                        else
                                        {

                                            Console.WriteLine();
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Incorrect card information. Please try again");
                                            Console.ResetColor();
                                            confirm = false;
                                        }

                                    } while (confirm == false);



                                    do
                                    {

                                        Console.WriteLine();
                                        Console.WriteLine();
                                        Console.WriteLine($"Confirm your purchase of ${purchase}? [1 = yes] [2 = no]\n");
                                        answer2 = int.Parse(Console.ReadLine());

                                    } while (answer2 != 1 && answer2 != 2);


                                    if (answer2 == 1)
                                    {

                                        Console.WriteLine(deb.PayDebit(purchase, deb.Balance_Initial_Debit, deb.Current_Balance));

                                    }

                                    else if (answer2 == 2)
                                    {

                                        answer = "y";

                                    }

                                    break;


                                case 6:

                                    bool confirm2;

                                    do
                                    {

                                        cred.SaveCard(cred.number, cred.flag, cred.cvv);


                                        if (cred.number.Length == 16 && (cred.flag == "v" || cred.flag == "m") && cred.cvv.Length == 3)
                                        {

                                            Console.WriteLine();
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("Card successfully registered");
                                            Console.ResetColor();

                                            confirm2 = true;

                                        }

                                        else
                                        {

                                            Console.WriteLine();
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Incorrect card information. Please try again");
                                            Console.ResetColor();

                                            confirm2 = false;

                                        }

                                    } while (confirm2 == false);


                                    do
                                    {

                                        Console.WriteLine();
                                        Console.WriteLine();
                                        Console.WriteLine($"Confirm your purchase of ${purchase}? [1 = yes] [2 = no]\n");
                                        answer2 = int.Parse(Console.ReadLine());

                                    } while (answer2 != 1 && answer2 != 2);


                                    if (answer2 == 1)
                                    {

                                        Console.WriteLine();
                                        Console.WriteLine("In how many parcels would you like to make your credit card purchase? (for no parcel purchase please type 0):");
                                        Console.WriteLine();
                                        Console.WriteLine("2x until 6x --> 5% of total interest rate");
                                        Console.WriteLine();
                                        Console.WriteLine("7x until 12x --> 8% of total interest rate");
                                        Console.WriteLine();
                                        Console.WriteLine("(max number of parcels : 12)");
                                        int k = int.Parse(Console.ReadLine());

                                        Console.WriteLine();
                                        Console.WriteLine(cred.PayCredit(k, purchase, cred.Limit_Initial_Credit, cred.Current_Limit, cred.i, (int)cred.parcel));

                                    }

                                    else if (answer2 == 2) { answer = "y"; }

                                    break;


                                case 7:

                                    answer = "y";

                                    break;
                            }


                        } while (choice2 != 7);


                        break;


                    case 3:

                        Console.WriteLine();
                        Console.WriteLine("Your registered Debit Card");
                        Console.WriteLine();
                        Console.WriteLine($"{deb.cardHolder}");
                        Console.WriteLine();
                        Console.WriteLine($"{deb.number}");
                        Console.WriteLine();
                        Console.WriteLine($"[{deb.flag.ToUpper()}]    (M = MasterCard) (V = Visa)");
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("Your registered Credit Card");
                        Console.WriteLine();
                        Console.WriteLine($"{cred.cardHolder}");
                        Console.WriteLine();
                        Console.WriteLine($"{cred.number}");
                        Console.WriteLine();
                        Console.WriteLine($"[{cred.flag.ToUpper()}]    (M = MasterCard) (V = Visa)");

                        Console.WriteLine("Would you like to return to the main menu? [yes = y] [no = n]");
                        answer = Console.ReadLine();

                        break;


                    case 4:

                        Console.WriteLine();
                        deb.CancelPayment();
                        break;

                }



            } while (answer == "y" || answer == "yes");



        }
    }
}
