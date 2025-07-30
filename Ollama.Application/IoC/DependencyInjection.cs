using Microsoft.Extensions.DependencyInjection;
using Ollama.Application.Interfaces;
using Ollama.Application.Usecases;

namespace Ollama.Application.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IChat, Chat>();

            return services;
        }
    }
}