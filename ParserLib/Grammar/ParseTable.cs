namespace ParserLib.Grammar
{
    /// <summary>
    /// Parse Table
    /// </summary>
    public class ParseTable {
        /// Goto Table
        public GotoTable   Goto    { get; set; }

        /// Rule Vector
        public RuleVector  Rules   { get; set; }

        /// Action Table
        public ActionTable Actions { get; set; }
    }
}