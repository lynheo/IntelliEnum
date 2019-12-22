using Microsoft.VisualStudio.TestTools.UnitTesting;

using Lyn.IntelliEnum;

using cm = System.ComponentModel;

namespace Lyn.IntelliEnumTest
{
    public enum TestEnum
    {
        None,
        [cm.Description("Value Test 01")]
        Value01 = 1,
        [cm.Description("Value Test 02")]
        Value02 = 2,
    }

    [TestClass]
    public class IntelliEnumTest
    {
        [TestMethod]
        public void TestGetDescriptionStrings()
        {
            var testEnumStrings = IntelliEnum.IntelliEnum.GetDescriptionStrings<TestEnum>();
            Assert.IsTrue(testEnumStrings[1] == "Value Test 01");
            Assert.IsTrue(testEnumStrings[2] == "Value Test 02");
        }


        [TestMethod]
        public void TestGetDescriptionStringMap()
        {
            var testEnumDict = IntelliEnum.IntelliEnum.GetDescriptionStringMap<TestEnum>();
            Assert.IsTrue(testEnumDict[TestEnum.Value01] == "Value Test 01");
            Assert.IsTrue(testEnumDict[TestEnum.Value02] == "Value Test 02");
        }

        [TestMethod]
        public void TestGetEnumValueFromDescription()
        {
            var var1 = IntelliEnum.IntelliEnum.GetEnumValueFromDescription("Value Test 01", TestEnum.None);
            var varn = IntelliEnum.IntelliEnum.GetEnumValueFromDescription("Unknown Value", TestEnum.None);
            
            Assert.IsTrue(var1 == TestEnum.Value01);
            Assert.IsTrue(varn == TestEnum.None);
        }
    }
}
