using SmartAIEssayChecker.Models.Users;

namespace MyNamespace.Services.Users;

public interface IUserService
{
    ValueTask<User> AddUserAsync(User user);
    IQueryable<User> RetrieveUsers();
    ValueTask<User> RetrieveUserByIdAsync(Guid userId);
    ValueTask<User> ModifyUserAsync(User user);
    ValueTask<User> RemoveUserAsync(Guid userId);
}