namespace Ollama.Infrastructure.Exceptions;

public class DupicateUserIdException : Exception
{
    public DupicateUserIdException(string message) : base(message) { }
}
