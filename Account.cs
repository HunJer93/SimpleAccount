//Jeremy Hunton
//6/4/2021
//CPT 244 (Data Structures): Assignment 0-Simple Class
//The purpose of this program is to create a simple accounting system to manage a bank account. The Account class
//is responsible for handling incoming/outgoing Transactions, the total of the account balance, and the total interest of the account.  

using System;
using System.Collections.Generic;
using System.Text;

namespace HuntonAssignment0
{

    class Account
    {
        //declare class constants 
        private const double InterestRate = 0.0005;
        private const int MaxTransactionSize = 50;
       

        //declare class variables
        private double startingAmount = 0.0;
        private double currentBalance = 0.0;
        private char[] transactionTypes = { 'D', 'W', 'I', 'P' };
        private bool withdrawStatus = false;
        private List<Transaction> transactionList = new List<Transaction>(MaxTransactionSize);


        //Account constructor 
        public Account(double startingAmount)
        {
            //set the input starting amount
            this.startingAmount = startingAmount;

            //let the starting amount represent the current balance
            currentBalance = startingAmount;

            //create a transaction for the starting amount and add it to the transactionList
            Transaction startingTransaction = new Transaction(startingAmount, transactionTypes[3]);
            transactionList.Add(startingTransaction);
        }//end Account constructor

        //start of setter methods

        //Deposit void method adds an entry 
        public void setDeposit(double depositAmt)
        {
            //create a new transaction object and pass the deposit amount
            Transaction deposit = new Transaction(depositAmt, transactionTypes[0]);

            //add the deposit to the transactionList
            transactionList.Add(deposit);

            //add the deposit to the currentBalance
            currentBalance += deposit.getTransactionAmount();
        }//end Deposit

        //showTransactions method displays the transactions listed (including the starting and current balance)
        public void showTransactions()
        {
            //display the transactions            
            Console.WriteLine("~~~~ ~~~~ ~~~~ ~~~~ ~~~~ ~~~~ ~~~~ ");
            Console.WriteLine("Transaction History\n");

            //foreach loop cycling the Transactions objects in the transactionList
            foreach (Transaction t in transactionList)
            {
                //format each transaction 
                decimal roundedT = (decimal)t.getTransactionAmount();
                roundedT = decimal.Round(roundedT, 2);
                Console.WriteLine("Transaction Type: {0} Transaction Amount: ${1}", t.getTransactionType(), roundedT);
            }//end cycling the transactionList

            //format the starting amount and currentBalance
            decimal fStartingAmt = (decimal)startingAmount;
            decimal fCurrentBalance = (decimal)currentBalance;
            fStartingAmt = decimal.Round(fStartingAmt, 2);
            fCurrentBalance = decimal.Round(fCurrentBalance, 2);
            Console.WriteLine("~~~~ ~~~~ ~~~~ ~~~~ ~~~~ ~~~~ ~~~~ ");
            Console.WriteLine("\nStarting Balance: ${0}", fStartingAmt);
            Console.WriteLine("Current Balance: ${0}\n", fCurrentBalance);
            Console.WriteLine("~~~~ ~~~~ ~~~~ ~~~~ ~~~~ ~~~~ ~~~~ ");


        }//end showTransactions 

        //setWithdraw takes the user input for validateWithdraw to validate it
        public void setWithdraw(double withdrawAmt)
        {
            //selection structure making sure the withdrawl doesn't overdraft the currentBalance
            if (currentBalance - withdrawAmt > 0)
            {
                //set the withdrawStatus as true
                withdrawStatus = true;

                //subtract the withdrawl from the currentBalance
                currentBalance -= withdrawAmt;

                //set the withdrawAmt to a negative number
                withdrawAmt = withdrawAmt * -1;

                //create a new transaction object and pass the withdrawAmt
                Transaction withdraw = new Transaction(withdrawAmt, transactionTypes[1]);

                //add the withdraw Transaction object to the transactionList
                transactionList.Add(withdraw);
            }//end withdraw amount accepted becauase it doesn't overdraft
            else
            {
                withdrawStatus = false;
            }//end else the withdrawl overdrafts, so the transaction isn't created
        }//end setWithdraw

        //start of getters

        //validateWithdraw method creates a negative transaction and subtracts it from the currentBalance IF the account balance isn't overdrawn by the transaction
        public bool getWithdrawStatus()
        {           
            return withdrawStatus;
        }//end validateWithdraw method

        //addInterest creates a Transaction in the transactionList of the currentBalance multiplied by the InterestRate, and adds the amount to the currentBalance. Returns the interest deposit.
        public double addInterest()
        {
            //create the interest rate object set to the amount of the currentBalance*InterestRate const
            Transaction interestDeposit = new Transaction((currentBalance * InterestRate), transactionTypes[2]);

            //add the interestDeposit to the transactionsList
            transactionList.Add(interestDeposit);

            //add the interestDeposit amount to the current balance
            currentBalance += interestDeposit.getTransactionAmount();

            return interestDeposit.getTransactionAmount();
        }//end addInterest method

        //getBalance returns the current balance
        public double getBalance()
        {
            return currentBalance;
        }//end getBalance
    }//end of Account class
}
