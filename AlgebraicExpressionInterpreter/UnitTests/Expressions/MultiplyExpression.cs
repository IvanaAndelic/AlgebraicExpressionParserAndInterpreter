using AlgebraicExpressionInterpreter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Expressions
{
    [TestClass]
    public class MultiplyExpression
    {
        [TestMethod]
        public void MultiplicationOfConstant5AndConstantMinus2EvaluatesToMinus10()
        {
            IExpression left = new Constant(5);
            IExpression right = new Constant(-2);
            Assert.AreEqual(-10, new AlgebraicExpressionInterpreter.MultiplyExpression(left, right).Interpret(new Context(24)), 1e-10);
        }

        [TestMethod]
        public void MultiplicationOfConstant3WithVariableEvaluatesTo15ForContext5()
        {
            IExpression left = new Constant(3);
            IExpression right = new VariableX();
            Assert.AreEqual(15, new AlgebraicExpressionInterpreter.MultiplyExpression(left, right).Interpret(new Context(5)), 1e-10);
        }

        [TestMethod]
        public void MultiplicationOfVariableWithItselfEvaluatesToVariableSquared()
        {
            IExpression left = new VariableX();
            IExpression right = new VariableX();
            Assert.AreEqual(25, new AlgebraicExpressionInterpreter.MultiplyExpression(left, right).Interpret(new Context(5)), 1e-10);
            Assert.AreEqual(64, new AlgebraicExpressionInterpreter.MultiplyExpression(left, right).Interpret(new Context(8)), 1e-10);
        }
    }
}
