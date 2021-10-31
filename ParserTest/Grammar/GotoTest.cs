using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParserLib.Grammar;
using System;

namespace ParserTest.Grammar
{
    [TestClass]
    public class GotoTest
    {
        [TestMethod]
        public void Initialize_Succeeds()
        {
            var instance = new GotoTable(0, 0);
            Assert.IsNotNull(instance);
        }

        [TestMethod]
        [DataRow(1, 1)]
        [DataRow(0, 0)]
        [DataRow(-1, -1)]
        public void Fetch_OutOfBounds_ThrowsException(int row, int col)
        {
            Assert.ThrowsException<IndexOutOfRangeException>(
                () => new GotoTable(0, 0)[row, col]  
            );
        }
    }
}