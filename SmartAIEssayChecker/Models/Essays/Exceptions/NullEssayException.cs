using Xeptions;

namespace SmartAIEssayChecker.Models.Essays.Exceptions;

public class NullEssayException : Xeption
{
    public NullEssayException()
        : base(message: "Essay is null.")
    { }
}