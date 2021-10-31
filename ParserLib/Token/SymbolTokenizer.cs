using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ParserLib.Token
{
    /// <summary>
    /// Symbol Tokenizer
    /// </summary>
    public class SymbolTokenizer : ITokenizer
    {
        /// Read only set of allowed symbols
        private readonly IReadOnlySet<string> symbolDict;

        /// <summary>
        /// Initializes a new instance of the <see cref="SymbolTokenizer" /> class
        /// </summary>
        /// <param name="symbolDict">The symbol dictionary</param>
        public SymbolTokenizer([NotNull] IReadOnlySet<string> symbolDict) 
        {
            this.symbolDict = symbolDict ?? throw new ArgumentNullException(nameof(symbolDict));
        }

        /// <summary>
        /// Tokenize input string based on recognized symbol dictionary
        /// </summary>
        /// <param name="input">The input string to tokenize</param>
        /// <returns>The read only list of tokens</returns>
        public IReadOnlyList<string> Tokenize(string input)
        {
            var tokens = new List<string>();
            var sb = new StringBuilder();

            for (int i = 0; i < input.Length; ++i) {
                sb.Append(input[i]);
                
                var symbol = sb.ToString();

                // Check if token is a registered symbol
                if (symbolDict.Contains(symbol)) {
                    tokens.Add(symbol);
                    sb.Clear();
                }
            }

            return tokens;
        }
    }
}