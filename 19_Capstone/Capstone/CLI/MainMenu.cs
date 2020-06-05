using Capstone.Models;
using System;
using System.Collections.Generic;

namespace CLI
{
    /// <summary>
    /// The top-level menu in our Market Application
    /// </summary>
    public class MainMenu : CLIMenu
    {
        // You may want to store some private variables here.  YOu may want those passed in 
        // in the constructor of this menu

        VendingMachine ourVendingMachine;

        /// <summary>
        /// Constructor adds items to the top-level menu. You will likely have parameters  passed in
        /// here...
        /// </summary>
        public MainMenu(VendingMachine vendingMachine) : base("Main Menu")
        {
            ourVendingMachine = vendingMachine;
        }

        protected override void SetMenuOptions()
        {
            // A Sample menu.  Build the dictionary here
            this.menuOptions.Add("1", "Display Vending Machine Items");
            this.menuOptions.Add("2", "Purchase");
            this.menuOptions.Add("Q", "Quit program");
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
                case "1": // Do whatever option 1 is. You may prompt the user for more information
                          // (using the Helper methods), and then pass those values into some 
                          //business object to get something done.
                    Console.WriteLine();

                    // set color here? 
                    SetColor(ConsoleColor.DarkGreen);
                    Console.WriteLine("CURRENT INVENTORY");
                    Console.WriteLine("**********************");
                    Console.WriteLine(ourVendingMachine.DisplayInventory());
                    ResetColor();
                    Pause("");
                    return true;    // Keep running the main menu
                case "2": // Do whatever option 2 is
                    SubMenu1 sm = new SubMenu1(ourVendingMachine);    // Create and show the sub-menu
                    sm.Run();
                    return true;    // Keep running the main menu
                    
                    
                    
            }
            return true;
        }

        protected override void BeforeDisplayMenu()
        {
            PrintHeader();
        }


        private void PrintHeader()
        {
            SetColor(ConsoleColor.DarkRed);
            Console.WriteLine(Figgle.FiggleFonts.Standard.Render("Vendo-Matic 800"));
            SetColor(ConsoleColor.DarkYellow);
            //set color here? 
            ResetColor();
        }
    }
}
