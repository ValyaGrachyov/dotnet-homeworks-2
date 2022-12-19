using Hw10.Dto;
using Hw10.Services.MathCalculator;

namespace Hw10.Services;

public abstract class Decoder : IMathCalculatorService
{
    protected IMathCalculatorService _math;
    

    public virtual  Task<CalculationMathExpressionResultDto> CalculateMathExpressionAsync(string? expression)
        =>  _math.CalculateMathExpressionAsync(expression);
}