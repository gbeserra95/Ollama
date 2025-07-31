using Microsoft.Extensions.AI;
using Ollama.Domain.Services;

namespace Ollama.Infrastructure.Services
{
    public class OllamaService : IOllamaService
    {
        private readonly IChatClient _chatClient;
        private List<ChatMessage> chatHistory = new List<ChatMessage>();

        public OllamaService(IChatClient chatClient)
        {
            _chatClient = chatClient;
        }

        public async IAsyncEnumerable<string> AskOllamaStreamingAsync(string prompt)
        {
            chatHistory.Add(new ChatMessage(ChatRole.User, prompt));

            string response = "";

            await foreach (var chunk in _chatClient.GetStreamingResponseAsync(chatHistory))
            {
                response += chunk.Text;
                yield return chunk.Text;
            }

            chatHistory.Add(new ChatMessage(ChatRole.Assistant, response));
        }
    }
}