using Ollama.Domain.Entities;
using Ollama.Domain.Exceptions;
using Ollama.Infrastructure.Repositories;
using Xunit;

namespace Ollama.Tests.Infrastructure.Repositories;

public class UserInMemoryRepositoryTest
{
    private readonly UserInMemoryRepository _repository;

    public UserInMemoryRepositoryTest()
    {
        _repository = new UserInMemoryRepository();
    }

    [Fact]
    public void UserInMemoryRepository_Should_Save_User_Successfully()
    {
        var user = new User("Gabriel");

        _repository.SaveUser(user);

        Assert.Equal(user.Id, _repository.GetUser()!.Id);
    }

    [Fact]
    public void UserInMemoryRepository_Should_Throw_When_An_User_Already_Exists()
    {
        var user = new User("Gabriel");

        _repository.SaveUser(user);

        var exception = Assert.Throws<DupicateUserException>(() => { _repository.SaveUser(user); });

        Assert.Equal("User already exists.", exception.Message);
    }

    [Fact]
    public void UserInMemoryRepository_Should_Return_Successfully()
    {
        var user = new User("Gabriel");

        _repository.SaveUser(user);

        var fetchedUser = _repository.GetUser();

        Assert.NotNull(fetchedUser);
        Assert.Equal(user.Id, fetchedUser.Id);
        Assert.Equal(user.Name, user.Name);
    }

    [Fact]
    public void UserInMemoryRepository_Should_Return_Null_If_User_Does_Not_Exists()
    {
        var user = _repository.GetUser();

        Assert.Null(user);
    }
}
