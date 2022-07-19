using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgebraicExpressionInterpreter
{
    public class VariableX : Expression
    {
        public VariableX()
        {
        }
        protected override double DoInterpret(Context context)
        {
            return context.X;
        }
    }
}