//Jeremy Hunton
//6/4/2021
//CPT 244 (Data Structures): Assignment 0-Simple Class
//The purpose of this program is to create a simple accounting system to manage a bank account.The MainClass
//is reponsible for displaying menus and validating user inputs for the menus. 

using System;
using System.Collections.Generic;

namespace HuntonAssignment0
{
    class MainClass
    {
        //declare class constants 
        private static char[] MenuOptionChars= { 'D', 'W', 'C', 'S', 'T', 'Q' };
        private static string[] MenuOptions = { "Deposit", "Withdraw", "Calcuate Interest", "Show Balance", "Display Transactions", "Quit" };

        static void Main(string[] args)
        {
            //declare class variables
            char menuSelection = ' ';
            //display welcome banner
            displayWelcomeBanner();

            //request the starting account balance and create an Account obj with the starting balance
            Account account = new Account(setStartingBalance());

            //display the main menu and validate the input
           menuSelection = validateMenuSelection();

            //while loop checking that the quit option hasn't been selected
            while(menuSelection != 'Q')
            {
                //selection structure for menu selections
                if(menuSelection == 'D')
                {
                    //call the processDeposit to request user input and assign it to the account
                    account.setDeposit(processDeposit());

                }//end menu selection D for deposit

                else if(menuSelection == 'W')
                {
                    //call processWithdraw and pass the input to the account object
                    account.setWithdraw(processWithdraw());

                    //selection structure checking if the withdrawl was successful
                    if(account.getWithdrawStatus() == true)
                    {
                        displayWithdrawSuccess();
                    }//end withdraw accepted and message displayed
                    else
                    {
                        displayWithdrawFailure();
                    }//else the withdrawl failed and the error displays
                }//end menu selection W for withdrawl

                else if(menuSelection == 'C')
                {
                    //processes the interest in the account and display it to the user
                    displayCalcInterest(account.addInterest());
                }//end menu selection C for calculate interest

                else if(menuSelection == 'S')
                {
                    //get the balance from the account and display it
                    displayBalance(account.getBalance());
                }//end menuSelection S for show balance
                else
                {
                    //call the showTransactions method from account
                    account.showTransactions();
                }//end menu selection T for show transactions

                //redisplay the main menu
              menuSelection= validateMenuSelection();
            }//end user quits the program

            //display farewell message
            displayFarewellMessage();
        }//end of main method

        //start of void methods 

        //the displayWelcomeBanner displays the welcome banner
        public static void displayWelcomeBanner()
        {
            Console.WriteLine("Welcome to bank account manager. Please follow the menus");
            Console.WriteLine("and prompts below.\n");
        }//end displayWelcomeBanner

        //the displayMainMenu displays the main menu
        public static void displayMainMenu()
        {
            Console.WriteLine("~~~~ ~~~~ ~~~~ ~~~~ ~~~~ ~~~~ ~~~~ ~~~~ \n");

            for(int i=0; i < MenuOptionChars.Length; i++)
            {
                Console.WriteLine("Press {0} for {1}", MenuOptionChars[i], MenuOptions[i]);
            }//end for loop cycling menu options
        }//end displayMainMenu

        //displayFarewellMessage displays the farewell message before the program closes
        public static void displayFarewellMessage()
        {
            Console.WriteLine("\nThank you for the using the account manager.");
            Console.WriteLine("We hope you have a great day!");
        }//end displayFarewellMessage

        //displayCalcInterest displays the calculated interest
        public static void displayCalcInterest(double interestAmt)
        {
            //format the interst to the proper decimal
            decimal fInterest = (decimal)interestAmt;
            fInterest = decimal.Round(fInterest, 2);
            Console.WriteLine("\nThe interest ${0} has been processed and added to the account.", fInterest);
            Console.WriteLine("Returning to main menu.\n");
        }//end displayCalcInterest

        //displayBalance displays the account balance
        public static void displayBalance(double accountBalance)
        {
            //format the account balance to the proper decimal
            decimal fBalance = (decimal)accountBalance;
            fBalance = decimal.Round(fBalance, 2);
            Console.WriteLine("\nThe current account balance is ${0}.", fBalance);
            Console.WriteLine("Returning to main menu.\n");
        }//end displayBalance

        //displayWithdrawSuccess displays that the withdrawl processes was successful
        public static void displayWithdrawSuccess()
        {
            Console.WriteLine("\nThe transaction has been processed and withdrawn from your account.");
            Console.WriteLine("Returning to the main menu.\n");
        }//end displayWithdrawSuccess

