using AlgebraicExpressionInterpreter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Expressions
{
    [TestClass]
    public class MathFunction
    {
        [TestMethod]
        public void MathFunctionOfSinReturns1ForPiHalfConstant()
        {
            IExpression piHalf = new Constant(Math.PI / 2.0);
            IExpression mathFun = new AlgebraicExpressionInterpreter.MathFunction(Math.Sin, piHalf);
            Assert.AreEqual(1.0, mathFun.Interpret(new Context(3)), 1e-10);
        }

        [TestMethod]
        public void MathFunctionOfSinReturns0ForPiConstant()
        {
            IExpression x = new VariableX();
            IExpression mathFun = new AlgebraicExpressionInterpreter.MathFunction(Math.Sin, x);
            Assert.AreEqual(0, mathFun.Interpret(new Context(Math.PI)), 1e-10);
        }

        [TestMethod]
        public void MathFunctionOfSqrtReturnsCorrectValueFor2()
        {
            IExpression argument = new VariableX();
            IExpression mathFun = new AlgebraicExpressionInterpreter.MathFunction(Math.Sqrt, argument);
            Assert.AreEqual(Math.Sqrt(2.0), mathFun.Interpret(new Context(2)), 1e-10);
        }

        [TestMethod]
        public void MathFunctionSinOfSqrtReturnsCorrectValueFor2()
        {
            IExpression x = new VariableX();
            IExpression xPlus2 = new AlgebraicExpressionInterpreter.SumExpression(x, new Constant(2));
            IExpression sqrtFun = new AlgebraicExpressionInterpreter.MathFunction(Math.Sqrt, xPlus2);
            IExpression sinFun = new AlgebraicExpressionInterpreter.MathFunction(Math.Sin, sqrtFun);
            Assert.AreEqual(Math.Sin(Math.Sqrt(2 + 2)), sinFun.Interpret(new Context(2)), 1e-10);
        }

        [TestMethod]
        public void MathFunctionOfCosReturnsMinus1ForPiConstant()
        {
            IExpression pi = new Constant(Math.PI);
            IExpression mathFun = new AlgebraicExpressionInterpreter.MathFunction(Math.Cos, pi);
            Assert.AreEqual(-1.0, mathFun.Interpret(new Context(Math.PI)), 1e-10);
        }

        [TestMethod]
        public void MathFunctionOfCosReturns0ForPiHalfConstant()
        {
            IExpression piHalf = new Constant(Math.PI / 2);
            IExpression mathFun = new AlgebraicExpressionInterpreter.MathFunction(Math.Cos, piHalf);
            Assert.AreEqual(0, mathFun.Interpret(new Context(Math.PI)), 1e-10);
        }

        [TestMethod]
        public void MathFunctionOfCosReturns1ForZeroConstant()
        {
            IExpression zero = new Constant(0);
            IExpression mathFun = new AlgebraicExpressionInterpreter.MathFunction(Math.Cos, zero);
            Assert.AreEqual(1, mathFun.Interpret(new Context(0)), 1e-10);
        }

        [TestMethod]
        public void MathFunctionCosOfSqrtReturnsCorrectValueFor2()
        {
            IExpression x = new VariableX();
            IExpression xPlus2 = new AlgebraicExpressionInterpreter.SumExpression(x, new Constant(2));
            IExpression sqrtFun = new AlgebraicExpressionInterpreter.MathFunction(Math.Sqrt, xPlus2);
            IExpression cosFun = new AlgebraicExpressionInterpreter.MathFunction(Math.Cos, sqrtFun);
            Assert.AreEqual(Math.Cos(Math.Sqrt(2 + 2)), cosFun.Interpret(new Context(2)), 1e-10);
        }
    }
}
