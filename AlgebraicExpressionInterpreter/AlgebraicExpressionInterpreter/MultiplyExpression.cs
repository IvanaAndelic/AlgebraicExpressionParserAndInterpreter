using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgebraicExpressionInterpreter
{
    public class MultiplyExpression : IExpression
    {
        private readonly IExpression left;
        private readonly IExpression right;

        public MultiplyExpression(IExpression left, IExpression right)
        {
            this.left = left;
            this.right = right;
        }

        public double Interpret(Context context)
        {
            return left.Interpret(context) * right.Interpret(context);
        }
    }
}