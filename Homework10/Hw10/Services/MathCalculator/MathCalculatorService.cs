using Hw10.Dto;

namespace Hw10.Services.MathCalculator;

public class MathCalculatorService : IMathCalculatorService
{
    public async Task<CalculationMathExpressionResultDto> CalculateMathExpressionAsync(string? expression)
    {
        try
        {
            //TODO
        }
        catch (Exception ex)
        {
            return new CalculationMathExpressionResultDto(expression);
        }
    }
}