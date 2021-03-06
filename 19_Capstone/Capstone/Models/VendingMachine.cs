﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Models
{
    public class VendingMachine : MoneyHandler
    {
        public Dictionary<string, Product> productInventory { get; set; }
        
       

        public VendingMachine()
        {
            
        }
        
        public void LoadInventory(string filename)
        {
            productInventory = new Dictionary<string, Product>();

            using (StreamReader sw = new StreamReader($"..\\..\\..\\{filename}"))
            {
                while (!sw.EndOfStream)
                {
                    string line = sw.ReadLine();

                    string[] productFields = line.Split("|"); 

                    Product product = new Product(productFields[1], decimal.Parse(productFields[2]), productFields[3], 5);
                    string slotID = productFields[0];

                    productInventory.Add(slotID, product);
                }
            }
        }

        public string DisplayInventory()
        { //this needs to be our dictionary 
            string inventory = "";

            foreach (KeyValuePair<string, Product> entry in productInventory)
            {
                
                inventory += $"{entry.Key} ||| {entry.Value.Name}, ${entry.Value.Price}, {entry.Value.Quantity} Left In Stock" +
                    $"\n---------------------------------------------------\n";
            }
            return inventory;
        }


      

        public string SelectProduct(string slotID)             
        {
            if (!productInventory.ContainsKey(slotID))
            {
                return "Sorry, invalid slot ID!";
            }

            else if (productInventory[slotID].Quantity == 0)
            {
                return "Sorry, SOLD OUT";
            }

            else if (CurrentBalance < productInventory[slotID].Price)
            {
                return "Sorry, please feed in more money!";
            }

            else
            {
                //decrement quantity
                productInventory[slotID].Quantity--;

                //subtract price from current balance
                decimal startingBalance = CurrentBalance;
                CurrentBalance -= productInventory[slotID].Price;

                //Log the transaction
                LogHistory($"{productInventory[slotID].Name} {slotID}", startingBalance, CurrentBalance);

                //You purchase {name} for {price}. You have {current balance} remaining. **GetSound(Type)**
                return $"You purchased {productInventory[slotID].Name} for ${productInventory[slotID].Price}.\nYou have ${CurrentBalance} remaining.\n" +
                    $"{productInventory[slotID].GetSound(productInventory[slotID].Type)}";
            }


        }





    }
    
}
