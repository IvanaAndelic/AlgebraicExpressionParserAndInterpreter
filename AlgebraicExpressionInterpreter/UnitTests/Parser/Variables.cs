using AlgebraicExpressionInterpreter;
using AlgebraicExpressionParser;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Parser
{
    [TestClass]
    public class Variable
    {
        [TestMethod]
        public void ParseMethodReturnsExpressionForASimpleVariable()
        {
            var parser = new AlgebraicExpressionParser.Parser();
            Assert.AreEqual(5, parser.Parse("x").Evaluate(new Context(5)));
            Assert.AreEqual(-3, parser.Parse("-x").Evaluate(new Context(3)));
            Assert.AreEqual(-3, parser.Parse("x").Evaluate(new Context(-3)));

            Assert.AreEqual(-3, parser.Parse(" -x").Evaluate(new Context(3)));
        }

        [TestMethod]
        [ExpectedException(typeof(ParserException))]
        public void ParseMethodThrowsExceptionIfVariableNamehasAdditionalCharacters()
        {
            var parser = new AlgebraicExpressionParser.Parser();
            parser.Parse("xx");
        }

        [TestMethod]
        [ExpectedException(typeof(ParserException))]
        public void ParseMethodThrowsExceptionIfMinusSignIsNotImmediatellyBeforeVariable()
        {
            var parser = new AlgebraicExpressionParser.Parser();
            parser.Parse("- x");
        }

        [TestMethod]
        [ExpectedException(typeof(ParserException))]
        public void ParseMethodThrowsExceptionIfPlusSignIsNotImmediatellyBeforeVariable()
        {
            var parser = new AlgebraicExpressionParser.Parser();
            parser.Parse("+ x");
        }

        [TestMethod]
        public void ParseMethodReturnsExpressionForAdditionOfVariableAndConstant()
        {
            var parser = new AlgebraicExpressionParser.Parser();
            Assert.AreEqual(8, parser.Parse("x+3").Evaluate(new Context(5)));
            Assert.AreEqual(6, parser.Parse("3+x").Evaluate(new Context(3)));
            Assert.AreEqual(7, parser.Parse("-x+4").Evaluate(new Context(-3)));
        }

        [TestMethod]
        public void ParseMethodReturnsExpressionForSubtractionOfVariableAndConstant()
        {
            var parser = new AlgebraicExpressionParser.Parser();
            Assert.AreEqual(2, parser.Parse("x-3").Evaluate(new Context(5)));
            Assert.AreEqual(0, parser.Parse("3-x").Evaluate(new Context(3)));
            Assert.AreEqual(1, parser.Parse("4--x").Evaluate(new Context(-3)));
        }

        [TestMethod]
        public void ParseMethodReturnsExpressionForMultiplicationOfVariableAndConstant()
        {
            var parser = new AlgebraicExpressionParser.Parser();
            Assert.AreEqual(15, parser.Parse("x*3").Evaluate(new Context(5)));
            Assert.AreEqual(9, parser.Parse("3*x").Evaluate(new Context(3)));
            Assert.AreEqual(-9, parser.Parse("-3*x").Evaluate(new Context(3)));
            Assert.AreEqual(12, parser.Parse("4*-x").Evaluate(new Context(-3)));
        }

        [TestMethod]
        public void ParseMethodReturnsExpressionForDivisionOfVariableAndConstant()
        {
            var parser = new AlgebraicExpressionParser.Parser();
            Assert.AreEqual(5 / 3.0, parser.Parse("x / 3").Evaluate(new Context(5)));
            Assert.AreEqual(1, parser.Parse("3 / x").Evaluate(new Context(3)));
            Assert.AreEqual(-1, parser.Parse("-3 / x").Evaluate(new Context(3)));
            Assert.AreEqual(4 / 3.0, parser.Parse("4 / -x").Evaluate(new Context(-3)));
        }

        [TestMethod]
        public void ParseMethodReturnsExpressionForAdditionOfMultipleVariablesAndConstants()
        {
            var parser = new AlgebraicExpressionParser.Parser();
            Assert.AreEqual(10, parser.Parse("x + x").Evaluate(new Context(5)));
            Assert.AreEqual(13, parser.Parse("x + 3 + x ").Evaluate(new Context(5)));
            Assert.AreEqual(11, parser.Parse("3 + x + x").Evaluate(new Context(4)));
            Assert.AreEqual(10, parser.Parse("-x + -x + 4").Evaluate(new Context(-3)));
        }

        [TestMethod]
        public void ParseMethodReturnsExpressionForSubtractionOfMultipleVariablesAndConstants()
        {
            var parser = new AlgebraicExpressionParser.Parser();
            Assert.AreEqual(3, parser.Parse("x - 3 - x + 6").Evaluate(new Context(5)));
            Assert.AreEqual(-10, parser.Parse("-x - 5 - x - 2 + x").Evaluate(new Context(3)));
        }

        [TestMethod]
        public void ParseMethodReturnsExpressionForMultiplicationOfMultipleVariablesAndConstants()
        {
            var parser = new AlgebraicExpressionParser.Parser();
            Assert.AreEqual(25, parser.Parse("x * x").Evaluate(new Context(5)));
            Assert.AreEqual(-27, parser.Parse("x * x * x").Evaluate(new Context(-3)));
            Assert.AreEqual(3, parser.Parse("3 * x - 2 * x").Evaluate(new Context(3)));
        }

        [TestMethod]
        public void ParseMethodReturnsExpressionForDivisionOfMultipleVariablesAndConstants()
        {
            var parser = new AlgebraicExpressionParser.Parser();
            Assert.AreEqual(1, parser.Parse("x / x").Evaluate(new Context(5)));
            Assert.AreEqual(3, parser.Parse("3 * x / x").Evaluate(new Context(3)));
        }

        [TestMethod]
        public void ParseMethodReturnsExpressionForExpressionWithDifferentOperationsOnVariablesAndConstants()
        {
            var parser = new AlgebraicExpressionParser.Parser();
            Assert.AreEqual(-70, parser.Parse("x - x * 3 * x").Evaluate(new Context(5)));
        }
    }
}
