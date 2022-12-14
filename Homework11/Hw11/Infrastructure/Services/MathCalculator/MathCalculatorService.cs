using Hw11.Infrastructure.Exceptions;
using Hw11.Infrastructure.Parser;

namespace Hw11.Infrastructure.Services.MathCalculator;

public class MathCalculatorService : IMathCalculatorService
{
    private IExceptionHandler _handler;
    
    public MathCalculatorService(IExceptionHandler handler)
    {
        _handler = handler;
    }
    public async Task<double> CalculateMathExpressionAsync(string? expression)
    {
        try
        {
            var parseExpression = new ExpressionParser(expression).Parse();


            var converteExpressionDictionary = new ExpressionConverter().ExpressionDictionary(parseExpression);

            var result = await new CalculatorVisitor().VisitDictionary(converteExpressionDictionary);

            return result;
        }
        catch (Exception e)
        {
            _handler.HandleException(e);
            throw;
        }
    }
}