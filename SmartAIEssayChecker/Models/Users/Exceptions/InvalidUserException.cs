using Xeptions;

namespace SmartAIEssayChecker.Models.Users.Exceptions;

public class InvalidUserException : Xeption
{
    public InvalidUserException()
        :base(message: "User is invalid. Fix the errors and try again!")
    { }
}