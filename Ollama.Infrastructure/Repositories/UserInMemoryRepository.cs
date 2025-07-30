using Ollama.Domain.Entities;
using Ollama.Domain.Repositories;
using Ollama.Infrastructure.Exceptions;

namespace Ollama.Infrastructure.Repositories;

public class UserInMemoryRepository : IUserRepository
{
    private readonly List<User> _users = [];

    public User? GetUserById(Guid id)
    {
        return _users.FirstOrDefault(u => u.Id == id);
    }

    public User? GetUserByName(string name)
    {
        return _users.FirstOrDefault(u => u.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    public void SaveUser(User user)
    {
        if (_users.Any(u => u.Id == user.Id))
            throw new DupicateUserIdException("User with the same Id already exists.");
            
        _users.Add(user);
    }
}
