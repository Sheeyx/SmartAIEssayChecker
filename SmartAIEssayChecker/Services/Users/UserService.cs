using SmartAIEssayChecker.Brokers.Storages;
using SmartAIEssayChecker.Models.Users;
using SmartAIEssayChecker.Models.Users.Exceptions;

namespace MyNamespace.Services.Users;

internal class UserService
{
    private readonly StorageBroker storageBroker;

    public UserService()
    {
        this.storageBroker = new StorageBroker();
    }

    internal Task<User> AddUserAsync(User user)
    {
        if (user is null)
        {
            throw new NullUserException();
        }
        
        return this.storageBroker.InsertUserAsync(user);
    }
    
}