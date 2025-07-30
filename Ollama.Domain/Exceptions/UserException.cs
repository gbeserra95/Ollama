namespace Ollama.Domain.Exceptions;

public class UserException : ArgumentException
{
    public UserException(string message) : base(message) { }
}
