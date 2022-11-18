using System.Linq.Expressions;
using System.Text.RegularExpressions;
using static Hw9.ErrorMessages.MathErrorMessager;

namespace Hw9.Parser;

public class ExpressionParser
{
    private readonly string[] Operations = { "+", "-", "*", "/" };

    private readonly string[]? Tokens;
    private int Position;

    private static readonly Regex InputSplit = new("(?<=[−+*/\\(\\)])|(?=[−+*/\\(\\)])");
    private static readonly Regex Numbers = new("[0-9]+");

    public ExpressionParser(string expression)
    {
        if (string.IsNullOrWhiteSpace(expression))
            throw new NullReferenceException(EmptyString);
        Tokens = InputSplit.Split(expression)
                .SelectMany(str => str.Split(' ', StringSplitOptions.RemoveEmptyEntries))
                .ToArray();
    }

    public Expression Parse()
    {
        var result = PlusOrMinus();
        if (Position == Tokens?.Length) return result;
        var message = Tokens?[Position] == ")" ? IncorrectBracketsNumber :
            UnknownCharacterMessage(Tokens![Position].ToCharArray()[0]);
        throw new ArgumentException(message);
    }

    private Expression PlusOrMinus()
    {
        var firstExpression = MultiplyOrDivide();
        while (Position < Tokens?.Length)
        {
            var token = Tokens[Position];
            if (!token.Equals("+") && !token.Equals("-")) break;
            Position++;
            var secondExpression = MultiplyOrDivide();
            firstExpression = token.Equals("+")
                    ? Expression.Add(firstExpression, secondExpression)
                    : Expression.Subtract(firstExpression, secondExpression);
        }

        return firstExpression;
    }


    private Expression MultiplyOrDivide()
    {
        var firstExpression = Brackets();
        while (Position < Tokens?.Length)
        {
            var token = Tokens[Position];
            if (!token.Equals("*") && !token.Equals("/")) break;
            Position++;
            var secondExpression = Brackets();
            firstExpression = token.Equals("*")
                    ? Expression.Multiply(firstExpression, secondExpression)
                    : Expression.Divide(firstExpression, secondExpression);
        }

        return firstExpression;
    }

    private Expression Brackets()
    {
        var next = Position < Tokens?.Length ? Tokens[Position] : string.Empty;
        var previous = Position - 1 >= 0 ? Tokens?[Position - 1] : string.Empty;
        if (next.Equals("("))
        {
            Position++;
            var result = PlusOrMinus();
            if (Position >= Tokens?.Length)
                throw new ArgumentException(IncorrectBracketsNumber);

            Position++;
            return result;
        }

        return CheckAllSituations(next, previous);
    }

    private Expression CheckAllSituations(string next, string previous)
    {
        if (double.TryParse(next, out var res))
        {
            Position++;
            return Expression.Constant(res);
        }
        string message;
        if (Position == 0 && Operations.Contains(next))
            message = StartingWithOperation;
        else if (next == ")" && Operations.Contains(previous))
            message = OperationBeforeParenthesisMessage(previous ?? string.Empty);
        else if (previous == "(" && Operations.Contains(next))
            message = InvalidOperatorAfterParenthesisMessage(next);
        else if (Operations.Contains(previous) && Operations.Contains(next))
            message = TwoOperationInRowMessage(previous ?? string.Empty, next);
        else if (Numbers.IsMatch(next))
            message = NotNumberMessage(next);
        else if (Operations.Contains(previous) && next == string.Empty)
            message = EndingWithOperation;
        else
            message = UnknownCharacterMessage(next.ToCharArray()[0]);
        throw new ArgumentException(message);
    }
}