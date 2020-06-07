using Capstone.Models;
using System;
using System.Collections.Generic;

namespace CLI
{
    /// <summary>
    /// The top-level menu in our Market Application
    /// </summary>
    public class SubMenu1 : CLIMenu
    {
        // Store any private variables here....
        VendingMachine ourVendingMachine;

        /// <summary>
        /// Constructor adds items to the top-level menu
        /// </summary>
        public SubMenu1(VendingMachine vendingMachine) :
            base("SubMenu1")
        {
            ourVendingMachine = vendingMachine;
        }

        protected override void SetMenuOptions()
        {
            this.menuOptions.Add("1", "Feed Money");
            this.menuOptions.Add("2", "Select Product");
            this.menuOptions.Add("3", "Finish Transaction");
            this.menuOptions.Add("B", "Back to Main Menu");
            this.quitKey = "B";
        }

        /// <summary>
        /// The override of ExecuteSelection handles whatever selection was made by the user.
        /// This is where any business logic is executed.
        /// </summary>
        /// <param name="choice">"Key" of the user's menu selection</param>
        /// <returns></returns>
        protected override bool ExecuteSelection(string choice)
        {
            switch (choice)
            {
                case "1": // Feed Money 
                    int moneyInserted = GetInteger("Please insert money in whole dollar amounts: ");           //int.TryParse?            
                    ourVendingMachine.FeedMoney(moneyInserted);
                    Pause("");
                    return true;
                case "2": // Select Item
                    SetColor(ConsoleColor.Blue);
                    Console.WriteLine(ourVendingMachine.DisplayInventory());
                    ResetColor();
                    string selectedSlot;
                    Console.Write($"Please enter the Slot ID for the item you would like to purchase: ");
                    selectedSlot = Console.ReadLine();
                    Console.WriteLine(ourVendingMachine.SelectProduct(selectedSlot));
                    WriteError("Thanks for your business!");
                    Pause("");
                    //return false;
                    return true;
                case "3":    //complete transaction, return change
                    SetColor(ConsoleColor.White);
                    Console.WriteLine(ourVendingMachine.GetChange());
                    ResetColor();
                    Pause("");
                    return true; 
            }
            return true;
        }

        protected override void BeforeDisplayMenu()
        {
            PrintHeader();
        }

        protected override void AfterDisplayMenu()
        {
            base.AfterDisplayMenu();
            SetColor(ConsoleColor.DarkRed);
            Console.WriteLine($"\nCurrent Money Provided: ${ourVendingMachine.CurrentBalance}\n");
            ResetColor();
        }

        private void PrintHeader()
        {
            SetColor(ConsoleColor.DarkBlue);
            Console.WriteLine(Figgle.FiggleFonts.Standard.Render("Purchase Menu"));            
            ResetColor();
        }

    }
}
