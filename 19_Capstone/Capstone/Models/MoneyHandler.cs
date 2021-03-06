﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Models
{
    public class MoneyHandler
    {
        public decimal CurrentBalance { get; protected set; } = 0.00M;

        //methods
        public decimal FeedMoney(int dollarAmount)
        {
            CurrentBalance += dollarAmount;            
            LogHistory("FEED MONEY", dollarAmount, CurrentBalance);
            return CurrentBalance;
        }


        public void LogHistory(string taskCompleted, decimal value1, decimal value2)      //pass in name of task completed (concat. into log)
        {
            using (StreamWriter sw = new StreamWriter((@"..\..\..\..\Log.txt"), true))        //same directory as solution 
            {
                sw.WriteLine($">>{DateTime.Now} {taskCompleted}  {value1:C} {value2:C}");

             }
        }

        
        public string GetChange()
        {
            int quarters = 0;
            int dimes = 0;
            int nickels = 0;
            decimal startingBalance = CurrentBalance;
            decimal remainingBalance = CurrentBalance;

            while (remainingBalance > 0)
            {
                
                quarters = (int)(CurrentBalance / 0.25M);
                remainingBalance = CurrentBalance - (quarters * 0.25M);

                dimes = (int)(remainingBalance / 0.10M);
                remainingBalance = remainingBalance - (dimes * 0.10M);

                nickels = (int)(remainingBalance / 0.05M);
                remainingBalance = remainingBalance - (nickels * 0.05M);
            }
            CurrentBalance = remainingBalance;
            LogHistory("GIVE CHANGE", startingBalance, CurrentBalance);
            return $"\nHere's your change:\n{quarters} quarter(s)\n{dimes} dime(s)\n{nickels} nickel(s)\n";
            
        }
        
    }


}
