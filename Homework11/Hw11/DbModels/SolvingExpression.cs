using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Hw11.DbModels;

[ExcludeFromCodeCoverage]
public class SolvingExpression
{

	public SolvingExpression(string expression, double result)
    {
		Expression = expression;
		Result = result;
    }
	public int SolvingExpressionId { get; set; }
		
	[Required] 
	public string Expression { get; set; } = null!;

	[Required] 
	public double Result { get; set; }
}