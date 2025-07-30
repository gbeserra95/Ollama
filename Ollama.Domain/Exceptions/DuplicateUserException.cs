namespace Ollama.Domain.Exceptions;

public class DupicateUserException : Exception
{
    public DupicateUserException(string message) : base(message) { }
}
