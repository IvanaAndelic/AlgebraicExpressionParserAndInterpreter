using AlgebraicExpressionInterpreter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Expressions
{
    [TestClass]
    public class SumExpression
    {
        [TestMethod]
        public void SumExpressionInterpretForTwoConstantsReturnsTheirSum()
        {
            Constant left = new Constant(23);
            Constant right = new Constant(2);
            var sum = new AlgebraicExpressionInterpreter.SumExpression(left, right);

            Context context = new Context(3);
            Assert.AreEqual(25, sum.Interpret(context));
        }

        [TestMethod]
        public void SumExpressionInterpretForConstantsAndVariableReturnsTheirSum()
        {
            IExpression left = new VariableX();
            IExpression right = new Constant(2);
            var sum = new AlgebraicExpressionInterpreter.SumExpression(left, right);

            Context context = new Context(3);
            Assert.AreEqual(5, sum.Interpret(context));
            Assert.AreEqual(7, sum.Interpret(new Context(5)));
        }

        [TestMethod]
        public void SumExpressionInterpretForTwoVariablesReturnsTheirSum()
        {
            IExpression left = new VariableX();
            IExpression right = new VariableX();
            var sum = new AlgebraicExpressionInterpreter.SumExpression(left, right);

            Context context = new Context(4);
            Assert.AreEqual(8, sum.Interpret(context));
        }

        [TestMethod]
        public void SumExpressionInterpretForTwoVariablesReturnsTheirSum2()
        {
            IExpression first = new VariableX();
            IExpression second = new Constant(2);
            IExpression third = new Constant(5);

            var sum = new AlgebraicExpressionInterpreter.SumExpression(second, third);
            var multi = new AlgebraicExpressionInterpreter.MultiplyExpression(first, sum);

            Context context = new Context(4);
            Assert.AreEqual(28, multi.Interpret(context));
        }
    }
}
