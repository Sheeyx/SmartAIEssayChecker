using SmartAIEssayChecker.Brokers.Storages;
using SmartAIEssayChecker.Models.Users;
using SmartAIEssayChecker.Models.Users.Exceptions;
using Xeptions;

namespace MyNamespace.Services.Users;

internal class UserService : Xeption

{
    private void ValidationOnAdd(User user)
    {
        ValidateUserNotNull(user);

        Validate(
            (Rule: IsInvalid(user.Id), Parameter: nameof(user.Id)),
            (Rule: IsInvalid(user.Name), Parameter: nameof(user.Name)));
    }

    private void ValidateUserOnModify(User user)
    {
        ValidateUserNotNull(user);

        Validate(
            (Rule: IsInvalid(user.Id), Parameter: nameof(user.Id)),
            (Rule: IsInvalid(user.Name), Parameter: nameof(user.Name)));
    }

    private void ValidateUserId(Guid userId)
    {
        Validate((Rule: IsInvalid(userId), Parameter: nameof(userId)));
    }

    private static dynamic IsInvalid(Guid userId) => new
    {
        Condition = userId == default,
        Message = "Id is required"
    };

    private static dynamic IsInvalid(string text) => new
    {
        Condition = String.IsNullOrWhiteSpace(text) == default,
        Message = "Text is required"
    };

    private static void ValidateUserNotNull(User user)
    {
        if (user is null)
        {
            throw new NullUserException();
        }


    private static void Validate(params (dynamic Rule, string Parameter)[] validations)

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
 

            invalidUserException.ThrowIfContainsErrors();
        }
    }
    

}