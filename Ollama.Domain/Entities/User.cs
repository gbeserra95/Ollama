using Ollama.Domain.Exceptions;

namespace Ollama.Domain.Entities;

public class User : Entity
{
    public string Name { get; private set; }

    public User(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new UserException("Name cannot be empty."); 

        Id = Guid.NewGuid();
        Name = name;   
    }
}
