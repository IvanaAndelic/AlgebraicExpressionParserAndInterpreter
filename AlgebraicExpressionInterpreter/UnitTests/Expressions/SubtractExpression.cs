using AlgebraicExpressionInterpreter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Expressions
{
    [TestClass]
    public class SubtractExpression
    {
        [TestMethod]
        public void SubtractExpressionInterpretForTwoConstantsReturnsTheirDifference()
        {
            Constant left = new Constant(16);
            Constant right = new Constant(4);
            var difference= new AlgebraicExpressionInterpreter.SubtractExpression(left, right);

            Context context = new Context(5);
            Assert.AreEqual(12, difference.Evaluate(context), 1e-10);
        }

        [TestMethod]
        public void SubtractExpressionInterpretForConstantsAndVariableReturnsTheirDifference()
        {
            IExpression left = new VariableX();
            IExpression right = new Constant(5);
            var difference= new AlgebraicExpressionInterpreter.SubtractExpression(left, right);

            Context context = new Context(3);
            Assert.AreEqual(-2, difference.Evaluate(context), 1e-10);
        }

        [TestMethod]
        public void SubtractExpressionInterpretForTwoVariablesReturnsTheirDifference()
        {
            IExpression left = new VariableX();
            IExpression right = new VariableX();
            var difference= new AlgebraicExpressionInterpreter.SubtractExpression(left, right);

            Context context = new Context(4);
            Assert.AreEqual(0, difference.Evaluate(context), 1e-10);
        }
    }
}
