using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParserLib.Grammar;

namespace ParserTest.Grammar
{
    using State = ActionTable.State;

    [TestClass]
    public class ActionTableTest
    {
        [TestMethod]
        public void Initialize_Succeeds()
        {
            var instance = new ActionTable(0);
            Assert.IsNotNull(instance);
        }

        
        [TestMethod]
        public void Fetch_NonSetAction_ReturnsError()
        {
            var result = new ActionTable(1)["#", 0];
            Assert.AreEqual(State.ERROR, result.Type);
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(0)]
        [DataRow(-1)]
        public void Fetch_InvalidCol_ReturnsError(int index)
        {
            var result = new ActionTable(0)["#", index];
            Assert.AreEqual(State.ERROR, result.Type);
        }

        [TestMethod]
        public void Set_NonInitRow_CreatesRow()
        {
            var actionTable = new ActionTable(1);
            actionTable.Shift("#", 0, 0);

            var result = actionTable["#", 0];
            Assert.AreEqual(State.SHIFT, result.Type);
        }

        [TestMethod]
        public void Shift_AddsToMatrix()
        {
            var actionTable = new ActionTable(1);
            actionTable.Shift("#", 0, 0);

            var result = actionTable["#", 0];
            Assert.AreEqual(State.SHIFT, result.Type);
        }

        [TestMethod]
        public void Accepted_AddsToMatrix()
        {
            var actionTable = new ActionTable(1);
            actionTable.Accept("#", 0);
            
            var result = actionTable["#", 0];
            Assert.AreEqual(State.ACCEPTED, result.Type);
        }

        [TestMethod]
        public void Reduce_AddsToMatrix()
        {
            var actionTable = new ActionTable(1);
            actionTable.Reduce("#", 0, 0);
            
            var result = actionTable["#", 0];
            Assert.AreEqual(State.REDUCE, result.Type);
        }

        [TestMethod]
        [DataRow(1, State.ACCEPTED)]
        [DataRow(2, State.ERROR)]
        [DataRow(3, State.SHIFT)]
        [DataRow(4, State.REDUCE)]
        public void SetAction_Checks(int value, State type)
        {
            var actionTable = new ActionTable(1);
            var result = actionTable.SetAction("#", 0, value, type);
            Assert.AreEqual(type,  result.Type);
            Assert.AreEqual(value, result.State);
        }
    }
}