using Ollama.Domain.Entities;
using Ollama.Infrastructure.Exceptions;
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

        Assert.Equal(user.Id, _repository.GetUserById(user.Id)!.Id);
    }

    [Fact]
    public void UserInMemoryRepository_Should_Throw_When_Id_Already_Exists()
    {
        var user = new User("Gabriel");

        _repository.SaveUser(user);

        var exception = Assert.Throws<DupicateUserIdException>(() => { _repository.SaveUser(user); });

        Assert.Equal("User with the same Id already exists.", exception.Message);
    }

    [Fact]
    public void UserInMemoryRepository_Should_Return_User_By_Name_Successfully()
    {
        var user = new User("Gabriel");

        _repository.SaveUser(user);
        var fetchedUser = _repository.GetUserByName("gabriel");

        Assert.NotNull(fetchedUser);
        Assert.Equal(user.Id, fetchedUser.Id);
        Assert.Equal(user.Name, user.Name);
    }

    [Fact]
    public void UserInMemoryRepository_Should_Return_Null_If_User_Does_Not_Exists()
    {
        var user1 = _repository.GetUserById(Guid.NewGuid());
        var user2 = _repository.GetUserByName("michael scott");

        Assert.Null(user1);
        Assert.Null(user2);
    }
}
