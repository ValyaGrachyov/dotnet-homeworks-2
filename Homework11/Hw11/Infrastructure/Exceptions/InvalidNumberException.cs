namespace Hw11.Infrastructure.Exceptions;

public class InvalidNumberException: Exception
{
	public InvalidNumberException(string message)
		: base(message)
	{
	}
}