using Ollama.Domain.Entities;

namespace Ollama.Domain.Repositories;

public interface IUserRepository
{
    User? GetUserById(Guid id);
    User? GetUserByName(string name);
    void SaveUser(User user);
}
