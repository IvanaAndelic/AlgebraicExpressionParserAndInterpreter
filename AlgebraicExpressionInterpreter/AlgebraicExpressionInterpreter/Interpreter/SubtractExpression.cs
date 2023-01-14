using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgebraicExpressionInterpreter
{
    public class SubtractExpression : Expression
    {
        private readonly IExpression left;
        private readonly IExpression right;

        public SubtractExpression(IExpression left, IExpression right)
        {
            this.left = left;
            this.right = right;
        }

        protected override double DoEvaluate(Context context)
        {
            return left.Evaluate(context) - right.Evaluate(context);
        }
    }
}
