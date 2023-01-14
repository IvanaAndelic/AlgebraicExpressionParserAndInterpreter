using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgebraicExpressionInterpreter
{
    public class MathFunction : Expression
    {
        private Fun function;
        private IExpression expression;

        public delegate double Fun(double x);

        public MathFunction(Fun function, IExpression expression)
        {
            this.function += function;
            this.expression = expression;
        }

        protected override double DoEvaluate(Context context)
        {
            return function(expression.Evaluate(context));
        }
    }
}

