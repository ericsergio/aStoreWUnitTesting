using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AnvilStore.UnitTests
{
    [TestClass]
    public class DataTests
    {
        [DataTestMethod]
        [DataRow("AL")]
        [DataRow("AK")]
        [DataRow("AZ")]
        [DataRow("AR")]
        [DataRow("AS")]
        [DataRow("CA")]
        [DataRow("CO")]
        [DataRow("CT")]
        [DataRow("DE")]
        [DataRow("DC")]
        [DataRow("FL")]
        [DataRow("GA")]
        [DataRow("GU")]
        [DataRow("HI")]
        [DataRow("ID")]
        [DataRow("IL")]
        [DataRow("IN")]
        [DataRow("IA")]
        [DataRow("KS")]
        [DataRow("KY")]
        [DataRow("LA")]
        [DataRow("ME")]
        [DataRow("MD")]
        [DataRow("MA")]
        [DataRow("MI")]
        [DataRow("MN")]
        [DataRow("MS")]
        [DataRow("MO")]
        [DataRow("MT")]
        [DataRow("NE")]
        [DataRow("NV")]
        [DataRow("NH")]
        [DataRow("NJ")]
        [DataRow("NM")]
        [DataRow("NY")]
        [DataRow("NC")]
        [DataRow("ND")]
        [DataRow("CM")]
        [DataRow("OH")]
        [DataRow("OK")]
        [DataRow("OR")]
        [DataRow("PA")]
        [DataRow("PR")]
        [DataRow("RI")]
        [DataRow("SC")]
        [DataRow("SD")]
        [DataRow("TN")]
        [DataRow("TX")]
        [DataRow("TT")]
        [DataRow("UT")]
        [DataRow("VT")]
        [DataRow("VA")]
        [DataRow("VI")]
        [DataRow("WA")]
        [DataRow("WV")]
        [DataRow("WI")]
        [DataRow("WY")]
        public void CheckState_ValidStateCode_Returns1(string state)
        {
            //Arrange
            //string testStateCode = "WA";
            Data data = new();
            //Act
            //for(int i = 0; i < states.Length; i++)
            
            int result = data.CheckState(state);
            
            var expected = 1;
            //Assert
            Assert.AreEqual(result, expected);
        }
        [DataTestMethod]
        [DataRow("QQ")]
        [DataRow("12")]
        public void CheckState_InValidStateCode_Returns0(string state)
        {
            //Arrange           
            Data data = new();
            
            //Act            
            int result = data.CheckState(state);
            var expected = 0;
            
            //Assert
            Assert.AreEqual(result, expected);
        }
    }
}
