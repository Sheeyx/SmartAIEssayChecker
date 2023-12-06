using SmartAIEssayChecker.Brokers.Storages;
using SmartAIEssayChecker.Models.Users;
using SmartAIEssayChecker.Models.Users.Exceptions;
using Xeptions;

namespace MyNamespace.Services.Users;

internal class UserService : Xeption
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
        
        Validate(
            (Rule: isInvalid(user.Id), Parameter: nameof(user.Id)),
            (Rule: isInvalid(user.Name), Parameter: nameof(user.Name))
        );
        
        return this.storageBroker.InsertUserAsync(user);
    }

    private dynamic isInvalid(Guid id) => new
    {
        Condition = id == default,
        Message = "Id is required"
    };

    private dynamic isInvalid(string text) => new
    {
        Conditon = String.IsNullOrWhiteSpace(text),
        Message = "Text is required"
    };
    private void Validate(params (dynamic Rule, string Parameter)[] validations)
    {
        var invalidUserException = new InvalidUserException();

        foreach ((dynamic rule, string parameter) in validations)
        {
            if (rule.Condition)
            {
                invalidUserException.UpsertDataList(
                    key: parameter,
                    value: rule.Message);
            }
            invalidUserException.ThrowIfContainsErrors();
        }
    }
    
}