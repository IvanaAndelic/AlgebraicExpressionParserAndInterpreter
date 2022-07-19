﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgebraicExpressionInterpreter
{
    public interface IExpression
    {
        double Interpret(Context context);

        void ToggleSign();
    }
}