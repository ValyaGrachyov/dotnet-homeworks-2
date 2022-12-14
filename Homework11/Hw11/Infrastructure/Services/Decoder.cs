using Hw11.Infrastructure.Dto;
using Hw11.Infrastructure.Services.MathCalculator;

namespace Hw11.Infrastructure.Services;

public abstract class Decoder : IMathCalculatorService
{
    protected IMathCalculatorService _math;
    

    public virtual  Task<CalculationMathExpressionResultDto> CalculateMathExpressionAsync(string? expression)
        =>  _math.CalculateMathExpressionAsync(expression);
}