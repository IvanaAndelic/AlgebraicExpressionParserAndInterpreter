using AlgebraicExpressionInterpreter;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgebraicExpressionParser
{

    public class InvalidExpressionException : Exception
    {
        public InvalidExpressionException(string message)
            : base(message) { }
    }

    public class Parser
    {
        private enum ExpressionParserState
        {
            SkippingWhiteSpacesBeforeOperator,
            SkippingWhiteSpacesAfterOperator,
            ReadingOperator,
            ReadingConstant,
            ReadingVariable,
            ReadingMathFunction
        }

        private enum Sign
        {
            Positive,
            Negative
        }

        private enum Operator
        {
            Addition,
            Subtraction,
            Multiplication,
            Division,
            LeftParenthesis,

            Functions,
            Sin,
            Cos,
            Tan,
            Sqrt,
            Ln,
            Log,
            Asin,
            Acos,
            Atan,
        }

        //popuniti
        private readonly Dictionary<Operator, MathFunction.Fun> functionMap = new Dictionary<Operator, MathFunction.Fun> {
            { Operator.Sin, Math.Sin },
            { Operator.Cos, Math.Cos },
            { Operator.Sqrt, Math.Sqrt },
        };

        private int GetPrecedence(Operator op)
        {
            switch (op)
            {
                case Operator.Addition:
                case Operator.Subtraction:
                    return 1;
                case Operator.Multiplication:
                case Operator.Division:
                    return 2;
                case Operator.LeftParenthesis:
                    return 3;
            }
            return 4;
        }

        private readonly Deque<Operator> operators = new Deque<Operator>();
        private readonly Deque<IExpression> output = new Deque<IExpression>();

        private IExpression EvaluateOperator(Operator op)
        {
            if (op > Operator.Functions)
            {
                var operand = output.PopBack();
                var fun = functionMap[op];
                return new MathFunction(fun, operand);
            }
            var rhs = output.PopBack();
            var lhs = output.PopBack();
            return EvaluateBinaryOperation(op, lhs, rhs);
        }
        //while (
        //    there is an operator o2 other than the left parenthesis at the top
        //    of the operator stack, and(o2 has greater precedence than o1
        //    or they have the same precedence and o1 is left - associative)
        //):
        //    pop o2 from the operator stack into the output queue
        //push o1 onto the operator stack
        private void ProccessOperator(Operator op)
        {
            while (operators.Count > 0 && operators.PeekBack() != Operator.LeftParenthesis && GetPrecedence(operators.PeekBack()) > GetPrecedence(op))
            {
                output.PushBack(EvaluateOperator(operators.PopBack()));
            }
            operators.PushBack(op);
        }

        private void CleanupTopOperators()
        {
            var topOperator = operators.PopBack();
            while (operators.Count > 0 && GetPrecedence(operators.PeekBack()) <= GetPrecedence(topOperator))
            {
                output.PushBack(EvaluateOperator(topOperator));
                topOperator = operators.PopBack();
            }
            operators.PushBack(topOperator);
        }

        //while the operator at the top of the operator stack is not a left parenthesis:
        //    { assert the operator stack is not empty}
        //    /* If the stack runs out without finding a left parenthesis, then there are mismatched parentheses. */
        //    pop the operator from the operator stack into the output queue
        //{ assert there is a left parenthesis at the top of the operator stack}
        //    pop the left parenthesis from the operator stack and discard it
        //if there is a function token at the top of the operator stack, then:
        //    pop the function from the operator stack into the output queue
        private void ProcessRightParenthesis()
        {
            while (IsNotLeftParenthesis())
            {
                output.PushBack(EvaluateOperator(operators.PopBack()));
            }
            // Pop the left parenthesis from the operator stack and discard it.
            operators.PopBack();
        }

        private bool IsNotLeftParenthesis()
        {
            if (operators.Count == 0)
            {
                throw new InvalidExpressionException("Mismatched parentheses");
            }
            return operators.PeekBack() != Operator.LeftParenthesis;
        }

        public IExpression Parse(string expression) //vraca izraz iexpression
        {
            operators.Clear();
            output.Clear();

            ExpressionParserState state = ExpressionParserState.SkippingWhiteSpacesAfterOperator;
            Sign currentSign = Sign.Positive;

            for (int pos = 0; pos < expression.Length;)
            {
                switch (state)
                {
                    case ExpressionParserState.SkippingWhiteSpacesAfterOperator:
                        SkipWhiteSpaces(expression, ref pos);
                        if (pos == expression.Length)
                        {
                            throw new InvalidExpressionException("Expression terminated unexpectedly");
                        }
                        switch (expression[pos])
                        {
                            case '(':
                                operators.PushBack(Operator.LeftParenthesis);
                                ++pos;
                                break;
                            case ')':
                                throw new InvalidExpressionException($"Unexpected right parenthesis on position {pos + 1}");
                            default:
                                switch (expression[pos])
                                {
                                    case '-':
                                        currentSign = Sign.Negative;
                                        ++pos;
                                        break;
                                    case '+':
                                        currentSign = Sign.Positive;
                                        ++pos;
                                        break;
                                }
                                state = GetNextState(expression, pos);
                                break;
                        }
                        break;
                    case ExpressionParserState.SkippingWhiteSpacesBeforeOperator:
                        SkipWhiteSpaces(expression, ref pos);
                        if (pos == expression.Length)
                        {
                            break;
                        }
                        switch (expression[pos])
                        {
                            case '+':
                                ProccessOperator(Operator.Addition);
                                state = ExpressionParserState.SkippingWhiteSpacesAfterOperator;
                                break;
                            case '-':
                                ProccessOperator(Operator.Subtraction);
                                state = ExpressionParserState.SkippingWhiteSpacesAfterOperator;
                                break;
                            case '*':
                                ProccessOperator(Operator.Multiplication);
                                state = ExpressionParserState.SkippingWhiteSpacesAfterOperator;
                                break;
                            case '/':
                                ProccessOperator(Operator.Division);
                                state = ExpressionParserState.SkippingWhiteSpacesAfterOperator;
                                break;
                            case '(':
                                operators.PushBack(Operator.LeftParenthesis);
                                break;
                            case ')':
                                ProcessRightParenthesis();
                                break;
                            default:
                                throw new InvalidExpressionException($"Invalid operator on position {pos + 1}");
                        }
                        ++pos;
                        break;
                    case ExpressionParserState.ReadingVariable:
                        output.PushBack(new VariableX(currentSign == Sign.Positive));
                        state = ExpressionParserState.SkippingWhiteSpacesBeforeOperator;
                        ++pos;
                        currentSign = Sign.Positive;
                        break;
                    case ExpressionParserState.ReadingConstant:
                        var constant = ReadConstant(expression, ref pos, currentSign);
                        output.PushBack(constant);
                        state = ExpressionParserState.SkippingWhiteSpacesBeforeOperator;
                        currentSign = Sign.Positive;
                        break;
                    case ExpressionParserState.ReadingMathFunction:
                        ReadFunction(expression, ref pos);
                        state = ExpressionParserState.SkippingWhiteSpacesAfterOperator;
                        break;
                }
            }
            // Process any operator with higher precedence at the end of expression
            if (operators.Count > 1 && GetPrecedence(operators.PeekBack()) > 1)
            {
                CleanupTopOperators();
            }
            return FinalEvaluation();
        }

        //while there are tokens on the operator stack:
        ///* If the operator token on the top of the stack is a parenthesis, then there are mismatched parentheses. */
        //{ assert the operator on top of the stack is not a(left) parenthesis}
        //pop the operator from the operator stack onto the output queue
        private IExpression FinalEvaluation()
        {
            var lhs = output.PopFront();
            while (operators.Count > 0)
            {
                var topOperator = operators.PopFront();
                if (topOperator == Operator.LeftParenthesis)
                {
                    throw new InvalidExpressionException("Mismatched parentheses");
                }
                if (topOperator > Operator.Functions)
                {
                    var fun = functionMap[topOperator];
                    lhs = new MathFunction(fun, lhs);
                }
                else
                {
                    var rhs = output.PopFront();
                    lhs = EvaluateBinaryOperation(topOperator, lhs, rhs);
                }
            }
            return lhs;
        }

        private IExpression EvaluateBinaryOperation(Operator op, IExpression lhs, IExpression rhs)
        {
            switch (op)
            {
                case Operator.Addition:
                    return new SumExpression(lhs, rhs);
                case Operator.Subtraction:
                    return new SubtractExpression(lhs, rhs);
                case Operator.Multiplication:
                    return new MultiplyExpression(lhs, rhs);
                case Operator.Division:
                    return new DivideExpression(lhs, rhs);
            }
            Debug.Assert(false);
            return null;
        }

        private void ReadFunction(string expression, ref int pos)
        {
            Operator fun = ResolveFunction(expression, ref pos);
            operators.PushBack(fun);
            // Function name must be followed by left parenthesis.
            if (expression[pos] != '(')
                throw new InvalidExpressionException($"Function name not followed by left parenthesis at position {pos + 1}");
            operators.PushBack(Operator.LeftParenthesis);
            ++pos;
        }

        private Operator ResolveFunction(string expression, ref int pos)
        {
            string funName = expression.Substring(pos);
            if (funName.StartsWith("sin"))
            {
                pos += 3;
                return Operator.Sin;
            }
            if (funName.StartsWith("cos"))
            {
                pos += 3;
                return Operator.Cos;
            }
            if (funName.StartsWith("tan"))
            {
                pos += 3;
                return Operator.Tan;
            }
            if (funName.StartsWith("sqrt"))
            {
                pos += 4;
                return Operator.Sqrt;
            }
            if (funName.StartsWith("ln"))
            {
                pos += 2;
                return Operator.Ln;
            }
            if (funName.StartsWith("log"))
            {
                pos += 3;
                return Operator.Log;
            }
            throw new InvalidExpressionException($"Unknown function at position {pos + 1}");
        }

        private IExpression ReadConstant(string expression, ref int pos, Sign sign)
        {
            int start = pos;
            int decimalSeparators = 0;
            while (pos < expression.Length && (char.IsDigit(expression[pos]) || expression[pos] == '.'))
            {
                if (expression[pos] == '.')
                {
                    ++decimalSeparators;
                    if (decimalSeparators > 1)
                    {
                        throw new InvalidExpressionException($"Duplicate decimal separator on position {pos + 1}");
                    }
                }
                ++pos;
            }
            // Leading and trailing spaces should be eliminated already so we set number style accordingly.
            // Decimal separator must be a point so we set formatProvider to CultureInfo.InvariantCulture.
            var value = double.Parse(expression.Substring(start, pos - start), NumberStyles.None | NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture);
            if (sign == Sign.Negative)
                value = -value;
            return new Constant(value);
        }

        private ExpressionParserState GetNextState(string expression, int pos)
        {
            if (expression[pos] == 'x')
            {
                return ExpressionParserState.ReadingVariable;
            }
            else if ((expression[pos] >= 'A' && expression[pos] <= 'Z') || (expression[pos] >= 'a' && expression[pos] <= 'z'))
            {
                return ExpressionParserState.ReadingMathFunction;
            }
            else if (char.IsDigit(expression[pos]))
            {
                return ExpressionParserState.ReadingConstant;
            }
            throw new InvalidExpressionException($"Unexpected character at position {pos + 1}");
        }

        private void SkipWhiteSpaces(string expression, ref int pos)
        {
            while (pos < expression.Length && expression[pos] == ' ')
            {
                ++pos;
            }
        }
    }
}


