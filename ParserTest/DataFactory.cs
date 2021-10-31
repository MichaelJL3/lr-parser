using System.Collections.Generic;
using ParserLib.Grammar;

namespace ParserTest
{
    using Rule = RuleVector.Rule;

    public static class DataFactory
    {
        public static ParseTable HardCodedParseTable()
        {
            var parseTable = new ParseTable();

            parseTable.Goto    = HardCodedGoto();
            parseTable.Rules   = HardCodedRules();
            parseTable.Actions = HardCodedActions();

            return parseTable;
        }

        public static GotoTable HardCodedGoto()
        {
            var gotoTable = new GotoTable(3, 12, -1);

            gotoTable[0, 0] = 1;
            gotoTable[0, 4] = 8;
            gotoTable[1, 0] = 2;
            gotoTable[1, 4] = 2;
            gotoTable[1, 6] = 9;
            gotoTable[2, 0] = 3;
            gotoTable[2, 4] = 3;
            gotoTable[2, 6] = 3;
            gotoTable[2, 7] = 10;

            return gotoTable;
        }

        public static RuleVector HardCodedRules()
        {
            var ruleVector = new RuleVector(7);

            ruleVector[1] = new Rule { References = 3, Goto = 0 };
            ruleVector[2] = new Rule { References = 1, Goto = 0 };
            ruleVector[3] = new Rule { References = 3, Goto = 1 };
            ruleVector[4] = new Rule { References = 1, Goto = 1 };
            ruleVector[5] = new Rule { References = 3, Goto = 2 };
            ruleVector[6] = new Rule { References = 1, Goto = 2 };

            return ruleVector;
        }

        public static ActionTable HardCodedActions()
        {
            var actionTable = new ActionTable(12);

            actionTable.Shift("id", 0, 5);
            actionTable.Shift("id", 4, 5);
            actionTable.Shift("id", 6, 5);
            actionTable.Shift("id", 7, 5);

            actionTable.Shift("+", 1, 6);
            actionTable.Reduce("+", 2, 2);
            actionTable.Reduce("+", 3, 4);
            actionTable.Reduce("+", 5, 6);
            actionTable.Shift("+", 8, 6);
            actionTable.Reduce("+", 9, 1);
            actionTable.Reduce("+", 10, 3);
            actionTable.Reduce("+", 11, 5);

            actionTable.Shift("*", 2, 7);
            actionTable.Reduce("*", 3, 4);
            actionTable.Reduce("*", 5, 6);
            actionTable.Shift("*", 9, 7);
            actionTable.Reduce("*", 10, 3);
            actionTable.Reduce("*", 11, 5);

            actionTable.Shift("(", 0, 4);
            actionTable.Shift("(", 4, 4);
            actionTable.Shift("(", 6, 4);
            actionTable.Shift("(", 7, 4);

            actionTable.Reduce(")", 2, 2);
            actionTable.Reduce(")", 3, 4);
            actionTable.Reduce(")", 5, 6);
            actionTable.Shift(")", 8, 11);
            actionTable.Reduce(")", 9, 1);
            actionTable.Reduce(")", 10, 3);
            actionTable.Reduce(")", 11, 5);

            actionTable.Accept("$", 1);
            actionTable.Reduce("$", 2, 2);
            actionTable.Reduce("$", 3, 4);
            actionTable.Reduce("$", 5, 6);
            actionTable.Reduce("$", 9, 1);
            actionTable.Reduce("$", 10, 3);
            actionTable.Reduce("$", 11, 5);

            return actionTable;
        }

        public static IReadOnlySet<string> HardCodedSymbols()
        {
            return new HashSet<string>() {
                "id", "+", "*", "(",  ")", "$"
            };
        }
    }
}