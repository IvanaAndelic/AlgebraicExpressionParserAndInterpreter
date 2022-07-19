using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using AlgebraicExpressionParser;
using AlgebraicExpressionInterpreter;

namespace UnitTests
{
    [TestClass]
    public class TestParserForEntriesWithSign
    {
        [TestMethod]
        public void ParseMethodEvaluatesToNegativeValueIfConstantIsPrecededWithMinusSign()
        {
            var parser = new Parser();
            Assert.AreEqual(-10.3, parser.Parse("-10.3").Interpret(new Context(5)), 1e-10);
        }

        [TestMethod]
        public void ParseMethodEvaluatesToValueIfConstantIsPrecededWithPlusSign()
        {
            var parser = new Parser();
            Assert.AreEqual(21.32, parser.Parse("+21.32").Interpret(new Context(5)), 1e-10);
        }

        [TestMethod]
        public void ParseMethodEvaluatesToNegativeValueIfVariableIsPrecededWithMinusSign()
        {
            var parser = new Parser();
            Assert.AreEqual(-5, parser.Parse("-x").Interpret(new Context(5)), 1e-10);
        }

        [TestMethod]
        public void ParseMethodEvaluatesToValueIfVariableIsPrecededWithPlusSign()
        {
            var parser = new Parser();
            Assert.AreEqual(5, parser.Parse("+x").Interpret(new Context(5)), 1e-10);
        }

        [TestMethod]
        public void ParseMethodEvaluatesFunctionPrecededWithMinusSign()
        {
            var parser = new Parser();
            Assert.AreEqual(-5, parser.Parse("-sqrt(x)").Interpret(new Context(25)), 1e-10);
        }

        [TestMethod]
        public void ParseMethodEvaluatesExpressionInParenthesesPrecededWithMinusSign()
        {
            var parser = new Parser();
            Assert.AreEqual(1, parser.Parse("-(3 - x)").Interpret(new Context(4)), 1e-10);
            Assert.AreEqual(-1, parser.Parse("+(x - 3)").Interpret(new Context(2)), 1e-10);
        }

        [TestMethod]
        public void ParseMethodEvaluatesExpressionConsistingOfMultipleEntriesWithSign()
        {
            var parser = new Parser();
            Assert.AreEqual(-1, parser.Parse("-3 - -x - +2").Interpret(new Context(4)), 1e-10);
            Assert.AreEqual(-1, parser.Parse("-3--x-+2").Interpret(new Context(4)), 1e-10);
            Assert.AreEqual(-21, parser.Parse("-15 - -3 * -x").Interpret(new Context(2)), 1e-10);
            Assert.AreEqual(-21, parser.Parse("-15--3*-x").Interpret(new Context(2)), 1e-10);
            Assert.AreEqual(-7, parser.Parse("-(-x--3)*-(-4 + x)-5").Interpret(new Context(2)), 1e-10);
            Assert.AreEqual(7, parser.Parse("-(-(-x--3)*-(-4 + x)-5)").Interpret(new Context(2)), 1e-10);
        }

        [TestMethod]
        public void ParseMethodEvaluatesEvaluatesFunctionPrecededWithPlusSign()
        {
            var parser = new Parser();
            Assert.AreEqual(-3, parser.Parse("-sqrt(x)").Interpret(new Context(9)), 1e-10);
            Assert.AreEqual(-3, parser.Parse("-sqrt(-x)").Interpret(new Context(-9)), 1e-10);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidExpressionException))]
        public void ParseMethodThrowsExceptionForMultipleMinusSigns()
        {
            var parser = new Parser();
            parser.Parse("--723");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidExpressionException))]
        public void ParseMethodThrowsExceptionForMultiplePlusSigns()
        {
            var parser = new Parser();
            parser.Parse("++723");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidExpressionException))]
        public void ParseMethodThrowsExceptionForPlusAndMinusSignsPecedingConstant()
        {
            var parser = new Parser();
            parser.Parse("+-723");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidExpressionException))]
        public void ParseMethodThrowsExceptionForMinusAndPlusSignsPecedingConstant()
        {
            var parser = new Parser();
            parser.Parse("-+723");
        }
    }
}
