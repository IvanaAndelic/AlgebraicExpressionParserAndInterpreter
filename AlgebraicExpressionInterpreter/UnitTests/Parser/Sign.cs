using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using AlgebraicExpressionParser;
using AlgebraicExpressionInterpreter;

namespace Parser
{
    [TestClass]
    public class Sign
    {
        [TestMethod]
        public void ParseMethodEvaluatesToNegativeValueIfConstantIsPrecededWithMinusSign()
        {
            var parser = new AlgebraicExpressionParser.Parser();
            Assert.AreEqual(-10.3, parser.Parse("-10.3").Evaluate(new Context(5)), 1e-10);
        }

        [TestMethod]
        public void ParseMethodEvaluatesToValueIfConstantIsPrecededWithPlusSign()
        {
            var parser = new AlgebraicExpressionParser.Parser();
            Assert.AreEqual(21.32, parser.Parse("+21.32").Evaluate(new Context(5)), 1e-10);
        }

        [TestMethod]
        public void ParseMethodEvaluatesToNegativeValueIfVariableIsPrecededWithMinusSign()
        {
            var parser = new AlgebraicExpressionParser.Parser();
            Assert.AreEqual(-5, parser.Parse("-x").Evaluate(new Context(5)), 1e-10);
        }

        [TestMethod]
        public void ParseMethodEvaluatesToValueIfVariableIsPrecededWithPlusSign()
        {
            var parser = new AlgebraicExpressionParser.Parser();
            Assert.AreEqual(5, parser.Parse("+x").Evaluate(new Context(5)), 1e-10);
        }

        [TestMethod]
        public void ParseMethodEvaluatesFunctionPrecededWithMinusSign()
        {
            var parser = new AlgebraicExpressionParser.Parser();
            Assert.AreEqual(-5, parser.Parse("-sqrt(x)").Evaluate(new Context(25)), 1e-10);
        }

        [TestMethod]
        public void ParseMethodEvaluatesExpressionInParenthesesPrecededWithMinusSign()
        {
            var parser = new AlgebraicExpressionParser.Parser();
            Assert.AreEqual(1, parser.Parse("-(3 - x)").Evaluate(new Context(4)), 1e-10);
            Assert.AreEqual(-1, parser.Parse("+(x - 3)").Evaluate(new Context(2)), 1e-10);
        }

        [TestMethod]
        public void ParseMethodEvaluatesExpressionConsistingOfMultipleEntriesWithSign()
        {
            var parser = new AlgebraicExpressionParser.Parser();
            Assert.AreEqual(-1, parser.Parse("-3 - -x - +2").Evaluate(new Context(4)), 1e-10);
            Assert.AreEqual(-1, parser.Parse("-3--x-+2").Evaluate(new Context(4)), 1e-10);
            Assert.AreEqual(-21, parser.Parse("-15 - -3 * -x").Evaluate(new Context(2)), 1e-10);
            Assert.AreEqual(-21, parser.Parse("-15--3*-x").Evaluate(new Context(2)), 1e-10);
            Assert.AreEqual(-7, parser.Parse("-(-x--3)*-(-4 + x)-5").Evaluate(new Context(2)), 1e-10);
            Assert.AreEqual(7, parser.Parse("-(-(-x--3)*-(-4 + x)-5)").Evaluate(new Context(2)), 1e-10);
        }

        [TestMethod]
        public void ParseMethodEvaluatesEvaluatesFunctionPrecededWithPlusSign()
        {
            var parser = new AlgebraicExpressionParser.Parser();
            Assert.AreEqual(-3, parser.Parse("-sqrt(x)").Evaluate(new Context(9)), 1e-10);
            Assert.AreEqual(-3, parser.Parse("-sqrt(-x)").Evaluate(new Context(-9)), 1e-10);
        }

        [TestMethod]
        [ExpectedException(typeof(ParserException))]
        public void ParseMethodThrowsExceptionForMultipleMinusSigns()
        {
            var parser = new AlgebraicExpressionParser.Parser();
            parser.Parse("--723");
        }

        [TestMethod]
        [ExpectedException(typeof(ParserException))]
        public void ParseMethodThrowsExceptionForMultiplePlusSigns()
        {
            var parser = new AlgebraicExpressionParser.Parser();
            parser.Parse("++723");
        }

        [TestMethod]
        [ExpectedException(typeof(ParserException))]
        public void ParseMethodThrowsExceptionForPlusAndMinusSignsPecedingConstant()
        {
            var parser = new AlgebraicExpressionParser.Parser();
            parser.Parse("+-723");
        }

        [TestMethod]
        [ExpectedException(typeof(ParserException))]
        public void ParseMethodThrowsExceptionForMinusAndPlusSignsPecedingConstant()
        {
            var parser = new AlgebraicExpressionParser.Parser();
            parser.Parse("-+723");
        }
    }
}
