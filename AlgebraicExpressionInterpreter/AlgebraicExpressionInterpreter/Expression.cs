using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgebraicExpressionInterpreter
{
    public abstract class Expression : IExpression
    {
        public double Interpret(Context context)
        {
            if (isPositive)
                return DoInterpret(context);
            return -DoInterpret(context);
        }

        protected abstract double DoInterpret(Context context);

        public void ToggleSign()
        {
            isPositive = !isPositive;
        }

        bool isPositive = true;
    }
}
