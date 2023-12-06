using SmartAIEssayChecker.Models.Users;

namespace MyNamespace.Services.Users;

public interface IUserService
{
    ValueTask<User> RetrieveUserByIdAsync(Guid userId);
    ValueTask<User> RemoveUserAsync(Guid userId);
    ValueTask<User> ModifyUserAsync(User user);
}