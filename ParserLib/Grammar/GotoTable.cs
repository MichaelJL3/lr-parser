using System;

namespace ParserLib.Grammar
{
    /// <summary>
    /// Goto Table
    /// 
    /// Matrix of rule id to transitioning action state
    /// </summary>
    public class GotoTable
    {
        /// Goto tsble
        private readonly int[][] gotoTable;

        /// <summary>
        /// Initializes a new instance of the <see cref="GotoTable" /> class
        /// </summary>
        /// <param name="rows">The number of rows</param>
        /// <param name="cols">The number of columns</param>
        /// <param name="defValue">The default value to fill in the matrix with defaults to 0</param>
        public GotoTable(int rows, int cols, int defValue = 0)
        {
            gotoTable = new int[rows][];

            for (int i = 0; i < rows; ++i)
            {
                // Create row vector
                var arr = new int[cols];

                // Fill vector with default value
                Array.Fill(arr, defValue);
                gotoTable[i] = arr;
            }
        }

        /// Indexer for goto table
        public int this[int symbol, int index]
        {
            get {
                return gotoTable[symbol][index];
            }
            set {
                gotoTable[symbol][index] = value;
            }
        }
    }
}