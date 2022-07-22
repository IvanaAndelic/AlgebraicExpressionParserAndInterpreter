using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using AlgebraicExpressionParser;
using AlgebraicExpressionInterpreter;

namespace UnitTests
{
    [TestClass]
    public class TestParserForParentheses
    {
        [TestMethod]
        public void ParseMethodReturnsValidExpressionForSingleParentheses()
        {
            var parser = new Parser();
            Assert.AreEqual(2, parser.Parse("(2)").Interpret(new Context(5)), 1e-10);
            Assert.AreEqual(0.3, parser.Parse("(10.3 - x * 2)").Interpret(new Context(5)), 1e-10);
        }

        [TestMethod]
        public void ParseMethodReturnsValidExpressionForMultipleParentheses()
        {
            var parser = new Parser();
            Assert.AreEqual(2, parser.Parse("((2))").Interpret(new Context(5)), 1e-10);
            Assert.AreEqual(2, parser.Parse("(((2)))").Interpret(new Context(5)), 1e-10);
            Assert.AreEqual(0.3, parser.Parse("((10.3 - x * 2))").Interpret(new Context(5)), 1e-10);
            Assert.AreEqual(0.3, parser.Parse("(((10.3 - x * 2)))").Interpret(new Context(5)), 1e-10);
            Assert.AreEqual(5.3, parser.Parse("(((10.3 - x * 2))) + (x)").Interpret(new Context(5)), 1e-10);
            Assert.AreEqual(4.7, parser.Parse("((x) - (((10.3 - x * 2))))").Interpret(new Context(5)), 1e-10);
            Assert.AreEqual(4.7, parser.Parse("(((x) - (((10.3 - x * 2)))))").Interpret(new Context(5)), 1e-10);
        }

        [TestMethod]
        public void ParseMethodReturnsExpressionForAnExpressionConsistingOfOperationsOnConstantsWithMultipleParentheses()
        {
            var parser = new Parser();
            Assert.AreEqual(-15, parser.Parse("(2 + 3) * (4 - 7)").Interpret(new Context(5)));
            Assert.AreEqual(20, parser.Parse("5 - (2 + 3) * (4 - 7)").Interpret(new Context(5)));
            Assert.AreEqual(-22, parser.Parse("5 - (2 + 3) * 6 - (4 - 7)").Interpret(new Context(5)));
        }

        [TestMethod]
        public void ParseMethodReturnsExpressionForAnExpressionWithParentheses()
        {
            var parser = new Parser();
            Assert.AreEqual(8 / -5.0, parser.Parse("(x + 3) / (x - 10)").Interpret(new Context(5)));
            Assert.AreEqual(24 / -5.0, parser.Parse("3 * (x + 3) / (x - 10)").Interpret(new Context(5)), 1e-10);
            Assert.AreEqual(25 / -10.0, parser.Parse("(3 * (x + 3) + 1) / (2 * (x - 10))").Interpret(new Context(5)));
        }

        [TestMethod]
        [ExpectedException(typeof(ParserException))]
        public void ParseMethodThrowsExceptionForExpressionStartingWithRightParenthesis()
        {
            var parser = new Parser();
            parser.Parse(")");
        }

        [TestMethod]
        [ExpectedException(typeof(ParserException))]
        public void ParseMethodThrowsExceptionForExpressionWithMissingRightParenthesis()
        {
            var parser = new Parser();
            parser.Parse("((3)");
        }

        [TestMethod]
        [ExpectedException(typeof(ParserException))]
        public void ParseMethodThrowsExceptionForExpressionWithExcesiveRightParenthesis()
        {
            var parser = new Parser();
            parser.Parse("(3))");
        }

        [TestMethod]
        [ExpectedException(typeof(ParserException))]
        public void ParseMethodThrowsExceptionForRightParenthesisAfterConstant()
        {
            var parser = new Parser();
            parser.Parse("1.23 )");
        }

        [TestMethod]
        [ExpectedException(typeof(ParserException))]
        public void ParseMethodThrowsExceptionForRightParenthesisPlacedAfterOperator()
        {
            var parser = new Parser();
            parser.Parse("((3 +) 2)");
        }

        [TestMethod]
        [ExpectedException(typeof(ParserException))]
        public void ParseMethodThrowsExceptionForLeftParenthesisPlacedBeforeOperator()
        {
            var parser = new Parser();
            parser.Parse("(3 (+ 2))");
        }

        [TestMethod]
        [ExpectedException(typeof(ParserException))]
        public void ParseMethodThrowsExceptionForEmptyParentheses()
        {
            var parser = new Parser();
            parser.Parse(" () ");
        }

        [TestMethod]
        [ExpectedException(typeof(ParserException))]
        public void ParseMethodThrowsExceptionForEmptyParenthesesAfterOperator()
        {
            var parser = new Parser();
            parser.Parse("3 + ()");
        }

        [TestMethod]
        [ExpectedException(typeof(ParserException))]
        public void ParseMethodThrowsExceptionForEmptyParenthesesBetweenOperators()
        {
            var parser = new Parser();
            parser.Parse(" 3 + () - 2 ");
        }

        [TestMethod]
        [ExpectedException(typeof(ParserException))]
        public void ParseMethodThrowsExceptionForEmptyParenthesesInsideBinaryOperation()
        {
            var parser = new Parser();
            parser.Parse(" 3 () - 2 ");
        }
    }
}
