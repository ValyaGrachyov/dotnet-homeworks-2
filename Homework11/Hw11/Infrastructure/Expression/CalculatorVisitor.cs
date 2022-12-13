using System.Data;
using System.Linq.Expressions;
using Hw11.Infrastructure.ErrorMessages;

namespace Hw11.Infrastructure;

public class CalculatorVisitor
{
    private Dictionary<Expression, Lazy<Task<double>>> _dictionary = new ();
    public async Task<double> VisitDictionary(Dictionary<Expression, Expression[]> dictionary)
    {
        
        var first = dictionary.Keys.First();
        foreach (var (current,before) in dictionary)
        {
            _dictionary[current] = new Lazy<Task<double>>(async () =>
            {
                await Task.WhenAll(before.Select(x => _dictionary[x].Value));
                await Task.Yield();

                return await CalculateExpression(current as dynamic);
            });
        }

        var result = await _dictionary[first].Value;
        _dictionary.Clear();

        return result;
        
    }

    private static double Plus(double val1, double val2)
        => val1 + val2;

    private static double Minus(double val1, double val2)
        => val1 - val2;

    private static double Mult(double val1, double val2)
        => val1 * val2;

    private static double Divide(double arg1, double arg2)
        => arg2 == 0.0 ? throw new DivideByZeroException(MathErrorMessager.DivisionByZero) : arg1 / arg2;

    private async Task<double> CalculateExpression(Expression expression)
    {
        if (expression is ConstantExpression constantExpression)
            return await Task.FromResult((double)constantExpression.Value!);

        await Task.Delay(1000);

        var binaryExpr = expression as BinaryExpression;
        var arg1 = await _dictionary[binaryExpr.Left].Value;
        var arg2 = await _dictionary[binaryExpr.Right].Value;
        

        return expression.NodeType switch
        {
            ExpressionType.Add => Plus(arg1, arg2),
            ExpressionType.Subtract => Minus(arg1, arg2),
            ExpressionType.Multiply => Mult(arg1, arg2),
            ExpressionType.Divide => Divide(arg1, arg2),
            _ => throw new InvalidExpressionException()
        };

    }
}