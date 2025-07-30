using Ollama.Domain.Entities;
using Ollama.Domain.Repositories;
using Ollama.Domain.Exceptions;

namespace Ollama.Infrastructure.Repositories;

public class UserInMemoryRepository : IUserRepository
{
    private User? _user;

    public User? GetUser()
    {
        return _user;
    }

    public void SaveUser(User user)
    {
        if (_user is not null)
            throw new DupicateUserException("User already exists.");

        _user = user;
    }
}
