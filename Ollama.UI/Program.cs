using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ollama.Application.Interfaces;
using Ollama.Application.IoC;
using Ollama.Infrastructure.IoC;

var builder = Host.CreateApplicationBuilder();

builder.Services.AddApplication();
builder.Services.AddInfrastructure();

var app = builder.Build();

var chatService = app.Services.GetRequiredService<IChat>();
chatService.GreetUser();

while (true)
{
    var prompt = Console.ReadLine();
    await chatService.GetUserPrompt(prompt);
    Console.WriteLine();
    Console.WriteLine();
}