using System.Collections.Generic;

namespace ParserLib.Token
{
    /// <summary>
    /// Tokenizer interface
    /// </summary>
    public interface ITokenizer
    {
        /// <summary>
        /// Tokenize input string
        /// </summary>
        /// <param name="input">The input string to tokenize</param>
        /// <returns>The read only list of tokens</returns>
         IReadOnlyList<string> Tokenize(string input);
    }
}