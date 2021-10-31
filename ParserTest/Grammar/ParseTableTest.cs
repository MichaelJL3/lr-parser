using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParserLib.Grammar;

namespace ParserTest.Grammar
{
    [TestClass]
    public class ParseTableTest
    {
        [TestMethod]
        public void Initialize_Succeeds()
        {
            var instance = new ParseTable();
            Assert.IsNotNull(instance);
        }
    }
}