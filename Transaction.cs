//Jeremy Hunton
//6/4/2021
//CPT 244 (Data Structures): Assignment 0-Simple Class
//The purpose of this program is to create a simple accounting system to manage a bank account. The Transaction class
//is responsible for creating individual transactions that keeps track of the type of transaction (positive vs. negative) and the amount in the transaction (in $). 

using System;
using System.Collections.Generic;
using System.Text;

namespace HuntonAssignment0
{
    class Transaction
    {
        //declare class variables 
        private double transactionAmount = 0.0;
        private String transactionType = "";

        //declare constructor
        public Transaction(double transactionAmount, char tranClassChar)
        {
            this.transactionAmount = transactionAmount;

            //check if the transaction is positive or negative 
            if (tranClassChar == 'D')
            {
                transactionType = "Deposit";
            }//end transaction type is a deposit
            else if(tranClassChar == 'W')
            {
                transactionType = "Withdrawl";
            }//end else transaction type is a withdrawl
            else if(tranClassChar == 'I')
            {
                transactionType = "Account Interest";
            }//end the transaction is interest
            else
            {
                transactionType = "Initial Deposit";
            }//end else the transaction is the inital transaction
        }//end Transaction constructor


        //start of getters

        public double getTransactionAmount()
        {
            return transactionAmount;
        }//end getTransactionAmount

        public String getTransactionType()
        {
            return transactionType;
        }//end getTransactionType

    }//end of Transaction
}
