using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgebraicExpressionInterpreter
{
    public class SumExpression : Expression
    {

        private readonly IExpression left;
        private readonly IExpression right;

        public SumExpression(IExpression left, IExpression right)
        {
            this.left = left;
            this.right = right;
        }

        protected override double DoInterpret(Context context)
        {
            return left.Interpret(context) + right.Interpret(context);
        }
    }
}
