using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using AlgebraicExpressionParser;
using AlgebraicExpressionInterpreter;

namespace UnitTests
{
    [TestClass]
    public class TestParserForConstants
    {
        [TestMethod]
        public void ParseMethodReturnsExpressionForAnExpressionConsistingOfThatValueOnly()
        {
            var parser = new Parser();
            Assert.AreEqual(2, parser.Parse("2").Interpret(new Context(5)));
            Assert.AreEqual(10.3, parser.Parse("10.3").Interpret(new Context(5)));
        }

        [TestMethod]
        public void ParseMethodReturnsExpressionForAnExpressionConsistingOfThatValueOnlyPrecededBySpace()
        {
            var parser = new Parser();
            Assert.AreEqual(5, parser.Parse(" 5").Interpret(new Context(5)));
        }

        [TestMethod]
        public void ParseMethodReturnsExpressionForAnExpressionConsistingOfThatValueOnlyFollowedBySpace()
        {
            var parser = new Parser();
            Assert.AreEqual(7, parser.Parse("7 ").Interpret(new Context(5)));
        }

        [TestMethod]
        public void ParseMethodReturnsExpressionForAnExpressionConsistingOfThatValueOnlyEnclosedInParentheses()
        {
            var parser = new Parser();
            Assert.AreEqual(7, parser.Parse("(7)").Interpret(new Context(5)));
            Assert.AreEqual(7.3, parser.Parse("( 7.3 )").Interpret(new Context(5)));
            Assert.AreEqual(7.5, parser.Parse(" ( 7.5 ) ").Interpret(new Context(5)));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidExpressionException))]
        public void ParseMethodThrowsExceptionIfMinusSignIsNotImmediatellyBeforeConstant()
        {
            var parser = new Parser();
            parser.Parse("- 723");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidExpressionException))]
        public void ParseMethodThrowsExceptionIfPlusSignIsNotImmediatellyBeforeConstant()
        {
            var parser = new Parser();
            parser.Parse("+ 723");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidExpressionException))]
        public void ParseMethodThrowsExceptionForMultipleDecimalSeparators()
        {
            var parser = new Parser();
            parser.Parse("7..23");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidExpressionException))]
        public void ParseThrowsExceptionForConstantFollowedByCharacter()
        {
            var parser = new Parser();
            parser.Parse("7.23a");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidExpressionException))]
        public void ParseMethodThrowsExceptionForConstantInExponentialFormat()
        {
            var parser = new Parser();
            Assert.AreEqual(10.3e5, parser.Parse("10e5").Interpret(new Context(5)));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidExpressionException))]
        public void ParseMethodThrowsExceptionForExpressionStartingWithRightParenthesis()
        {
            var parser = new Parser();
            parser.Parse(")");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidExpressionException))]
        public void ParseMethodThrowsExceptionForRightParenthesisAfterConstant()
        {
            var parser = new Parser();
            parser.Parse("1.23 )");
        }

        [TestMethod]
        public void ParseMethodEvaluatesToSumOfTwoConstants()
        {
            var parser = new Parser();
            Assert.AreEqual(5, parser.Parse("2+3").Interpret(new Context(5)));
            Assert.AreEqual(5, parser.Parse("2 +3").Interpret(new Context(5)));
            Assert.AreEqual(5, parser.Parse("2+ 3").Interpret(new Context(5)));
        }

        [TestMethod]
        public void ParseMethodEvaluatesToDifferenceOfTwoConstants()
        {
            var parser = new Parser();
            Assert.AreEqual(-1, parser.Parse("2-3").Interpret(new Context(5)));
            Assert.AreEqual(1, parser.Parse("3 - 2").Interpret(new Context(5)));
        }

        [TestMethod]
        public void ParseMethodEvaluatesToProductOfTwoConstants()
        {
            var parser = new Parser();
            Assert.AreEqual(6, parser.Parse("2*3").Interpret(new Context(5)));
            Assert.AreEqual(6, parser.Parse("3 * 2").Interpret(new Context(5)));
        }

        [TestMethod]
        public void ParseMethodEvaluatesToQuotientOfTwoConstants()
        {
            var parser = new Parser();
            Assert.AreEqual(2/3.0, parser.Parse("2 / 3").Interpret(new Context(5)), 1e-10);
            Assert.AreEqual(2.5, parser.Parse("5 / 2").Interpret(new Context(5)));
        }

        [TestMethod]
        public void ParseMethodEvaluatesResultOfSeveralOperationsOfSamePrecedenceOnConstants()
        {
            var parser = new Parser();
            Assert.AreEqual(18, parser.Parse("2 + 3 + 13").Interpret(new Context(5)));
            Assert.AreEqual(-7, parser.Parse("2 + 3 - 12").Interpret(new Context(5)));
            Assert.AreEqual(6/4.0, parser.Parse("2 * 3 / 4").Interpret(new Context(5)));
        }

        [TestMethod]
        public void ParseMethodEvaluatesResultOfSeveralOperationsOfDifferentPrecedenceOnConstants()
        {
            var parser = new Parser();
            Assert.AreEqual(10, parser.Parse("2 * 3 + 4").Interpret(new Context(5)));
            Assert.AreEqual(10, parser.Parse("4 * 3 - 2").Interpret(new Context(5)));
            Assert.AreEqual(-10, parser.Parse("2 - 3 * 4").Interpret(new Context(5)));
            Assert.AreEqual(-15, parser.Parse("2 - 3 * 4 - 5").Interpret(new Context(5)));
            Assert.AreEqual(-58, parser.Parse("2 - 3 * 4 * 5").Interpret(new Context(5)));
        }

        [TestMethod]
        public void ParseMethodReturnsExpressionForAnExpressionConsistingOfOperationsOnConstantsEnclosedInParentheses()
        {
            var parser = new Parser();
            Assert.AreEqual(10, parser.Parse("(7 + 3)").Interpret(new Context(5)));
        }

        [TestMethod]
        public void ParseMethodReturnsExpressionForAnExpressionConsistingOfOperationsOnConstantsWithMultipleParentheses()
        {
            var parser = new Parser();
            Assert.AreEqual(-15, parser.Parse("(2 + 3) * (4 - 7)").Interpret(new Context(5)));
            Assert.AreEqual(20, parser.Parse("5 - (2 + 3) * (4 - 7)").Interpret(new Context(5)));
            Assert.AreEqual(-22, parser.Parse("5 - (2 + 3) * 6 - (4 - 7)").Interpret(new Context(5)));
        }
    }
}
