using System.Collections.Generic;

namespace ParserLib.Grammar
{
    /// <summary>
    /// Action Table
    /// 
    /// Matrix of symbols to their corresponding action transitions
    /// </summary>
    public class ActionTable
    {   
        /// Error action 
        private static readonly Action ERROR = new Action { 
            State = -1, 
            Type = State.ERROR 
        };

        /// <summary>
        /// Matrix of symbols and actions
        /// </summary>
        /// <typeparam name="string">Symbol</typeparam>
        /// <typeparam name="Action[]">Actions vector per symbol</typeparam>
        private readonly IDictionary<string, Action[]> actionTable = new Dictionary<string, Action[]>();
        
        /// Number of columns in each row vector
        private readonly int cols;

        /// <summary>
        /// Initializes a new instance of the <see cref="ActionTable" /> class
        /// </summary>
        /// <param name="cols">Size of each row vector</param>
        public ActionTable(int cols)
        {
            this.cols = cols;
        }

        /// Indexer of the action table
        public Action this[string symbol, int index]
        {
            get {
                // Invalid index
                if (index < 0 || index >= cols || !actionTable.ContainsKey(symbol)) {
                    return ERROR;
                }
                
                var action = actionTable[symbol][index];

                // Return action or error if not found
                return action ?? ERROR;
            }
            set {
                // Create action vector for symbol if not present
                if (!actionTable.ContainsKey(symbol)) {
                    actionTable[symbol] = new Action[cols];
                }

                actionTable[symbol][index] = value;
            }
        }

        /// <summary>
        /// Create a new accept action and set it in the matrix at the specified location
        /// </summary>
        /// <param name="symbol">Action symbol (row)</param>
        /// <param name="index">Action index (col)</param>
        /// <returns>New accept action</returns>
        public Action Accept(string symbol, int index)
        {
            return SetAction(symbol, index, 0, State.ACCEPTED);
        }

        /// <summary>
        /// Create a new shift action and set it in the matrix at the specified location
        /// </summary>
        /// <param name="symbol">Action symbol (row)</param>
        /// <param name="index">Action index (col)</param>
        /// <param name="state">The actions shift value</param>
        /// <returns>New shift action</returns>
        public Action Shift(string symbol, int index, int state)
        {
            return SetAction(symbol, index, state, State.SHIFT);
        }

        /// <summary>
        /// Create a new reduce action and set it in the matrix at the specified location
        /// </summary>
        /// <param name="symbol">Action symbol (row)</param>
        /// <param name="index">Action index (col)</param>
        /// <param name="rule">The actions rule id</param>
        /// <returns>New reduce action</returns>
        public Action Reduce(string symbol, int index, int rule)
        {
            return SetAction(symbol, index, rule, State.REDUCE);
        }

        /// <summary>
        /// Create a new action and set it in the matrix at the specified location
        /// </summary>
        /// <param name="symbol">Action symbol (row)</param>
        /// <param name="index">Action index (col)</param>
        /// <param name="state">The state value of the action</param>
        /// <param name="type">The action type</param>
        /// <returns>New action</returns>
        public Action SetAction(string symbol, int index, int state, State type)
        {
            return this[symbol, index] = new Action { 
                State = state, 
                Type = type 
            };
        }

        /// <summary>
        /// Action
        /// </summary>
        public class Action {
            /// Transition/State of the action
            public int State { get; set; }

            /// Type of action
            public State Type { get; set; }    
        }

        /// <summary>
        /// Action states enum
        /// </summary>
        public enum State {
            ACCEPTED,
            ERROR,
            SHIFT,
            REDUCE
        }
    }
}