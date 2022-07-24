using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using AlgebraicExpressionParser;
using AlgebraicExpressionInterpreter;

namespace Parser
{
    [TestClass]
    public class NamedConstant
    {
        [TestMethod]
        public void ParserReturnsValueOfPi()
        {
            var parser = new AlgebraicExpressionParser.Parser();
            Assert.AreEqual(Math.PI, parser.Parse("PI").Interpret(new Context(5)), 1e-10);
            Assert.AreEqual(Math.PI, parser.Parse(" PI ").Interpret(new Context(5)), 1e-10);
        }

        [TestMethod]
        public void ParserEvaluatesExpressionWithPi()
        {
            var parser = new AlgebraicExpressionParser.Parser();
            Assert.AreEqual(-1, parser.Parse("cos(PI)").Interpret(new Context(5)), 1e-10);
        }

        [TestMethod]
        public void ParserReturnsValueOfE()
        {
            var parser = new AlgebraicExpressionParser.Parser();
            Assert.AreEqual(Math.E, parser.Parse("E").Interpret(new Context(5)), 1e-10);
            Assert.AreEqual(Math.E, parser.Parse(" E ").Interpret(new Context(5)), 1e-10);
        }

        [TestMethod]
        public void ParserEvaluatesExpressionWithE()
        {
            var parser = new AlgebraicExpressionParser.Parser();
            Assert.AreEqual(Math.Exp(2), parser.Parse("E ^ 2").Interpret(new Context(5)), 1e-10);
        }

        [TestMethod]
        [ExpectedException(typeof(ParserException))]
        public void ParseMethodThrowsExceptionForUnsupportedNamedConstant()
        {
            var parser = new AlgebraicExpressionParser.Parser();
            parser.Parse(" sin(F) ");
        }
    }
}
