using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AnvilStore.UnitTests
{
    [TestClass]
    public class CustomerTests
    {
        [TestMethod]
        [DataRow(new string[] { "Jane", "Doe", "123 99th St SE", "Seattle", "WA", "12121" })]
        public void CheckThatValuesAreNotEmpty_NoRequiredValueIsNull_True(string[] valuesToTestFor)
        {
            //Arrange
            Customer cust = new(valuesToTestFor);
            //Act
            var result = cust.CheckThatValuesAreNotEmpty(valuesToTestFor);
            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        [DataRow(new string[] { "Jane", "Doe", "123 99th St SE", "Seattle", "WA", "12121" })]
        public void ValidateZip_ValidZipProvided_Return1(string[] testValues)
        {
            //Arrange
            //Customer cust = new(testValues);
            //Act
            var result = Customer.ValidateZip(testValues[5]);
            int expected = 1;
            //Assert
            Assert.AreEqual(result, expected);
        }
        [TestMethod]
        [DataRow(new string[] { "Jane", "Doe", "123 99th St SE", "Seattle", "WA", "12" })]
        public void ValidateZip_InValidZipProvided_Return0(string[] testValues)
        {
            //Arrange
            //Customer cust = new(testValues);
            //Act
            var result = Customer.ValidateZip(testValues[5]);
            int expected = 0;
            //Assert
            Assert.AreEqual(result, expected);
        }
        [TestMethod]
        [DataRow(new string[] { "Jane", "Doe", "123 99th St SE", "Seattle", "QQ", "12121" })]
        public void ValidateState_ValidStateProvided_Return1(string[] testValues)
        {
            //Arrange
            //Customer cust = new(testValues);
            //Act
            var result = Customer.ValidateState(testValues[4]);
            int expected = 0;
            //Assert
            Assert.AreEqual(result, expected);
        }
        [TestMethod]
        [DataRow(new string[] { "Jane", "Doe", "123 99th St SE", "Seattle", "WA", "12121" })]
        public void ValidateState_InValidStateProvided_Return0(string[] testValues)
        {
            //Arrange
            //Customer cust = new(testValues);
            //Act
            var result = Customer.ValidateState(testValues[4]);
            int expected = 1;
            //Assert
            Assert.AreEqual(result, expected);
        }
        [DataTestMethod]
        [DataRow("123 Cherry st")]
        [DataRow("1234 4th st")]
        [DataRow("14 4th rd")]
        [DataRow("1234 4th dr")]
        [DataRow("1234 First st")]
        [DataRow("1234 4th Ave")]
        [DataRow("34 234th st")]
        [DataRow("14 4th rd")]
        [DataRow("134 4th pt")]
        [DataRow("1234 43rd st")]
        [DataRow("1234 4th Ave")]
        public void ValidateAddress_ValidAddress_Returns1(string address)
        {
            //Arrange           
            

            //Act            
            int result = Customer.ValidateAddress(address);
            var expected = 1;

            //Assert
            Assert.AreEqual(result, expected);
        }
    }
}
