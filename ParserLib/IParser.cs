namespace ParserLib
{
    /// <summary>
    /// Parser interface
    /// </summary>
    public interface IParser
    {
        /// <summary>
        /// Parse input
        /// </summary>
        /// <param name="input">The input string to parse</param>
        /// <returns>Sucess status of parsing</returns>
        bool Parse(string input);
    }
}