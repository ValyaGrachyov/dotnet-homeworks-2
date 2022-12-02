using Microsoft.EntityFrameworkCore;
using Hw10.DbModels;

namespace Hw10;

public class ApplicationContext: DbContext	
{
	public DbSet<SolvingExpression> SolvingExpressions => Set<SolvingExpression>();

	public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
	{
	}
}