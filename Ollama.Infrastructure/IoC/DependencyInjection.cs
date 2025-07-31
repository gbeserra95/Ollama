using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;
using Ollama.Domain.Repositories;
using Ollama.Domain.Services;
using Ollama.Infrastructure.Repositories;
using Ollama.Infrastructure.Services;

namespace Ollama.Infrastructure.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddChatClient(new OllamaChatClient(
                new Uri("http://localhost:11434"),
                "llama3"
            ));

            services.AddTransient<IUserRepository, UserInMemoryRepository>();
            services.AddTransient<IOllamaService, OllamaService>();

            return services;
        }
    }
}