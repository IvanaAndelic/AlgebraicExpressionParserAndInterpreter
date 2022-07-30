using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgebraicExpressionInterpreter
{
    public class PowerExpression : Expression
    {
        private readonly IExpression @base;
        private readonly IExpression exponent;

        public PowerExpression(IExpression @base, IExpression exponent)
        {
            this.@base = @base;
            this.exponent = exponent;
        }
        protected override double DoInterpret(Context context)
        {
            return Math.Pow(@base.Interpret(context), exponent.Interpret(context));
        }
    }
}
