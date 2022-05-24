using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgebraicExpressionInterpreter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class TestSubtractExpression
    {

        [TestMethod]
        public void SubtractExpressionInterpretForTwoConstantsReturnsTheirDifference()
        {
            Constant left = new Constant("16");
            Constant right = new Constant("4");
            SubtractExpression difference = new SubtractExpression(left, right);

            Context context = new Context(5);
            Assert.AreEqual(12, difference.Interpret(context));
        }

        [TestMethod]
        public void SubtractExpressionInterpretForConstantsAndVariableReturnsTheirDifference()
        {
            IExpression left = new VariableX();
            IExpression right = new Constant("5");
            SubtractExpression difference = new SubtractExpression(left, right);

            Context context = new Context(3);
            Assert.AreEqual(6, difference.Interpret(context));

        }

        [TestMethod]
        public void SubtractExpressionInterpretForTwoVariablesReturnsTheirDifference()
        {
            IExpression left = new VariableX();
            IExpression right = new VariableX();
            SubtractExpression difference = new SubtractExpression(left, right);

            Context context = new Context(4);
            Assert.AreEqual(9, difference.Interpret(context));
        }
    }
}
