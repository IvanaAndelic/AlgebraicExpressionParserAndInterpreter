using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using AlgebraicExpressionParser;
using AlgebraicExpressionInterpreter;

namespace UnitTests
{
    [TestClass]
    public class TestParserForPower
    {
        [TestMethod]
        public void ParserReturnsExpressionForPowerWithConstantBaseAndConstantExponent()
        {
            Parser parser = new Parser();
            Assert.AreEqual(125, parser.Parse("5.0 ^ 3.0").Interpret(new Context(5)), 1e-10);
            Assert.AreEqual(0.125, parser.Parse("0.5 ^ 3").Interpret(new Context(5)), 1e-10);
        }

        [TestMethod]
        public void ParserReturnsExpressionForPowerWithVariableBaseAndVariableExponent()
        {
            Parser parser = new Parser();
            Assert.AreEqual(27, parser.Parse("x ^ x").Interpret(new Context(3)), 1e-10);
            Assert.AreEqual(Math.Sqrt(Math.Sqrt(0.25)), parser.Parse("x ^ x").Interpret(new Context(0.25)), 1e-10);
        }

        [TestMethod]
        public void ParserReturnsExpressionForPowerWithBaseAsAComplexExpression()
        {
            Parser parser = new Parser();
            Assert.AreEqual(125, parser.Parse("(2 + 3) ^ x").Interpret(new Context(3)), 1e-10);
            Assert.AreEqual(Math.Sqrt(4), parser.Parse("(x + 3.5) ^ x").Interpret(new Context(0.5)), 1e-10);
        }

        [TestMethod]
        public void ParserReturnsExpressionForPowerWithExponentAsAComplexExpression()
        {
            Parser parser = new Parser();
            Assert.AreEqual(32, parser.Parse("2 ^ (2 + 3)").Interpret(new Context(3)), 1e-10);
            Assert.AreEqual(Math.Pow(3, 1.5), parser.Parse("3 ^ (2 - x)").Interpret(new Context(0.5)), 1e-10);
        }

        [TestMethod]
        public void ParserReturnsExpressionForAComplexOperationsContainingPower()
        {
            Parser parser = new Parser();
            Assert.AreEqual(-16, parser.Parse("2 - 2 ^ x - 10").Interpret(new Context(3)), 1e-10);
            Assert.AreEqual(121.5, parser.Parse("3 * x ^ 4 / 2").Interpret(new Context(3)), 1e-10);
            Assert.AreEqual(4, parser.Parse("2 ^ 0.5 ^ 4").Interpret(new Context(3)), 1e-10); // 3 * 2 ^ -5 ^ 2 * 3 
            Assert.AreEqual(240, parser.Parse("3 * (x - 1) ^ (8 - x * 2) ^ 2 * 5").Interpret(new Context(3)), 1e-10); // 3 * 2 ^ 2 ^ 2 * 3 
            Assert.AreEqual(0.015625, parser.Parse("2 ^ (x - 5) ^ 3").Interpret(new Context(3)), 1e-10); // 2 ^ -2 ^ 3
        }
    }
}
