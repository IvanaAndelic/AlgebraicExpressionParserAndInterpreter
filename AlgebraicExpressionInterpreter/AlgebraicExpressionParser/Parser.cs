using AlgebraicExpressionInterpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgebraicExpressionParser
{

    class InvalidExpressionException : Exception
    {
        public InvalidExpressionException(string message)
            : base(message) { }

    }
    public class Parser
    {

        public enum ExpressionParserState
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

        public enum Operator
        {
            Addition,
            Subtraction,
            Multiplication,
            Division,
            LeftParenthesis,
            Function,
            Sin = Function,
            Cos,
            Tan,
            Sqrt,
            Ln,
            Log,
            Asin,
            Acos,
            Atan
        }
        //popuniti
        Dictionary<Operator, MathFunction.Fun> functionMap = new Dictionary<Operator, MathFunction.Fun> { { Operator.Sin, Math.Sin }, { Operator.Cos, Math.Cos } };
        Dictionary<Operator, int> precedence = new Dictionary<Operator, int> { { Operator.Addition, 1 }, { Operator.Subtraction, 1 }, { Operator.Multiplication, 2 }, { Operator.Division, 2 } };
        Queue<Operator> outputQueue = new Queue<Operator>();
        Stack<Operator> operators = new Stack<Operator>();
        private void ProccessOperators(Operator current)
        {
            while (operators.Count > 0 && operators.Peek() != Operator.LeftParenthesis && precedence[operators.Peek()] >= precedence[current])
            {

                var topOperator = operators.Pop();
                outputQueue.Enqueue(topOperator);
            }
            operators.Push(current);
        }
        // a right parenthesis(i.e. ")"):
        //while the operator at the top of the operator stack is not a left parenthesis:
        //    { assert the operator stack is not empty}
        //    /* If the stack runs out without finding a left parenthesis, then there are mismatched parentheses. */
        //    pop the operator from the operator stack into the output queue
        //{ assert there is a left parenthesis at the top of the operator stack}
        //    pop the left parenthesis from the operator stack and discard it
        //if there is a function token at the top of the operator stack, then:
        //    pop the function from the operator stack into the output queue
        private bool IsNotLeftParentheses()
        {
            if (operators.Count == 0)
                throw new InvalidExpressionException("Mismatched parentheses");

            return operators.Peek() != Operator.LeftParenthesis;
        }
        public IExpression Parse(string expression) //vraca izraz iexpression
        {
            ExpressionParserState state = ExpressionParserState.SkippingWhiteSpacesAfterOperator;
            Sign currentSign = Sign.Positive;


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
                        try
                        {
                            state = GetNextState(expression, i);
                        }
                        catch (InvalidExpressionException e)
                        {
                            Console.WriteLine("ExceptionInvalidExpression: {0}", e.Message);
                        }
                        break;
                    case ExpressionParserState.SkippingWhiteSpacesBeforeOperator:
                        i = SkipWhiteSpaces(expression, i);

                        switch (expression[i])
                        {
                            //while (
                            //    there is an operator o2 other than the left parenthesis at the top
                            //    of the operator stack, and(o2 has greater precedence than o1
                            //    or they have the same precedence and o1 is left - associative)
                            //):
                            //    pop o2 from the operator stack into the output queue
                            //push o1 onto the operator stack
                            case '+':
                                ProccessOperators(Operator.Addition);
                                break;
                            case '-':
                                ProccessOperators(Operator.Subtraction);
                                break;
                            case '*':
                                ProccessOperators(Operator.Multiplication);
                                break;
                            case '/':
                                ProccessOperators(Operator.Division);
                                break;
                            // a left parenthesis(i.e. "("):
                            //push it onto the operator stack
                            case '(':
                                operators.Push(Operator.LeftParenthesis);
                                break;
                            // a right parenthesis(i.e. ")"):
                            //while the operator at the top of the operator stack is not a left parenthesis:
                            //    { assert the operator stack is not empty}
                            //    /* If the stack runs out without finding a left parenthesis, then there are mismatched parentheses. */
                            //    pop the operator from the operator stack into the output queue
                            //{ assert there is a left parenthesis at the top of the operator stack}
                            //    pop the left parenthesis from the operator stack and discard it
                            //if there is a function token at the top of the operator stack, then:
                            //    pop the function from the operator stack into the output queue
                            case ')':
                                while (IsNotLeftParentheses())
                                {
                                    var topOperator = operators.Pop();
                                    outputQueue.Enqueue(topOperator);
                                }
                                operators.Pop();
                                if (operators.Count > 0 && operators.Peek() >= Operator.Function)
                                {
                                    outputQueue.Enqueue(operators.Pop());
                                }
                                break;
                            default:
                                throw new Exception($"Invalid operator on position {i}");
                        }
                        ++i;
                        state = ExpressionParserState.SkippingWhiteSpacesAfterOperator;
                        break;
                    case ExpressionParserState.ReadingVariable:
                        //TODO: create VariableX and add it to object list (take care of current sign) 
                        //expressionQueue.Enqueue(new VariableX());
                        state = ExpressionParserState.SkippingWhiteSpacesBeforeOperator;
                        break;
                    case ExpressionParserState.ReadingConstant:
                        var constant = ReadConstant(expression, ref i);
                        //TODO:create constantExpression and add it to object list (take care of current sign)
                        //expressionQueue.Enqueue(constant);
                        state = ExpressionParserState.SkippingWhiteSpacesBeforeOperator;
                        break;
                    case ExpressionParserState.ReadingMathFunction:
                        var fun = ReadFunction(expression, ref i);
                        //expressionQueue.Enqueue(fun);
                        operators.Push(fun);
                        break;
                }
            }
            //while there are tokens on the operator stack:
            ///* If the operator token on the top of the stack is a parenthesis, then there are mismatched parentheses. */
            //{ assert the operator on top of the stack is not a(left) parenthesis}
            //pop the operator from the operator stack onto the output queue
            while (operators.Count > 0)
            {
                var topOperator = operators.Pop();
                if (topOperator == Operator.LeftParenthesis)
                    throw new InvalidExpressionException("Mismatched parentheses");
                outputQueue.Enqueue(topOperator);
            }


            return CreateFinalExpression(state, outputQueue);
        }

        public IExpression CreateFinalExpression(ExpressionParserState state, Queue<Operator> expressionQueue)
        {
            //foreach (IExpression expression in expressionQueue)
            //{

            //}
            return null;
        }
        public Operator ReadFunction(string expression, ref int i)
        {
            //TODO: identify function and initialize delegate MathFunction.Fun


            //MathFunction.Fun fun = null;
            int start = i;
            string funName = expression.Substring(start, i - start);
            switch (funName)
            {
                case "sin":
                    i += 3;
                    return Operator.Sin;
                case "cos":
                    i += 3;
                    // fun = Math.Cos;
                    break;
                case "tan":
                    i += 3;
                    // fun = Math.Tan;
                    break;
                case "sqrt":
                    i += 4;
                    // fun = Math.Sqrt;
                    break;
                case "ln":
                    i += 2;
                    // fun = Math.Log;
                    break;
                case "log":
                    i += 3;
                    // fun = Math.Log10;
                    break;
                case "asin":
                    i += 4;
                    //fun = Math.Asin;
                    break;
                case "acos":
                    i += 4;
                    // fun = Math.Acos;
                    break;
                case "atan":
                    i += 4;
                    // fun = Math.Atan;
                    break;
            }
            throw new InvalidExpressionException("Unknown function");
        }

        public int FindPositionOfRightParenthesis(int start, string expression)
        {
            int i = start;
            while (expression[i] != ')')
            {
                ++i;
            }
            return i;
        }
        public IExpression ReadConstant(string expression, ref int i)
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

        public ExpressionParserState GetNextState(string expression, int i)
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
            throw new InvalidExpressionException("Invalid expression"); // napraviti svoju iznimku

        }

        public int SkipWhiteSpaces(string expression, int i)
        {
            while (expression[i] == ' ')
            {
                ++i;
            }
            return i;
        }
    }
}


