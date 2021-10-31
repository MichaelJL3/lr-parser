namespace ParserLib.Grammar
{
    /// <summary>
    /// Rule Vector
    /// 
    /// Vector of grammar rules
    /// </summary>
    public class RuleVector
    {
        /// Rule vector
        private readonly Rule[] ruleVector;

        /// <summary>
        /// Initializes a new instance of the <see cref="RuleVector" /> class
        /// </summary>
        /// <param name="size">Size of the rule vector defaults to 0</param>
        public RuleVector(int size = 0)
        {
            this.ruleVector = new Rule[size];
        }

        /// Indexer for rule vector
        public Rule this[int i]
        {
            get {
                return ruleVector[i];
            }
            set {
                ruleVector[i] = value;
            }
        }

        /// <summary>
        /// Rule
        /// </summary>
        public class Rule {
            /// Number of stack elements refered to by the rule
            public int References { get; set; }
            
            /// Goto id
            public int Goto { get; set; }
        }
    }
}