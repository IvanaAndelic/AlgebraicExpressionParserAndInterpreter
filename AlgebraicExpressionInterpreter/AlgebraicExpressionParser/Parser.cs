using AlgebraicExpressionInterpreter;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;

namespace AlgebraicExpressionParser
{
    /// <summary>
    ///   Class that parses a string with mathematical expression and evaluates
    ///   the resulting <c>Expression</c> object.
    /// </summary>
    public class Parser
    {
        /// <summary>
        ///   Specifies current state of the parsing process.
        /// </summary>
        private enum ParserState
        {
            SkippingWhiteSpacesBeforeOperator,
            SkippingWhiteSpacesAfterOperator,
            ReadingOperator,
            ReadingConstant,
            ReadingVariable,
            ReadingFunction,
            ReadingNamedConstant
        }

        /// <summary>
        ///   Operators supported.
        /// </summary>
        private enum Operator
        {
            Addition,
            Subtraction,
            Multiplication,
            Division,
            Power,
            LeftParenthesis,
            Minus,

            Functions,
            Sin,
            Cos,
            Tan,
            Sqrt,
            Cbrt, //kubni korijen
            Exp,
            Ln,
            Log,
            Asin,
            Acos,
            Atan,
            Sinh,
            Cosh,
            Tanh,
            Asinh,
            Acosh,
            Atanh,
            Abs,
        }

        private enum namedConstant {
           E, 
           PI
        }

        /// <summary>
        ///   Mapping of <c>Operator</c> enumeration to function delegates.
        /// </summary>
        ///(Add enumerations for additional functions)
        private readonly Dictionary<Operator, MathFunction.Fun> functionMap = new Dictionary<Operator, MathFunction.Fun> {
            { Operator.Sin, Math.Sin },
            { Operator.Cos, Math.Cos },
            { Operator.Sqrt, Math.Sqrt },
           // {Operator.Cbrt, Math.Cbrt },
            {Operator.Exp, Math.Exp },
            {Operator.Ln, Math.Log },
            {Operator.Log, Math.Log10 },
            {Operator.Asin, Math.Asin },
            {Operator.Acos, Math.Acos },
            {Operator.Atan, Math.Atan },
            {Operator.Sinh, Math.Sinh },
            {Operator.Cosh, Math.Cosh },
            {Operator.Tanh, Math.Tanh },
            //{Operator.Asinh, Math.Asinh},
            //{Operator.Acosh, Math.Acosh },
           // {Operator.Atanh, Math.Atanh },
            {Operator.Abs, Math.Abs }



        };

        private readonly Dictionary<string, Operator> functionTokenMap = new Dictionary<string, Operator>
        {
            {"sin", Operator.Sin },
            {"cos", Operator.Cos },
            {"tan", Operator.Tan },
            {"sqrt", Operator.Sqrt },
            {"cbrt", Operator.Cbrt },
            {"exp", Operator.Exp },
            {"ln", Operator.Ln },
            {"log", Operator.Log },
            {"asin", Operator.Asin },
            {"acos", Operator.Acos },
            {"atan", Operator.Atan },
            {"sinh", Operator.Sinh },
            {"cosh", Operator.Cosh },
            {"tanh", Operator.Tanh },
            {"asinh", Operator.Asinh },
            {"acosh", Operator.Acosh },
            {"atanh", Operator.Atanh },
            {"abs", Operator.Abs }
        };

        private readonly Dictionary<string, Constant> namedConstantsToken = new Dictionary<string, Constant>
        {
            {"E", Constant.E },
            {"PI", Constant.PI }
        };

        /// <summary>
        ///   Stack with operators to be processed. On successful parsing this 
        ///   stack should be empty.
        /// </summary>
        private readonly Stack<Operator> operators = new Stack<Operator>();

        /// <summary>
        ///   Output stack where results are pushed. On successful parsing this 
        ///   stack should contain the final expression only.
        /// </summary>
        private readonly Stack<IExpression> output = new Stack<IExpression>();

