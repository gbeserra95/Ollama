namespace Ollama.Application.Interfaces;

public interface IChat
{
    void GreetUser();

    void GetUserPrompt();

    void ResponseUser();
}
