namespace Ollama.Application.Interfaces;

public interface IChat
{
    void GreetUser();

    Task GetUserPrompt(string? prompt);
}
