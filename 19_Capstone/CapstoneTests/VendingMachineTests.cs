using Capstone.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CapstoneTests
{
    [TestClass]
    public class VendingMachineTests
    {
        [DataTestMethod]
        [DataRow(5, 5)]
        [DataRow(10, 10)]
        [DataRow(0, 0)]
        public void Feed_Money_Method_(int moneyFed, double expectedResult)
        {
            //Arrange
            VendingMachine vending = new VendingMachine();

            //Act
            decimal result = vending.FeedMoney(moneyFed);

            //Assert
            decimal expectedBalance = (decimal)expectedResult;
            Assert.AreEqual(expectedBalance, result);
        }

        [DataTestMethod]
        [DataRow(2, "B3", 2, 0, 0)]
        [DataRow(3, "D1", 8, 1, 1)]
        public void Get_Change_Returns_Correct_Change(int moneyFed, string slotID, int expectedQuarters, int expectedDimes, int expectedNickels)
        {
            //Arrange
            VendingMachine vending = new VendingMachine();
            vending.LoadInventory("vendingmachine.csv");
            string expectedResult = $"Here's your change:\n{expectedQuarters} quarters\n{expectedDimes} dimes\n{expectedNickels} nickels";

            //Act
            vending.FeedMoney(moneyFed);
            vending.SelectProduct(slotID);
            string result = vending.GetChange();

            //Assert
            Assert.AreEqual(expectedResult, result);

        }

        

    }
}
