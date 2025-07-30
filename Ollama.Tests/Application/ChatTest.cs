using Moq;
using Ollama.Application.Usecases;
using Ollama.Domain.Entities;
using Ollama.Domain.Services;
using Ollama.Infrastructure.Repositories;
using Xunit;

namespace Ollama.Tests.Application
{
    public class ChatTest
    {
        private readonly UserInMemoryRepository _repository;
        private readonly Chat _chat;

        public ChatTest()
        {
            var ollamaServiceMock = new Mock<IOllamaService>();

            _repository = new UserInMemoryRepository();
            _chat = new Chat(ollamaServiceMock.Object, _repository);
        }

        [Fact]
        public void GreetUser_Should_Return_Welcome_Message_If_User_Already_Exists()
        {
            var user = new User("Gabriel");
            _repository.SaveUser(user);

            using var sw = new StringWriter();
            Console.SetOut(sw);

            _chat.GreetUser();

            var output = sw.ToString();

            Assert.Equal($"Welcome back, {user!.Name}! How can I help you today?\n", output);
        }

        [Fact]
        public void GreetUser_Should_Ask_For_User_Name_If_Does_Not_Exists()
        {
            using var sw = new StringWriter();
            Console.SetOut(sw);

            using var sr = new StringReader("Gabriel\n");
            Console.SetIn(sr);

            _chat.GreetUser();

            var output = sw.ToString();

            Assert.Contains($"Welcome to Ollama! Please, tell me your name: ", output);
            Assert.Contains("Hello, Gabriel! How can I help you today?\n", output);
        }

        [Fact]
        public void GreetUser_Should_Not_Allow_Empty_Name_If_Does_Not_Exists()
        {
            using var sw = new StringWriter();
            Console.SetOut(sw);

            using var sr = new StringReader("\nGabriel\n");
            Console.SetIn(sr);

            _chat.GreetUser();

            var output = sw.ToString();

            Assert.Contains("Name cannot be empty.\n", output);
            Assert.Contains("Hello, Gabriel! How can I help you today?\n", output);
        }
    }
}