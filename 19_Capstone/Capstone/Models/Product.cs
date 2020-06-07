using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    public class Product
    {
        //properties
        public string Name { get; }
        public decimal Price { get; }

        public string Type { get; }
        public int Quantity { get; set; }  
        


        //constructors
        public Product(string name, decimal price, string type, int quantity)
        {
            Name = name;
            Price = price;
            Type = type;
            Quantity = quantity;
            
        }

        //methods
        public string GetSound(string type)
        {
            switch(type)
            {
                case "Chip": return "Crunch Crunch, Yum!";
                    
                case "Candy": return "Munch Munch, Yum!";
                    
                case "Drink": return "Glug Glug, Yum!";
                   
                case "Gum": return "Chew Chew, Yum!";
                   
            }
            return "";
        }

    }
}
