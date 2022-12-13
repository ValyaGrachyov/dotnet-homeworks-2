namespace Hw11.Infrastructure.Exceptions;

public interface IExceptionHandler
{
	public void HandleException<T>(T exception) where T : Exception;
}