        //displayWithdrawError displays that the withdrawl process was unsuccessful
        public static void displayWithdrawFailure()
        {
            Console.WriteLine("\nError! The amount entered would overdraft your account. To prevent this,");
            Console.WriteLine("we have declined this transaction. Please check your account balance.");
            Console.WriteLine("Returning to the main menu.\n");
        }//end displayWithdrawSuccess

        //end of void method
        //start of vr methods

        //validateMenuSelection calls the display menu method, takes the user input and validates the request
        public static char validateMenuSelection()
        {
            //declare local variables
            char menuSelection;

            //display the main menu
            displayMainMenu();

            //request input
            Console.WriteLine("Please enter your menu selection:");
            menuSelection = Console.ReadLine()[0];
            //make the menuSelection an uppercase char
            menuSelection = Char.ToUpper(menuSelection);

            //validate the input
            while(menuSelection != 'D' && menuSelection != 'W' && menuSelection != 'C' && menuSelection != 'S' && menuSelection != 'T' && menuSelection != 'Q')
            {
                //display error
                Console.WriteLine("Error! This is not a valid input. Please enter a valid input.");
                Console.WriteLine("Returning to main menu...\n");

                displayMainMenu();

                //request input
                Console.WriteLine("Please enter your menu selection:");
                menuSelection = Console.ReadLine()[0];
                //make the menuSelection an uppercase char
              menuSelection = Char.ToUpper(menuSelection);
            }//end validation loop

            //return the menu selection
            return menuSelection;
        }//end validateMenuSelection

        //processDeposit takes a user input and validates the input as a valid deposit amount
        public static double processDeposit()
        {
            //declare local variables
            String input;
            double depositAmt;

            //display the input request and parse the request
            Console.WriteLine("Please enter the deposit amount:");
            input = Console.ReadLine();
            depositAmt = Double.Parse(input); 

            //validate the input 
            while(depositAmt <= 0.0)
            {
                Console.WriteLine("\nError! This is not a valid input. Please enter a deposit amount\n");

                //display the input request and parse the request
                Console.WriteLine("Please enter the deposit amount:");
                input = Console.ReadLine();
                depositAmt = Double.Parse(input);
            }//end input validation

            //display confirmation
            //format the deposit amount 
            decimal fDeposit = (decimal)depositAmt;
            fDeposit = decimal.Round(fDeposit,2);
            Console.WriteLine("\nThe amount ${0} has been processed and added to your account.", fDeposit);
            Console.WriteLine("Returning to main menu\n");
            //return the deposit amount
            return depositAmt;
        }//end processDeposit

        //processWithdraw takes a user input and validates the input as a valid withdraw amount
        public static double processWithdraw()
        {
            //declare local variables
            String input;
            double withdrawAmt;

            //display the input request and parse the input
            Console.WriteLine("Please enter the withdrawl amount:");
            input = Console.ReadLine();
            withdrawAmt = Double.Parse(input);

            //validate the input
            while(withdrawAmt < 0.0)
            {
                Console.WriteLine("\nError! This is not a valid input. Please enter a valid withdrawl amount\n");

                //display the input request and parse the input
                Console.WriteLine("Please enter the withdrawl amount:");
                input = Console.ReadLine();
                withdrawAmt = Double.Parse(input);
            }//end input validation

            //return the withdraw amount
            return withdrawAmt;
        }//end processWithdraw

        //setStartingBalance requests the user input for the starting amount of the account and validates it
        public static double setStartingBalance()
        {
            //declare local variables
            String input;
            double startingBalance;

            Console.WriteLine("Before getting started, please enter your initial account balance:");
            input = Console.ReadLine();
            startingBalance = Double.Parse(input);

            //validate the input
            while(startingBalance < 0)
            {
                Console.WriteLine("\nError! This is not a valid input. Please enter a valid amount\n");

                Console.WriteLine("Please enter your initial account balance:");
                input = Console.ReadLine();
                startingBalance = Double.Parse(input);
            }//end validation loop

            //confirm the balance
            //round the starting balance to display proper decimals
            decimal fBalance = (decimal)startingBalance;
            fBalance = decimal.Round(fBalance, 2);
            Console.WriteLine("Your starting balance is ${0}\n", fBalance);

            return startingBalance;

        }//end setStartingBalance
    }//end of main class
}//end of namespace
