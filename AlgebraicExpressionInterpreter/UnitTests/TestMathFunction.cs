using AlgebraicExpressionInterpreter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests
{
    [TestClass]
    public class TestMathFunction
    {
        [TestMethod]
        public void MathFunctionOfSinReturns1ForPiHalfConstant()
        {
            IExpression piHalf = new Constant(Math.PI / 2.0);
            IExpression mathFun = new MathFunction(Math.Sin, piHalf);
            Assert.AreEqual(1.0, mathFun.Interpret(new Context(3)), 1e-5);
        }

        [TestMethod]
        public void MathFunctionOfSinReturns0ForPiConstant()
        {
            IExpression x = new VariableX();
            IExpression mathFun = new MathFunction(Math.Sin, x);
            Assert.AreEqual(0, mathFun.Interpret(new Context(Math.PI)), 1e-10);
        }

        [TestMethod]
        public void MathFunctionOfSqrtReturnsCorrectValueFor2()
        {
            IExpression argument = new VariableX();
            IExpression mathFun = new MathFunction(Math.Sqrt, argument);
            Assert.AreEqual(Math.Sqrt(2.0), mathFun.Interpret(new Context(2)));
        }

        [TestMethod]
        public void MathFunctionSinOfSqrtReturnsCorrectValueFor2()
        {
            IExpression x = new VariableX();
            IExpression xPlus2 = new SumExpression(x, new Constant(2));
            IExpression sqrtFun = new MathFunction(Math.Sqrt, xPlus2);
            IExpression sinFun = new MathFunction(Math.Sin, sqrtFun);
            Assert.AreEqual(Math.Sqrt(2), sinFun.Interpret(new Context(2)));
        }

        [TestMethod]
        public void MathFunctionOfCosReturnsMinus1ForPiConstant()
        {
            IExpression pi = new Constant(Math.PI);
            IExpression mathFun = new MathFunction(Math.Cos, pi);
            Assert.AreEqual(-1.0, mathFun.Interpret(new Context(Math.PI)));
        }

        [TestMethod]
        public void MathFunctionOfCosReturns0ForPiHalfConstant()
        {
            IExpression piHalf = new Constant(Math.PI);
            IExpression mathFun = new MathFunction(Math.Cos, piHalf);
            Assert.AreEqual(0, mathFun.Interpret(new Context(Math.PI)));
        }

        [TestMethod]
        public void MathFunctionOfCosReturns1ForZeroConstant()
        {
            IExpression zero = new Constant(0);
            IExpression mathFun = new MathFunction(Math.Cos, zero);
            Assert.AreEqual(1, mathFun.Interpret(new Context(0)));
        }

        [TestMethod]
        public void MathFunctionCosOfSqrtReturnsCorrectValueFor2()
        {
            IExpression x = new VariableX();
            IExpression xPlus2 = new SumExpression(x, new Constant(2));
            IExpression sqrtFun = new MathFunction(Math.Sqrt, xPlus2);
            IExpression cosFun = new MathFunction(Math.Cos, sqrtFun);
            Assert.AreEqual(Math.Sqrt(2), cosFun.Interpret(new Context(2)));
        }
    }
}
