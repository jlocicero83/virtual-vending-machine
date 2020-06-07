using Capstone.Models;
using CLI;
using System;
using System.IO;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            // new vending machine
            VendingMachine ourVendingMachine = new VendingMachine();
            // load inventory with file name
            ourVendingMachine.LoadInventory("vendingmachine.csv");
            
            //main menu constructor pass in vending machine
            MainMenu main = new MainMenu(ourVendingMachine);
            main.Run();
           
        }

    }
}
