using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using ParserLib.Token;

namespace ParserTest.Token
{
    [TestClass]
    public class SymbolTokenizerTest
    {
        [TestMethod]
        [DataRow(new string[] {}, "")]
        [DataRow(new string[] {"id", "(", "$"}, "id($")]
        [DataRow(new string[] {"*", "*", "$", "*"}, "**$*")]
        [DataRow(new string[] {"id", "id", "id"}, "ididid")]
        [DataRow(new string[] {"id", "+", "(", ")", "$", "*"}, "id+()$*")]
        public void Tokenize_CheckExpected(string[] expected, string input)
        {
            var result = TokenizerFactory().Tokenize(input);

            CollectionAssert.AreEquivalent(expected, result.ToArray());
        }

        [TestMethod]
        public void Tokenize_NullInput_ThrowsException()
        {
            Assert.ThrowsException<NullReferenceException>(() => {
                TokenizerFactory().Tokenize(null);
            });
        }

        [TestMethod]
        public void Initialize_NullSymbolSet_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(
                () => new SymbolTokenizer(null)
            );
        }

        [TestMethod]
        public void Initialize_WithSymbolSet_Succeeds()
        {
            var instance = new SymbolTokenizer(new HashSet<string>());
            Assert.IsNotNull(instance);
        }

        private static ITokenizer TokenizerFactory()
        {
            return new SymbolTokenizer(DataFactory.HardCodedSymbols());
        }
    }
}