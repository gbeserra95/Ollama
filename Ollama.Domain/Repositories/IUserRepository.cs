using Ollama.Domain.Entities;

namespace Ollama.Domain.Repositories;

public interface IUserRepository
{
    User? GetUser();
    void SaveUser(User user);
}
