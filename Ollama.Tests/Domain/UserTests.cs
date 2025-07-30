using Ollama.Domain.Entities;
using Ollama.Domain.Exceptions;
using Xunit;

namespace Ollama.Tests.Domain;

public class UserTests
{
    [Fact]
    public void User_Should_Create_Successfully()
    {
        string name = "Gabriel";

        var user = new User(name);

        Assert.IsType<Guid>(user.Id);
        Assert.Equal(name, user.Name);
    }

    [Theory]
    [InlineData("")]
    [InlineData("    ")]
    [InlineData(null)]
    public void User_Should_Throws_When_Name_IsNullOrWhiteSpace(string name)
    {
        var exception = Assert.Throws<UserException>(() => { var user = new User(name); });
        Assert.Equal("Name cannot be empty.", exception.Message);
    }
}
