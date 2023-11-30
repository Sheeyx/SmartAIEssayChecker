using SmartAIEssayChecker.Models.Users;

namespace MyNamespace;

internal class Program
{
    static void Main(string[] args)
    {
        var users = new User()
        {
            Id = Guid.NewGuid(),
            Name = "Anvar"
        };
    }
}

