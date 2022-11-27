using Hw10.DbModels;
using Hw10.Dto;
using Hw10.Services.MathCalculator;

namespace Hw10.Services.CachedCalculator;

public class MathCachedCalculatorService : IMathCalculatorService
{
	private readonly ApplicationContext _dbContext;
	private readonly IMathCalculatorService _simpleCalculator;

	public MathCachedCalculatorService(ApplicationContext dbContext, IMathCalculatorService simpleCalculator)
	{
		_dbContext = dbContext;
		_simpleCalculator = simpleCalculator;
	}

	public async Task<CalculationMathExpressionResultDto> CalculateMathExpressionAsync(string? expression)
	{
		var solvingExpression = _dbContext.SolvingExpressions.Where(expr => expr.Expression == expression);

		if(solvingExpression.Any())
        {
			await Task.Delay(1000);
			return await Task.Run(() => new CalculationMathExpressionResultDto(solvingExpression.First().Result));
        }

		var result = await _simpleCalculator.CalculateMathExpressionAsync(expression);
		if (!result.IsSuccess) return result;
		_dbContext.SolvingExpressions.Add(new SolvingExpression(expression!, result.Result));
		await _dbContext.SaveChangesAsync();

		return result;
	}
}