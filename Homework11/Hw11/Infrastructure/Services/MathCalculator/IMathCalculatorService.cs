namespace Hw11.Infrastructure.Services.MathCalculator;

public interface IMathCalculatorService
{ 
    Task<double> CalculateMathExpressionAsync(string? expression);
}