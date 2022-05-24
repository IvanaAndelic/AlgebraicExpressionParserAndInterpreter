using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgebraicExpressionInterpreter
{
    public class VariableX : IExpression
    {
        public double Interpret(Context context)
        {
            return context.X;
        }
    }
}