using AlgebraicExpressionInterpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgebraicExpressionParser
{
    public class Parser
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

        enum Operator
        {
            Addition,
            Subtraction,
            Multiplication,
            Division
        }

        public IExpression Parse(string expression) //vraca izraz iexpression
        {
            ExpressionParserState state = ExpressionParserState.SkippingWhiteSpacesAfterOperator;
            Sign currentSign = Sign.Positive;
            List<IExpression> expressionList = new List<IExpression>();
            List<Operator> operators = new List<Operator>();

            for (int i = 0; i < expression.Length; ++i)
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
                    case ExpressionParserState.SkippingWhiteSpacesBeforeOperator:
                        i = SkipWhiteSpaces(expression, i);
                        switch (expression[i])
                        {
                            case '+':
                                operators.Add(Operator.Addition);
                                break;
                            case '-':
                                operators.Add(Operator.Subtraction);
                                break;
                            case '*':
                                operators.Add(Operator.Multiplication);
                                break;
                            case '/':
                                operators.Add(Operator.Division);
                                break;
                            default:
                                throw new Exception($"Invalid operator on position {i}");

                        }
                        ++i;
                        state = ExpressionParserState.SkippingWhiteSpacesAfterOperator;
                        break;


                    case ExpressionParserState.ReadingVariable:
                        //TODO: create VariableX and add it to object list (take care of current sign) 
                        expressionList.Add(new VariableX());
                        state = ExpressionParserState.SkippingWhiteSpacesBeforeOperator;
                        break;
                    case ExpressionParserState.ReadingConstant:
                        var constant = ReadConstant(expression, ref i);
                        //TODO:create constantExpression and add it to object list (take care of current sign)
                        expressionList.Add(constant);

                        state = ExpressionParserState.SkippingWhiteSpacesBeforeOperator;
                        break;
                    case ExpressionParserState.ReadingMathFunction:
                        var fun = ReadFunction(expression, ref i);
                        expressionList.Add(fun);
                        break;


                }

            }
            return null;
        }

        private IExpression ReadFunction(string expression, ref int i)
        {
            //TODO: identify function and initialize delegate MathFunction.Fun


            MathFunction.Fun fun = null;
            int start = i;
            string funName = expression.Substring(start, i - start);
            switch (funName)
            {
                case "sin":

                    i += 3;
                    fun = Math.Sin;
                    break;
                case "cos":
                    i += 3;
                    fun = Math.Cos;
                    break;
                case "tan":
                    i += 3;
                    fun = Math.Tan;
                    break;
                case "sqrt":
                    i += 4;
                    fun = Math.Sqrt;
                    break;
                case "ln":
                    i += 2;
                    fun = Math.Log;
                    break;
                case "log":
                    i += 3;
                    fun = Math.Log10;
                    break;
                case "asin":
                    i += 4;
                    fun = Math.Asin;
                    break;
                case "acos":
                    i += 4;
                    fun = Math.Acos;
                    break;
                case "atan":
                    i += 4;
                    fun = Math.Atan;
                    break;


            }

            //TODO: parse expression inside parenthesis
            start = i;
            int end = findPositionOfRightParenthesis(start, expression); //TODO find position of right parenthesis
            IExpression expr = Parse(expression.Substring(start, end - start));

            return new MathFunction(fun, expr);
            //while (char.IsLetter(expression[i]))
            //{
            //   switch (expression[i])
            //    {
            //        case 's':
            //            return new MathFunction(Math.Sin, new VariableX());
            //           return
            //        case 'c':
            //            return new MathFunction(Math.Cos, new VariableX());
            //    }

            //}
        }

        private int findPositionOfRightParenthesis(int start, string expression)
        {
            int i = start;
            while (expression[i] != ')')
            {
                ++i;
            }

            return i;
           
        }

        private IExpression ReadConstant(string expression, ref int i)
        {
            int start = i;
            int decimalSeparator = 0;
            while (char.IsDigit(expression[i]) || expression[i] == '.')
            {
                if (expression[i] == '.')
                {
                    ++decimalSeparator;
                    if (decimalSeparator > 1)
                        throw new Exception();
                }
                ++i;
            }
            return new Constant(double.Parse(expression.Substring(start, i - start)));
        }

        private ExpressionParserState GetNextState(string expression, int i)
        {

            if (expression[i] == 'x')
            {
                return ExpressionParserState.ReadingVariable;
            }
            else if ((expression[i] >= 'A' && expression[i] <= 'Z') || (expression[i] >= 'a' && expression[i] <= 'z'))
            {
                return ExpressionParserState.ReadingMathFunction;
            }
            else if (char.IsDigit(expression[i]))
            {
                return ExpressionParserState.ReadingConstant;
            }
            throw new Exception("Invalid expression"); //TODO: napraviti svoju iznimku

        }

        private int SkipWhiteSpaces(string expression, int i)
        {
            while (expression[i] == ' ')
            {
                ++i;
            }

            return i;
        }
    }
}