        /// <summary>
        ///   Parses the text of mathematical expression provided. Implements 
        ///   <see href="https://en.wikipedia.org/wiki/Shunting_yard_algorithm">
        ///   Dykstra's Shunting yard algorithm</see>, taking care of operator 
        ///   precedence.
        /// </summary>
        /// <param name="text">String with expression to parse.</param>
        /// <returns>Final <c>Expression</c> object.</returns>
        public IExpression Parse(string text)
        {
            operators.Clear();
            output.Clear();
            ParserState state = ParserState.SkippingWhiteSpacesAfterOperator;

            for (int pos = 0; pos < text.Length;)
            {
                switch (state)
                {
                    case ParserState.SkippingWhiteSpacesAfterOperator:
                        SkipWhiteSpaces(text, ref pos);
                        if (pos == text.Length)
                        {
                            throw new ParserException("Expression terminated unexpectedly", pos);
                        }
                        switch (text[pos])
                        {
                            case '(':
                                operators.Push(Operator.LeftParenthesis);
                                ++pos;
                                break;
                            case ')':
                                throw new ParserException("Unexpected right parenthesis", pos);
                            default:
                                switch (text[pos])
                                {
                                    case '-':
                                        operators.Push(Operator.Minus);
                                        ++pos;
                                        break;
                                    case '+':
                                        ++pos;
                                        break;
                                }
                                state = GetStateAfterOperator(text, ref pos);
                                break;
                        }
                        break;
                    case ParserState.SkippingWhiteSpacesBeforeOperator:
                        SkipWhiteSpaces(text, ref pos);
                        if (pos == text.Length)
                        {
                            break;
                        }
                        state = ProcessOperator(text, pos);
                        ++pos;
                        break;
                    case ParserState.ReadingVariable:
                        output.Push(new VariableX());
                        state = ParserState.SkippingWhiteSpacesBeforeOperator;
                        ++pos;
                        break;
                    case ParserState.ReadingConstant:
                        PushConstant(text, ref pos);
                        state = ParserState.SkippingWhiteSpacesBeforeOperator;
                        break;
                    case ParserState.ReadingFunction:
                        PushFunction(text, ref pos);
                        state = ParserState.SkippingWhiteSpacesAfterOperator;
                        break;
                    case ParserState.ReadingNamedConstant:
                        PushNamedConstant(text, ref pos);
                        state = ParserState.SkippingWhiteSpacesBeforeOperator;
                        break;
                }
            }
            if (state != ParserState.SkippingWhiteSpacesBeforeOperator)
            {
                throw new ParserException("Expression terminated unexpectedly", text.Length);
            }
            return FinalExpression();
        }

        private ParserState ProcessOperator(string text, int pos)
        {
            switch (text[pos])
            {
                case ')':
                    ProcessRightParenthesis(pos);
                    return ParserState.SkippingWhiteSpacesBeforeOperator;
                case '+':
                    PushOperator(Operator.Addition);
                    break;
                case '-':
                    PushOperator(Operator.Subtraction);
                    break;
                case '*':
                    PushOperator(Operator.Multiplication);
                    break;
                case '/':
                    PushOperator(Operator.Division);
                    break;
                case '^':
                    PushOperator(Operator.Power);
                    break;
                default:
                    throw new ParserException("Invalid operator", pos);
            }

            return ParserState.SkippingWhiteSpacesAfterOperator;
        }

