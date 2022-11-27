using Hw9.Infrastructure.Models;
using Hw9.Parser;


namespace Hw9.Services.MathCalculator;

public class MathCalculatorService : IMathCalculatorService
{
    public async Task<CalculationMathExpressionResultDto> CalculateMathExpressionAsync(string? expression)
    {
        try
        {
            var parseExpression = new ExpressionParser(expression).Parse();            

            var converteExpressionDictionary = new ExpressionConverter().ExpressionDictionary(parseExpression);

            var result = await new CalculatorVisitor().VisitDictionary(converteExpressionDictionary);

            return new CalculationMathExpressionResultDto(result);
        }
        catch (Exception e)
        {
            return new CalculationMathExpressionResultDto(e.Message);
        }
    }
}