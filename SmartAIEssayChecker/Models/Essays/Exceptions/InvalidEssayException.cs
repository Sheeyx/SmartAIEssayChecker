using Xeptions;

namespace SmartAIEssayChecker.Models.Essays.Exceptions;

public class InvalidEssayException : Xeption
{
    public InvalidEssayException()
        : base(message: "Essay is invalid.")
    { }
}