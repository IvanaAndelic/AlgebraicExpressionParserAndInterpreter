using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgebraicExpressionInterpreter
{
    public abstract class Expression : IExpression
    {
        public double Evaluate(Context context)
        {
            if (isPositive)
                return DoEvaluate(context);
            return -DoEvaluate(context);
        }

        protected abstract double DoEvaluate(Context context);

        public void ToggleSign()
        {
            isPositive = !isPositive;
        }

        bool isPositive = true;
    }
}
