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

        private enum Operator
        {
            Addition,
            Subtraction,
            Multiplication,
            Division,
            LeftParenthesis,
            Minus,

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

        private int GetPrecedence(Operator @operator)
        {
            switch (@operator)
            {
                case Operator.Addition:
                case Operator.Subtraction:
                    return 1;
                case Operator.Multiplication:
                case Operator.Division:
                    return 2;
                case Operator.LeftParenthesis:
                case Operator.Minus:
                    return 3;
            }
            return 4;
        }

        private readonly Deque<Operator> operators = new Deque<Operator>();
        private readonly Deque<IExpression> output = new Deque<IExpression>();

        private IExpression EvaluateOperator(Operator @operator)
        {
            if (@operator > Operator.Functions)
            {
                var operand = output.PopBack();
                var fun = functionMap[@operator];
                return new MathFunction(fun, operand);
            }
            if (@operator == Operator.Minus)
            {
                var operand = output.PopBack();
                operand.ToggleSign();
                return operand;
            }
            var rhs = output.PopBack();
            var lhs = output.PopBack();
            return EvaluateBinaryOperation(@operator, lhs, rhs);
        }
        //while (
        //    there is an operator o2 other than the left parenthesis at the top
        //    of the operator stack, and(o2 has greater precedence than o1
        //    or they have the same precedence and o1 is left - associative)
        //):
        //    pop o2 from the operator stack into the output queue
        //push o1 onto the operator stack
        private void ProccessOperator(Operator @operator)
        {
            while (operators.Count > 0 && operators.PeekBack() != Operator.LeftParenthesis && GetPrecedence(operators.PeekBack()) > GetPrecedence(@operator))
            {
                output.PushBack(EvaluateOperator(operators.PopBack()));
            }
            operators.PushBack(@operator);
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

        public IExpression Parse(string text)
        {
            operators.Clear();
            output.Clear();

            ExpressionParserState state = ExpressionParserState.SkippingWhiteSpacesAfterOperator;

            for (int pos = 0; pos < text.Length;)
            {
                switch (state)
                {
                    case ExpressionParserState.SkippingWhiteSpacesAfterOperator:
                        SkipWhiteSpaces(text, ref pos);
                        if (pos == text.Length)
                        {
                            throw new InvalidExpressionException("Expression terminated unexpectedly");
                        }
                        switch (text[pos])
                        {
                            case '(':
                                operators.PushBack(Operator.LeftParenthesis);
                                ++pos;
                                break;
                            case ')':
                                throw new InvalidExpressionException($"Unexpected right parenthesis on position {pos + 1}");
                            default:
                                switch (text[pos])
                                {
                                    case '-':
                                        operators.PushBack(Operator.Minus);
                                        ++pos;
                                        break;
                                    case '+':
                                        ++pos;
                                        break;
                                }
                                state = GetNextState(text, pos);
                                break;
                        }
                        break;
                    case ExpressionParserState.SkippingWhiteSpacesBeforeOperator:
                        SkipWhiteSpaces(text, ref pos);
                        if (pos == text.Length)
                        {
                            break;
                        }
                        switch (text[pos])
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
                        output.PushBack(new VariableX());
                        state = ExpressionParserState.SkippingWhiteSpacesBeforeOperator;
                        ++pos;
                        break;
                    case ExpressionParserState.ReadingConstant:
                        var constant = ReadConstant(text, ref pos);
                        output.PushBack(constant);
                        state = ExpressionParserState.SkippingWhiteSpacesBeforeOperator;
                        break;
                    case ExpressionParserState.ReadingMathFunction:
                        ReadFunction(text, ref pos);
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
                else if (topOperator == Operator.Minus)
                {
                    lhs.ToggleSign();
                }
                else
                {
                    var rhs = output.PopFront();
                    lhs = EvaluateBinaryOperation(topOperator, lhs, rhs);
                }
            }
            return lhs;
        }

        private IExpression EvaluateBinaryOperation(Operator @operator, IExpression lhs, IExpression rhs)
        {
            switch (@operator)
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

        private void ReadFunction(string text, ref int pos)
        {
            Operator fun = ResolveFunction(text, ref pos);
            operators.PushBack(fun);
            // Function name must be followed by left parenthesis.
            if (text[pos] != '(')
                throw new InvalidExpressionException($"Function name not followed by left parenthesis at position {pos + 1}");
            operators.PushBack(Operator.LeftParenthesis);
            ++pos;
        }

        private Operator ResolveFunction(string text, ref int pos)
        {
            string funName = text.Substring(pos);
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

        private IExpression ReadConstant(string text, ref int pos)
        {
            int start = pos;
            int decimalSeparators = 0;
            while (pos < text.Length && (char.IsDigit(text[pos]) || text[pos] == '.'))
            {
                if (text[pos] == '.')
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
            var value = double.Parse(text.Substring(start, pos - start), NumberStyles.None | NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture);
            return new Constant(value);
        }

        private ExpressionParserState GetNextState(string text, int pos)
        {
            if (text[pos] == '(')
            {
                return ExpressionParserState.SkippingWhiteSpacesAfterOperator;
            }
            if (text[pos] == 'x')
            {
                return ExpressionParserState.ReadingVariable;
            }
            if ((text[pos] >= 'A' && text[pos] <= 'Z') || (text[pos] >= 'a' && text[pos] <= 'z'))
            {
                return ExpressionParserState.ReadingMathFunction;
            }
            if (char.IsDigit(text[pos]))
            {
                return ExpressionParserState.ReadingConstant;
            }
            throw new InvalidExpressionException($"Unexpected character at position {pos + 1}");
        }

        private void SkipWhiteSpaces(string text, ref int pos)
        {
            while (pos < text.Length && text[pos] == ' ')
            {
                ++pos;
            }
        }
    }
}


