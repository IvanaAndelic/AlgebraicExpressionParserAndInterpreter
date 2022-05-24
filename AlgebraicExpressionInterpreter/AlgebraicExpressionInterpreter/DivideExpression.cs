using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgebraicExpressionInterpreter
{
    public class DivideExpression
    {
        private readonly IExpression left;
        private readonly IExpression right;

        public DivideExpression(IExpression left, IExpression right)
        {
            this.left = left;
            this.right = right;
        }

        public double Interpret(Context context)
        {
            if (right.Interpret(context) > 0)
            {
                return left.Interpret(context) / right.Interpret(context);
            }
            else
            {
                return 0;
            }

        }
    }
}
