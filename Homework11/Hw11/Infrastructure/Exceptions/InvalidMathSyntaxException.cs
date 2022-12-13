namespace Hw11.Infrastructure.Exceptions;

public class InvalidSyntaxException : Exception
{
	public InvalidSyntaxException(string message)
		: base(message)
	{
	}
}