using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AnvilStore.UnitTests
{
    [TestClass]
    public class OrderTests
    {
        //CalculateWithSalesTax()
        //CalculateOrderShippingCost()
        //CalculateBaseCostWithBulkOrderDiscount()
        //CalculateOrderTotal()
        [TestMethod]
        public void TestCalculateBaseCostWithBulkOrderDiscount_LessThan10Ordered_Price88_50()
        {
            //Arrange
            AnvilStore.Order testOrderLessThan10 = new("John Doe", "123 1st St SW", "Gothem", "AK", "98111", 1);

            //Act
            decimal result = (testOrderLessThan10.CalculateBaseCostWithBulkOrderDiscount());
            decimal expectedResult = 88.50m;

            //Assert
            Assert.AreEqual(expectedResult, result);
        }
        [TestMethod]
        public void TestCalculateBaseCostWithBulkOrderDiscount_Between10And19_Price70()
        {
            //Arrange
            AnvilStore.Order testOrderLessThan10 = new("John Doe", "123 1st St SW", "Gothem", "AK", "98111", 11);

            //Act
            decimal result = (testOrderLessThan10.CalculateBaseCostWithBulkOrderDiscount() / 11);
            decimal expectedResult = 70.00m;

            //Assert
            Assert.AreEqual(expectedResult, result);
        }
        [TestMethod]
        public void TestCalculateBaseCostWithBulkOrderDiscount_GreaterThan20_Price68_25()
        {
            //Arrange
            AnvilStore.Order testOrderLessThan10 = new("John Doe", "123 1st St SW", "Gothem", "AK", "98111", 20);

            //Act
            decimal result = (testOrderLessThan10.CalculateBaseCostWithBulkOrderDiscount() / 20);
            decimal expectedResult = 68.25m;

            //Assert
            Assert.AreEqual(expectedResult, result);
        }
        [TestMethod]
        public void CalculateOrderShippingCost_StateIsCA_ShippingFree()
        {
            //Arrange
            AnvilStore.Order stateIsCA = new("John Doe", "123 1st St SW", "Gothem", "CA", "98111", 20);

            //Act
            decimal result = (stateIsCA.CalculateOrderShippingCost());
            decimal expectedResult = 0m;

            //Assert
            Assert.AreEqual(expectedResult, result);
        }
        [TestMethod]
        public void CalculateOrderShippingCost_StateIsOR_ShippingFree()
        {
            //Arrange
            AnvilStore.Order stateIsOR = new("John Doe", "123 1st St SW", "Gothem", "OR", "98111", 20);

            //Act
            decimal result = (stateIsOR.CalculateOrderShippingCost());
            decimal expectedResult = 0m;

            //Assert
            Assert.AreEqual(expectedResult, result);
        }
        [TestMethod]
        public void CalculateOrderShippingCost_QuantityLessThan5_ShippingFree()
        {
            //Arrange
            AnvilStore.Order stateIsOR = new("John Doe", "123 1st St SW", "Gothem", "OR", "98111", 4);

            //Act
            decimal result = (stateIsOR.CalculateOrderShippingCost());
            decimal expectedResult = 0m;

            //Assert
            Assert.AreEqual(expectedResult, result);
        }
        [TestMethod]
        public void CalculateOrderShippingCost_Quantity5orMoreNotCANotOR_Shipping150PerAnvil()
        {
            //Arrange
            AnvilStore.Order ShipNotFree = new("John Doe", "123 1st St SW", "Gothem", "IL", "98111", 7);

            //Act
            decimal result = (ShipNotFree.CalculateOrderShippingCost() / ShipNotFree.OrderQuantity);
            decimal expectedResult = 150.00m;

            //Assert
            Assert.AreEqual(expectedResult, result);
        }
        [TestMethod]
        public void CalculateWithSalesTax_AnyOrder_Tax10Point85Percent()
        {
            //Arrange
            AnvilStore.Order taxTest = new("John Doe", "123 1st St SW", "Gothem", "IL", "98111", 7);

            //Act
            decimal result = ((taxTest.CalculateWithSalesTax() - taxTest.CalculateBaseCostWithBulkOrderDiscount())  / taxTest.CalculateBaseCostWithBulkOrderDiscount());
            decimal expectedResult = .1085m;

            //Assert
            Assert.AreEqual(expectedResult, result);
        }
        [TestMethod]
        public void CalculateOrderTotal_AnyOrder_TotalAddsTaxShippingAndBase()
        {
            //Arrange
            AnvilStore.Order totalTest = new("John Doe", "123 1st St SW", "Gothem", "IL", "98111", 7);

            //Act
            decimal tax = totalTest.CalculateWithSalesTax() - totalTest.CalculateBaseCostWithBulkOrderDiscount();
            decimal shipping = totalTest.CalculateOrderShippingCost();
            decimal baseTotal = totalTest.CalculateBaseCostWithBulkOrderDiscount();
            
            //decimal result = ((taxTest.CalculateWithSalesTax() - taxTest.CalculateBaseCostWithBulkOrderDiscount())  / taxTest.CalculateBaseCostWithBulkOrderDiscount());
            decimal expectedResult = Math.Round(1736.72m);
            decimal result = Math.Round(tax + shipping + baseTotal);

            //Assert
            Assert.AreEqual(expectedResult, result);
            
        }
    }
}
