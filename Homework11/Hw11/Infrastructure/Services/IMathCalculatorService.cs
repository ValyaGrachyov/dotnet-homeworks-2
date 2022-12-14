using Hw11.Infrastructure.Dto;

namespace Hw11.Infrastructure.Services;

public interface IMathCalculatorService
{
    public Task<CalculationMathExpressionResultDto> CalculateMathExpressionAsync(string? expression);
}