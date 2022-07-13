using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgebraicExpressionInterpreter
{
    public class VariableX : IExpression
    {
        public VariableX(bool isPositive = true)
        {
            this.isPositive = isPositive;
        }
        public double Interpret(Context context)
        {
            if (isPositive)
            { 
                return context.X;
            }
            return -context.X;
        }

        private readonly bool isPositive;
    }
}