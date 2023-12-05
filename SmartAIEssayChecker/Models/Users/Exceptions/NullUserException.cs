using Xeptions;

namespace SmartAIEssayChecker.Models.Users.Exceptions;

public class NullUserException : Xeption
{
    public NullUserException()
        : base(message: "Client is null")
    {
        
    }
}