        /// <summary>
        ///   Evaluates precedence of the operator passed.
        /// </summary>
        /// <param name="operator">Operator for which precedence is reqested.</param>
        /// <returns>Integer represeting precedence level. Higher values represent higher precedence.</returns>
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
                case Operator.Power:
                    return 3;
                case Operator.LeftParenthesis:
                case Operator.Minus:
                    return 4;
            }
            return 5;
        }

        /// <summary>
        ///   Pushes operator passed onto operators stack. If operator on the 
        ///   top of the operator stack has higher precedence then operator 
        ///   passed, function evaluates operators from the top of the stack 
        ///   that have higher precedence first and pushes the result to the 
        ///   output stack.
        /// </summary>
        /// <param name="operator">Operator to push onto operator stack.</param>
        private void PushOperator(Operator @operator)
        {
            while (operators.Count > 0 && operators.Peek() != Operator.LeftParenthesis && GetPrecedence(operators.Peek()) > GetPrecedence(@operator))
            {
                EvaluateExpressionFromTop();
            }
            operators.Push(@operator);
        }

        /// <summary>
        ///   Evaluates remaining operators on the operator stack, 
        /// </summary>
        /// <returns>Final <c>Expression</c> object.</returns>
        private IExpression FinalExpression()
        {
            while (operators.Count > 0)
            {
                if (operators.Peek() == Operator.LeftParenthesis)
                {
                    // TODO: Provide exact position
                    throw new ParserException("Right parentesis is missing or mismatched", 0);
                }
                EvaluateExpressionFromTop();
            }
            return output.Pop();
        }

        /// <summary>
        ///   Evaluates expression for the top operators. First pops all 
        ///   operators with equal or higher precedence than top operator, 
        ///   together with corresponding operands and pushes them to a local 
        ///   stacks in order to evaluate operations from left to right, as 
        ///   they appear in the original text. Then processes local stacks 
        ///   and pushes the result to the output stack.
        /// </summary>
        private void EvaluateExpressionFromTop()
        {
            // Local stacks for evaluation from left to right.
            Stack<IExpression> endExpressions = new Stack<IExpression>();
            Stack<Operator> endOperators = new Stack<Operator>();
            var topOperator = operators.Pop();
            var precedence = GetPrecedence(topOperator);
            // Move first operand.
            endExpressions.Push(output.Pop());
            while (GetPrecedence(topOperator) >= precedence)
            {
                endOperators.Push(topOperator);
                // For binary operation, additional operand is required.
                switch (topOperator)
                {
                    case Operator.Addition:
                    case Operator.Subtraction:
                    case Operator.Multiplication:
                    case Operator.Division:
                    case Operator.Power:
                        endExpressions.Push(output.Pop());
                        break;
                }
                if (operators.Count == 0 || GetPrecedence(operators.Peek()) < precedence || operators.Peek() == Operator.LeftParenthesis)
                {
                    break;
                }
                topOperator = operators.Pop();
            }
            Debug.Assert(endExpressions.Count != 0);
            // Evaluate operations from the local stack and push the resulting expression to output stack.
            var lhs = endExpressions.Pop();
            while (endOperators.Count > 0)
            {
                var @operator = endOperators.Pop();
                if (@operator > Operator.Functions)
                {
                    var fun = functionMap[@operator];
                    lhs = new MathFunction(fun, lhs);
                }
                else if (@operator == Operator.Minus)
                {
                    lhs.ToggleSign();
                }
                else
                {
                    var rhs = endExpressions.Pop();
                    lhs = EvaluateBinaryOperation(@operator, lhs, rhs);
                }
            }
            output.Push(lhs);
            Debug.Assert(endExpressions.Count == 0);
        }

        /// <summary>
        ///   Evaluates expression left from right parenthesis up to matching 
        ///   left parenthesis.
        /// </summary>
        /// <param name="pos">Position of the right parenthesis used for error reporting.</param>
        private void ProcessRightParenthesis(int pos)
        {
            while (IsNotLeftParenthesis(pos))
            {
                EvaluateExpressionFromTop();
            }
            // Pop the left parenthesis from the operator stack and discard it.
            operators.Pop();
        }

        /// <summary>
        ///   Checks if operator on the top of operator stack is not left 
        ///   parenthesis.
        /// </summary>
        /// <param name="pos">Position of the right parenthesis used for error reporting.</param>
        /// <returns>Returns <c>true</c> if character is not left parenthesis. If character is '(' returns <c>false</c>.</returns>
        private bool IsNotLeftParenthesis(int pos)
        {
            if (operators.Count == 0)
            {
                throw new ParserException("Left parenthesis is missing or mismatched", pos);
            }
            return operators.Peek() != Operator.LeftParenthesis;
        }

        /// <summary>
        ///   Creates ne expression for a binary operator, lefthand and 
        ///   righthand expressions provided.
        /// </summary>
        /// <param name="operator">Binary operator for which expression should be evaluated.</param>
        /// <param name="lhs">Expression on the lefthand side of operator.</param>
        /// <param name="rhs">Expression on the righthand side of operator.</param>
        /// <returns>Resulting <c>Expression</c> object.</returns>
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
                case Operator.Power:
                    return new PowerExpression(lhs, rhs);
            }
            Debug.Assert(false);
            return null;
        }

        /// <summary>
        ///   Resolves the function and pushes it onto operator stack.
        /// </summary>
        /// <param name="text">Name of the function.</param>
        /// <param name="pos">Position of the function name used for error reporting.</param>
        private void PushFunction(string text, ref int pos)
        {
            Operator fun = ResolveFunction(text, ref pos);
            operators.Push(fun);
            // Function name must be followed by left parenthesis.
            if (text[pos] != '(')
                throw new ParserException("Left parenthesis is missing after function name", pos);
            operators.Push(Operator.LeftParenthesis);
            ++pos;
        }

        /// <summary>
        ///   Resolves the function from its name.
        /// </summary>
        /// <param name="text">Text of the mathematical expression.</param>
        /// <param name="pos">Index of the function name start.</param>
        /// <returns><c>Operator</c> corresponding to resolved function name.</returns>
        private Operator ResolveFunction(string text, ref int pos)
        {
            string functionName = GetIdentifier(text, pos);

            if(functionTokenMap.TryGetValue(functionName,out Operator function))
            {
                pos += functionName.Length;
                return function;
            }
            throw new ParserException("Unknown function", pos);
        }

        /// <summary>
        ///   Parses and pushes the constant to the output stack.
        /// </summary>
        /// <param name="text">Text of the mathematical expression.</param>
        /// <param name="pos">Position where value of the constant starts.</param>
        private void PushConstant(string text, ref int pos)
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
                        throw new ParserException("Duplicate decimal separator", pos);
                    }
                }
                ++pos;
            }
            // Leading and trailing spaces should be eliminated already so we set number style accordingly.
            // Decimal separator must be a point so we set formatProvider to CultureInfo.InvariantCulture.
            var value = double.Parse(text.Substring(start, pos - start), NumberStyles.None | NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture);
            output.Push(new Constant(value));
        }

        private Constant PushNamedConstant(string text, ref int pos)
        {
            string constantName = GetIdentifier(text, pos);

            if(namedConstantsToken.TryGetValue(constantName, out Constant constant)){
                pos += constantName.Length;
                return constant;
            }
            //switch (constantname)
            //{
            //    case "e":
            //        pos += 1;
            //        output.push(new constant(math.e));
            //        return;
            //    case "pi":
            //        pos += 2;
            //        output.push(new constant(math.pi));
            //        return;
            //}
            throw new ParserException("Unknown named constant", pos);
        }

        /// <summary>
        ///   Evaluates next state after operator was read.
        /// </summary>
        /// <param name="text">Text of the mathematical expression.</param>
        /// <param name="pos">Position where value of the constant starts.</param>
        /// <returns>New <c>ParserState</c> value.</returns>
        private ParserState GetStateAfterOperator(string text, ref int pos)
        {
            if (text[pos] == '(')
            {
                return ParserState.SkippingWhiteSpacesAfterOperator;
            }
            if (text[pos] == 'x')
            {
                return ParserState.ReadingVariable;
            }
            if (char.IsDigit(text[pos]))
            {
                return ParserState.ReadingConstant;
            }
            // Extract a sequence of letters and digits.
            string identifier = GetIdentifier(text, pos);
            if (identifier.Length > 0)
            {
                // If identifier is folowed by parenthesis, it must be a function.
                if (pos + identifier.Length < text.Length && text[pos + identifier.Length] == '(')
                {
                    return ParserState.ReadingFunction;
                }
                return ParserState.ReadingNamedConstant;
            }
            throw new ParserException("Unexpected character", pos);
        }

        /// <summary>
        ///   Extracts identifier, which starts with a letter and is followed 
        ///   by a sequence of letters and digits.
        /// </summary>
        /// <param name="text">Text of the mathematical expression.</param>
        /// <param name="pos">Position where extraction starts.</param>
        /// <returns>String with identifier.</returns>
        private string GetIdentifier(string text, int pos)
        {
            if (Char.IsLetter(text[pos]))
            {
                int i = pos;
                do
                {
                    ++i;
                }
                while (i < text.Length && Char.IsLetter(text[i]));
                return text.Substring(pos, i - pos);
            }
            return string.Empty;
        }

        /// <summary>
        ///   Increment <c>pos</c> to the first non-space character.
        /// </summary>
        /// <param name="text">Text of the mathematical expression.</param>
        /// <param name="pos">Position where search starts.</param>
        private void SkipWhiteSpaces(string text, ref int pos)
        {
            while (pos < text.Length && text[pos] == ' ')
            {
                ++pos;
            }
        }
    }
}
