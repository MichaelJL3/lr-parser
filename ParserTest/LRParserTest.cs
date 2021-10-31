using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParserLib;
using ParserLib.Token;

namespace ParserTest
{
    [TestClass]
    public class LRParserTest
    {
        [TestMethod]
        [DataRow("id$", true)]
        [DataRow("id+(id)$", true)]
        [DataRow("id+(id+id)$", true)]
        [DataRow("id+(idid)$", false)]
        public void Parse_CheckExpected(string input, bool expected)
        {
            var result = ParserFactory().Parse(input);

            Assert.AreEqual(expected, result);
        }

        private static IParser ParserFactory()
        {
            var parseTable = DataFactory.HardCodedParseTable();
            var symbols    = DataFactory.HardCodedSymbols();

            var tokenizer = new SymbolTokenizer(symbols);
        
            return new LRParser(tokenizer, parseTable);
        }
    }
}
