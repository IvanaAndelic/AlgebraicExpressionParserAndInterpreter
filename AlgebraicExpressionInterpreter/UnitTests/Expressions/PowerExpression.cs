using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using AlgebraicExpressionInterpreter;

namespace Expressions
{
    [TestClass]
    public class PowerExpression
    {
        [TestMethod]
        public void PowerExpressionForTwoConstantsReturnsFirstConstantToThePowerOfSecond()
        {
            Constant @base = new Constant(2);
            Constant exponent = new Constant(3);
            var power = new AlgebraicExpressionInterpreter.PowerExpression(@base, exponent);

            Context context = new Context(5);
            Assert.AreEqual(8, power.Interpret(context), 1e-10);

            Assert.AreEqual(-8, new AlgebraicExpressionInterpreter.PowerExpression(new Constant(-2), exponent).Interpret(context), 1e-10);
        }

        [TestMethod]
        public void PowerExpressionForAConstantAndVariableReturnsConstantToThePowerOfVariable()
        {
            Constant @base = new Constant(3);
            VariableX exponent = new VariableX();
            var power = new AlgebraicExpressionInterpreter.PowerExpression(@base, exponent);

            Context context = new Context(3);
            Assert.AreEqual(27, power.Interpret(context), 1e-10);
        }

        [TestMethod]
        public void PowerExpressionForAVariableAndConstantReturnsVariableToThePowerOfConstant()
        {
            Constant @base = new Constant(2);
            VariableX exponent = new VariableX();
            var power = new AlgebraicExpressionInterpreter.PowerExpression(@base, exponent);

            Context context = new Context(-3);
            Assert.AreEqual(0.125, power.Interpret(context), 1e-10);
        }

        [TestMethod]
        public void PowerExpressionForTwoVariablesReturnsVariableToThePowerOfVariable()
        {
            VariableX var = new VariableX();
            var power = new AlgebraicExpressionInterpreter.PowerExpression(var, var);

            Context context = new Context(-2);
            Assert.AreEqual(0.25, power.Interpret(context), 1e-10);
        }
    }
}
