using AlgebraicExpressionInterpreter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Expressions
{
    [TestClass]
    public class DivideExpression
    {
        [TestMethod]
        public void DivisionOfCOnstant3WithConstantEvaluatesTo1Point5()
        {
            IExpression left = new Constant(3);
            IExpression right = new Constant(2);
            Assert.AreEqual(1.5, new AlgebraicExpressionInterpreter.DivideExpression(left, right).Interpret(new Context(24)), 1e-10);
        }

        [TestMethod]
        public void DivisionOfConstant4WithVariableEvaluatesTo0Point5ForContext8()
        {
            IExpression left = new Constant(4);
            IExpression right = new VariableX();
            Assert.AreEqual(0.5, new AlgebraicExpressionInterpreter.DivideExpression(left, right).Interpret(new Context(8)), 1e-10);
        }

        [TestMethod]
        public void DivisionOfVariableWithItselfEvaluatesTo1ForAnyContext()
        {
            IExpression left = new VariableX();
            IExpression right = new VariableX();
            Assert.AreEqual(1, new AlgebraicExpressionInterpreter.DivideExpression(left, right).Interpret(new Context(8)));
            Assert.AreEqual(1, new AlgebraicExpressionInterpreter.DivideExpression(left, right).Interpret(new Context(4)));
        }
    }
}
