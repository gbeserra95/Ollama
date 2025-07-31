namespace Ollama.Domain.Services
{
    public interface IOllamaService
    {
        IAsyncEnumerable<string> AskOllamaStreamingAsync(string prompt);
    }
}