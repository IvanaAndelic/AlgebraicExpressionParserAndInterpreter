using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgebraicExpressionInterpreter
{
    public class Constant : Expression
    {
        private readonly double value;

        public Constant(double value)
        {
            this.value = value;
        }

        protected override double DoInterpret(Context context)
        {
            return value;
        }
    }
}