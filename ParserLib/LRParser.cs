using System;
using System.Collections.Generic;
using ParserLib.Token;
using ParserLib.Grammar;

namespace ParserLib
{
    using Action = ActionTable.Action;
    using State  = ActionTable.State;

    /// <summary>
    /// LRParser
    /// </summary>
    public class LRParser : IParser
    {
        /// Input string tokenizer
        private readonly ITokenizer tokenizer;

        /// Parse table
        private readonly ParseTable parseTable;

        /// <summary>
        /// Initializes a new instance of the <see cref="LRParser" /> class
        /// </summary>
        /// <param name="tokenizer">The input string tokenizer</param>
        /// <param name="parseTable">The parse table</param>
        public LRParser(
            ITokenizer tokenizer,
            ParseTable parseTable
        ) {
            this.tokenizer  = tokenizer;
            this.parseTable = parseTable;
        }

        /// <summary>
        /// Parse the input string
        /// </summary>
        /// <param name="input">The input string</param>
        /// <returns>Success state of the parse</returns>
        public bool Parse(string input) 
        { 
            var enumerator = tokenizer.Tokenize(input).GetEnumerator();
            enumerator.MoveNext();

            var stateStack = new Stack<int>();
            stateStack.Push(0);

            while(enumerator.Current != null) {
                // Retrieve next action
                var state  = NextState(stateStack);
                var symbol = enumerator.Current;
                var action = parseTable.Actions[symbol, state];

                // Log relevant step
                Log(state, symbol, action.Type, action.State);
                
                // Apply next action
                if (action.Type == State.SHIFT) {
                    Shift(action, stateStack, enumerator);
                } else if (action.Type == State.REDUCE) {
                    Reduce(action, stateStack, parseTable);
                } else {
                    return action.Type == State.ACCEPTED;
                }
            }

            // Accept was not reached
            return false;
        }

        /// <summary>
        /// Apply reduce action
        /// </summary>
        /// <param name="action">The action to apply</param>
        /// <param name="stateStack">The stack of states</param>
        private static void Reduce(Action action, Stack<int> stateStack, ParseTable parseTable)
        {
            // Fetch the rule to apply
            var rule  = parseTable.Rules[action.State];
            // Reduce used variables into new node
            var state = NextState(stateStack, rule.References);
            // Add new state based on rule
            var transition = parseTable.Goto[rule.Goto, state];

            stateStack.Push(transition);
        }

        /// <summary>
        /// Apply shift action
        /// </summary>
        /// <param name="action">The action to apply</param>
        /// <param name="stateStack">The stack of states</param>
        /// <param name="enumerator">The symbol enumerator</param>
        private static void Shift(Action action, Stack<int> stateStack, IEnumerator<string> enumerator)
        {
            // Move to the next symbol of the input
            enumerator.MoveNext();
            // Push the new state on to the stack
            stateStack.Push(action.State);
        }

        /// <summary>
        /// Fetch the next required state
        /// </summary>
        /// <param name="stateStack">The stack of states</param>
        /// <param name="skips">The number of consumed states</param>
        /// <returns></returns>
        private static int NextState(Stack<int> stateStack, int skips = 0) 
        {
            // Corrupted input string
            if (skips >= stateStack.Count)
                return -1;

            // Consume states
            for (int i = 0; i < skips; ++i)
                stateStack.Pop();

            return stateStack.Peek();
        }

        /// <summary>
        /// Log relevant information about a step
        /// </summary>
        /// <param name="state">The current state</param>
        /// <param name="symbol">The current symbol</param>
        /// <param name="actionType">The next action</param>
        /// <param name="actionState">The next state</param>
        private static void Log(int state, string symbol, State actionType, int actionState)
        {
            Console.WriteLine($"{state}, {symbol}, {actionType}, {actionState}");
        }
    }
}
