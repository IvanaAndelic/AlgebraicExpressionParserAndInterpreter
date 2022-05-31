using AlgebraicExpressionInterpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgebraicExpressionParser
{
    public class Parser:IExpression
    {

        enum ExpressionParserState
        {
            SkippingWhiteSpacesBeforeOperator,
            SkippingWhiteSpacesAfterOperator,
            ReadingOperator, 
            ReadingConstant, 
            ReadingVariable, 
            ReadingMathFunction
        }
        enum Sign
        {
            Positive, 
            Negative
        }

        static void Parse(string expression)
        {
            ExpressionParserState state = ExpressionParserState.SkippingWhiteSpacesAfterOperator;
            Sign currentSign = Sign.Positive;
            List<IExpression> expressionList = new List<IExpression>();

            for(int i = 0; i < expression.Length; ++i)
            {
                switch (state)
                {
                    case ExpressionParserState.SkippingWhiteSpacesAfterOperator:
                        i = SkipWhiteSpaces(expression, i);
                        switch (expression[i])
                        {
                            case '-':
                                //TODO:set flag the expression is negative
                                currentSign = Sign.Negative;
                                ++i;
                                break;
                            case '+':
                                currentSign = Sign.Positive;
                                ++i;
                                break;
                            default:
                                currentSign = Sign.Positive;
                                break;
                        }
                        state = GetNextState(expression, i);
                        break;

                    case ExpressionParserState.ReadingVariable:
                        //TODO: create VariableX and add it to object list (take care of current sign) 
                        expressionList.Add(new VariableX());
                        state = ExpressionParserState.SkippingWhiteSpacesBeforeOperator;
                        break;
                    case ExpressionParserState.ReadingConstant:
                        int end = ReadConstant(expression, i);
                        //TODO:create constantExpression and add it to object list (take care of current sign)
                        expressionList.Add(new Constant(expression.Substring(i, end - i)));
                        i = end;
                        state = ExpressionParserState.SkippingWhiteSpacesBeforeOperator;
                        break;
                        

                }

            }
        }

        private static int ReadConstant(string expression, int i)
        {
            int decimalSeparator = 0;
           while(char.IsDigit(expression[i]) || expression[i] == '.')
            {
                if (expression[i] == '.')
                {
                    ++decimalSeparator;
                    if (decimalSeparator > 1)
                        throw Exception();
                }
                ++i;
            }
            return i;
        }

        private static ExpressionParserState GetNextState(string expression, int i)
        {

            if (expression[i] == 'x')
            {
                return ExpressionParserState.ReadingVariable;
            }
            else if ((expression[i]>='A' && expression[i]<='Z')||(expression[i]>='a' && expression[i] <= 'z'))
            {
                return ExpressionParserState.ReadingMathFunction;
            }else if (char.IsDigit(expression[i]))
            {
                return ExpressionParserState.ReadingConstant;
            }
            throw new Exception("Invalid expression"); //TODO: napraviti svoju iznimku
            
        }

        private static int SkipWhiteSpaces(string expression, int i)
        {
            while(expression[i]==' ')
            {
                ++i;
            }
            
            return i;
        }
    }
}
