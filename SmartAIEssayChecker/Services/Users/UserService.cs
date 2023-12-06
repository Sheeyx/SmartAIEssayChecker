using MyNamespace.Brokers.Loggings;
using SmartAIEssayChecker.Brokers.Storages;
using SmartAIEssayChecker.Models.Users;

namespace MyNamespace.Services.Users;
public partial class UserService : IUserService
{

    private readonly IStorageBroker storageBroker;
    private readonly ILoggingBroker loggingBroker;

    public UserService(
        IStorageBroker storageBroker,
        ILoggingBroker loggingBroker)
    {
        this.storageBroker = storageBroker;
        this.loggingBroker = loggingBroker;
    }
    

    public IQueryable<User> RetrieveUsers() =>
        this.storageBroker.SelectAllUsers();

    public async ValueTask<User> RetrieveUserByIdAsync(Guid userId)
    {
        ValidateUserId(userId);

        User user = await this.storageBroker.SelectUserByIdAsync(userId);

        return user;
    }

    public async ValueTask<User> ModifyUserAsync(User user)
    {
        ValidateUserOnModify(user);

        return await this.storageBroker.UpdateUserAsync(user);
    }

    public async ValueTask<User> RemoveUserAsync(Guid userId)
    {
        ValidateUserId(userId);

        User user = await this.storageBroker.SelectUserByIdAsync(userId);

        return await this.storageBroker.DeleteUserAsync(user);
    }
}