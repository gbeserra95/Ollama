using Ollama.Application.Interfaces;
using Ollama.Domain.Entities;
using Ollama.Domain.Exceptions;
using Ollama.Domain.Repositories;
using Ollama.Domain.Services;

namespace Ollama.Application.Usecases;

public class Chat : IChat
{
    private readonly IOllamaService _ollamaService;
    private readonly IUserRepository _userRepository;

    public Chat(IOllamaService ollamaService, IUserRepository userRepository)
    {
        _ollamaService = ollamaService;
        _userRepository = userRepository;
    }

    public void GreetUser()
    {
        var user = _userRepository.GetUser();

        if (user is null)
        {
            AskUserName();
            return;
        }

        Console.WriteLine($"Welcome back, {user!.Name}! How can I help you today?");
    }

    public async Task GetUserPrompt(string prompt)
    {
        await foreach (var text in _ollamaService.AskOllamaStreamingAsync(prompt))
        {
            Console.Write(text);
        }

        Console.WriteLine();
    }

    private void AskUserName()
    {
        Console.Write("Welcome to Ollama! Please, tell me your name: ");

        while (true)
        {
            try
            {
                var name = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Name cannot be empty.");
                }
                else
                {
                    var newUser = new User(name);
                    _userRepository.SaveUser(newUser);

                    Console.WriteLine($"Hello, {newUser.Name}! How can I help you today?");
                    break;
                }
            }
            catch (UserException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Please, tell me your name: ");
        }
    }
}
