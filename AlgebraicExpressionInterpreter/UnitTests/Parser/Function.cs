using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using AlgebraicExpressionParser;
using AlgebraicExpressionInterpreter;


namespace Parser
{
    [TestClass]
    public class Function
    {
        [TestMethod]
        public void ParserReturnsExpressionForSinFunctionWithConstantArgument()
        {
            var parser = new AlgebraicExpressionParser.Parser();
            Assert.AreEqual(1, parser.Parse("sin(1.5707963267948966192313216916398)").Interpret(new Context(5)), 1e-10);
        }

        [TestMethod]
        public void ParserReturnsExpressionForSinFunctionWithVariableArgument()
        {
            var parser = new AlgebraicExpressionParser.Parser();
            Assert.AreEqual(1, parser.Parse("sin(x)").Interpret(new Context(1.5707963267948966192313216916398)), 1e-10);
        }

        [TestMethod]
        public void ParserReturnsExpressionForSinFunctionWithExpressionAsArgument()
        {
            var parser = new AlgebraicExpressionParser.Parser();
            Assert.AreEqual(1, parser.Parse("sin(x + 1)").Interpret(new Context(0.5707963267948966192313216916398)), 1e-10);
            Assert.AreEqual(3, parser.Parse("sqrt(11 - x * 2)").Interpret(new Context(1)), 1e-10);
        }

        [TestMethod]
        public void ParserReturnsExpressionForExpressionWithMultipleFunctions()
        {
            var parser = new AlgebraicExpressionParser.Parser();
            Assert.AreEqual(-4, parser.Parse("sqrt(4) - sqrt(9) * 2").Interpret(new Context(2)), 1e-10);
            Assert.AreEqual(Math.Sqrt(2), parser.Parse("3 * sqrt(x) - sqrt(x) * 2").Interpret(new Context(2)), 1e-10);
            Assert.AreEqual(2, parser.Parse("sin(x / 2) + cos(2 * x)").Interpret(new Context(3.1415926535897932384626433832795)), 1e-10);
            Assert.AreEqual(2, parser.Parse("sin((2 * x) / (2 + 2)) - cos(x - 2 * x)").Interpret(new Context(3.1415926535897932384626433832795)), 1e-10);
            Assert.AreEqual(-1, parser.Parse("sin((2 * x) / (2 + 2)) * cos(x - 2 * x)").Interpret(new Context(3.1415926535897932384626433832795)), 1e-10);
        }

        [TestMethod]
        public void ParserReturnsExpressionForACompositionOfFunctions()
        {
            var parser = new AlgebraicExpressionParser.Parser();
            Assert.AreEqual(Math.Sqrt(2), parser.Parse("sqrt(sin(x / 2) + cos(2 * x))").Interpret(new Context(3.1415926535897932384626433832795)), 1e-10);
        }

        [TestMethod]
        public void ParserReturnsExpressionForFunctionsWithPrecedingSign()
        {
            var parser = new AlgebraicExpressionParser.Parser();
            Assert.AreEqual(-Math.Sqrt(2), parser.Parse("-sqrt(2)").Interpret(new Context(3.1415926535897932384626433832795)), 1e-10);
        }

        [TestMethod]
        [ExpectedException(typeof(ParserException))]
        public void ParseMethodThrowsExceptionForAFunctionWithEmptyParentheses()
        {
            var parser = new AlgebraicExpressionParser.Parser();
            parser.Parse(" sin() ");
        }

        [TestMethod]
        [ExpectedException(typeof(ParserException))]
        public void ParseMethodThrowsExceptionForASignBetweenFunctionNameAndParentheses()
        {
            var parser = new AlgebraicExpressionParser.Parser();
            parser.Parse(" sin-(2) ");
        }

        [TestMethod]
        [ExpectedException(typeof(ParserException))]
        public void ParseMethodThrowsExceptionForMissingRightParenthesesAfterFunction()
        {
            var parser = new AlgebraicExpressionParser.Parser();
            parser.Parse(" sin(2 ");
        }

        [TestMethod]
        [ExpectedException(typeof(ParserException))]
        public void ParseMethodThrowsExceptionForOnlyLeftParenthesisAfterFunction()
        {
            var parser = new AlgebraicExpressionParser.Parser();
            parser.Parse(" sin( ");
        }
    }
}
