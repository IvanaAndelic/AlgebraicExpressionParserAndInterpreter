using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgebraicExpressionInterpreter
{
    public class MathFunction : IExpression
    {
        private Fun function;
        private IExpression expression;

        public delegate double Fun(double x);

        public MathFunction(Fun function, IExpression expression)
        {
            this.function += function;
            this.expression = expression;
        }

        public double Interpret(Context context)
        {
            return function(expression.Interpret(context));
        }
    }
}

