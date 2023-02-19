using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionGridView
{
    /// <summary>
    ///   Exception thrown by <c>EvaluateVerticalAndHorizontalGridPositionsMethod</c>.
    /// </summary>
    public class EvaluateGridPositionsException:Exception
    {
        public EvaluateGridPositionsException(string message)
            :base(message)
        {

        }

    }
}
