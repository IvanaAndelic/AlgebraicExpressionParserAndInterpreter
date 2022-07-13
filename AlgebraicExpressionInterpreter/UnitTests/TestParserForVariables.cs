using AlgebraicExpressionInterpreter;
using AlgebraicExpressionParser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests
{
    [TestClass]
    public class TestParserForVariables
    {
        [TestMethod]
        public void ParseMethodReturnsExpressionForASimpleVariable()
        {
            var parser = new Parser();
            Assert.AreEqual(5, parser.Parse("x").Interpret(new Context(5)));
            Assert.AreEqual(-3, parser.Parse("-x").Interpret(new Context(3)));
            Assert.AreEqual(-3, parser.Parse("x").Interpret(new Context(-3)));

            Assert.AreEqual(-3, parser.Parse(" -x").Interpret(new Context(3)));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidExpressionException))]
        public void ParseMethodThrowsExceptionIfVariableNamehasAdditionalCharacters()
        {
            var parser = new Parser();
            parser.Parse("xx");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidExpressionException))]
        public void ParseMethodThrowsExceptionIfMinusSignIsNotImmediatellyBeforeVariable()
        {
            var parser = new Parser();
            parser.Parse("- x");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidExpressionException))]
        public void ParseMethodThrowsExceptionIfPlusSignIsNotImmediatellyBeforeVariable()
        {
            var parser = new Parser();
            parser.Parse("+ x");
        }

        [TestMethod]
        public void ParseMethodReturnsExpressionForAdditionOfVariableAndConstant()
        {
            var parser = new Parser();
            Assert.AreEqual(8, parser.Parse("x+3").Interpret(new Context(5)));
            Assert.AreEqual(6, parser.Parse("3+x").Interpret(new Context(3)));
            Assert.AreEqual(7, parser.Parse("-x+4").Interpret(new Context(-3)));
        }

        [TestMethod]
        public void ParseMethodReturnsExpressionForSubtractionOfVariableAndConstant()
        {
            var parser = new Parser();
            Assert.AreEqual(2, parser.Parse("x-3").Interpret(new Context(5)));
            Assert.AreEqual(0, parser.Parse("3-x").Interpret(new Context(3)));
            Assert.AreEqual(1, parser.Parse("4--x").Interpret(new Context(-3)));
        }

        [TestMethod]
        public void ParseMethodReturnsExpressionForMultiplicationOfVariableAndConstant()
        {
            var parser = new Parser();
            Assert.AreEqual(15, parser.Parse("x*3").Interpret(new Context(5)));
            Assert.AreEqual(9, parser.Parse("3*x").Interpret(new Context(3)));
            Assert.AreEqual(-9, parser.Parse("-3*x").Interpret(new Context(3)));
            Assert.AreEqual(12, parser.Parse("4*-x").Interpret(new Context(-3)));
        }

        [TestMethod]
        public void ParseMethodReturnsExpressionForDivisionOfVariableAndConstant()
        {
            var parser = new Parser();
            Assert.AreEqual(5 / 3.0, parser.Parse("x / 3").Interpret(new Context(5)));
            Assert.AreEqual(1, parser.Parse("3 / x").Interpret(new Context(3)));
            Assert.AreEqual(-1, parser.Parse("-3 / x").Interpret(new Context(3)));
            Assert.AreEqual(4 / 3.0, parser.Parse("4 / -x").Interpret(new Context(-3)));
        }

        [TestMethod]
        public void ParseMethodReturnsExpressionForAdditionOfMultipleVariablesAndConstants()
        {
            var parser = new Parser();
            Assert.AreEqual(10, parser.Parse("x + x").Interpret(new Context(5)));
            Assert.AreEqual(13, parser.Parse("x + 3 + x ").Interpret(new Context(5)));
            Assert.AreEqual(11, parser.Parse("3 + x + x").Interpret(new Context(4)));
            Assert.AreEqual(10, parser.Parse("-x + -x + 4").Interpret(new Context(-3)));
        }

        [TestMethod]
        public void ParseMethodReturnsExpressionForSubtractionOfMultipleVariablesAndConstants()
        {
            var parser = new Parser();
            Assert.AreEqual(3, parser.Parse("x - 3 - x + 6").Interpret(new Context(5)));
            Assert.AreEqual(-10, parser.Parse("-x - 5 - x - 2 + x").Interpret(new Context(3)));
        }

        [TestMethod]
        public void ParseMethodReturnsExpressionForMultiplicationOfMultipleVariablesAndConstants()
        {
            var parser = new Parser();
            Assert.AreEqual(25, parser.Parse("x * x").Interpret(new Context(5)));
            Assert.AreEqual(-27, parser.Parse("x * x * x").Interpret(new Context(-3)));
            Assert.AreEqual(3, parser.Parse("3 * x - 2 * x").Interpret(new Context(3)));
        }

        [TestMethod]
        public void ParseMethodReturnsExpressionForDivisionOfMultipleVariablesAndConstants()
        {
            var parser = new Parser();
            Assert.AreEqual(1, parser.Parse("x / x").Interpret(new Context(5)));
            Assert.AreEqual(3, parser.Parse("3 * x / x").Interpret(new Context(3)));
        }

        [TestMethod]
        public void ParseMethodReturnsExpressionForExpressionWithDifferentOperationsOnVariablesAndConstants()
        {
            var parser = new Parser();
            Assert.AreEqual(-70, parser.Parse("x - x * 3 * x").Interpret(new Context(5)));
        }

        [TestMethod]
        public void ParseMethodReturnsExpressionForAnExpressionWithParentheses()
        {
            var parser = new Parser();
            Assert.AreEqual(8 / -5.0, parser.Parse("(x + 3) / (x - 10)").Interpret(new Context(5)));
            Assert.AreEqual(24 / -5.0, parser.Parse("3 * (x + 3) / (x - 10)").Interpret(new Context(5)), 1e-10);
            Assert.AreEqual(25 / -10.0, parser.Parse("(3 * (x + 3) + 1) / (2 * (x - 10))").Interpret(new Context(5)));
        }
    }
}
