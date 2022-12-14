namespace Hw11.Infrastructure.Exceptions;

public class InvalidSymbolException: Exception
{
	public InvalidSymbolException(string message)
		: base(message)
	{
	}
}