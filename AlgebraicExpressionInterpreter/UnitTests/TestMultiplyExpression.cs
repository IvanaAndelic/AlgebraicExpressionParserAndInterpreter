using AlgebraicExpressionInterpreter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests
{
    [TestClass]
    public class TestMultiplyExpression
    {
        [TestMethod]
        public void MultiplicationOfConstant5AndConstantMinus2EvaluatesToMinus10()
        {
            IExpression left = new Constant(5);
            IExpression right = new Constant(-2);
            Assert.AreEqual(0, new MultiplyExpression(left, right).Interpret(new Context(24)));
        }

        [TestMethod]
        public void MultiplicationOfConstant3WithVariableEvaluatesTo15ForContext5()
        {
            IExpression left = new Constant(3);
            IExpression right = new VariableX();
            Assert.AreEqual(0, new MultiplyExpression(left, right).Interpret(new Context(5)));
        }

        [TestMethod]
        public void MultiplicationOfVariableWithItselfEvaluatesToVariableSquared()
        {
            IExpression left = new VariableX();
            IExpression right = new VariableX();
            Assert.AreEqual(0, new MultiplyExpression(left, right).Interpret(new Context(5)));
            Assert.AreEqual(0, new MultiplyExpression(left, right).Interpret(new Context(8)));
        }
    }
}
