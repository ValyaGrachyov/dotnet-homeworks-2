using Hw10.DbModels;
using Hw10.Dto;
using Hw10.Services;
using Hw10.Services.MathCalculator;
using Hw10.Services.Parser;

namespace Hw10.Services.CachedCalculator;

public class MathCachedCalculatorService : Decoder 
{
	private readonly ApplicationContext _dbContext;	
	public MathCachedCalculatorService(ApplicationContext dbContext, IMathCalculatorService service)
	{
        _dbContext = dbContext;
        _math = service;
    }

	public override async Task<CalculationMathExpressionResultDto> CalculateMathExpressionAsync(string? expression)
	{
		var solvingExpression = _dbContext.SolvingExpressions.Where(expr => expr.Expression == expression);

		if(solvingExpression.Any())
		{
			await Task.Delay(1000);
			return await Task.Run(() => new CalculationMathExpressionResultDto(solvingExpression.First().Result));
		}

		var result = await _math.CalculateMathExpressionAsync(expression);
		if (!result.IsSuccess) return result;
		_dbContext.SolvingExpressions.Add(new SolvingExpression(expression!, result.Result));
		await _dbContext.SaveChangesAsync();

		return result;
	}
}