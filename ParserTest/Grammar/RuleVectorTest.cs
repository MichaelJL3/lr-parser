using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParserLib.Grammar;
using System;

namespace ParserTest.Grammar
{
    [TestClass]
    public class RuleVectorTest
    {
        [TestMethod]
        public void Initialize_Succeeds()
        {
            var instance = new RuleVector();
            Assert.IsNotNull(instance);
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(0)]
        [DataRow(-1)]
        public void Fetch_OutOfBounds_ThrowsException(int index)
        {
            Assert.ThrowsException<IndexOutOfRangeException>(
                () => new RuleVector()[index]  
            );
        }
    }
}