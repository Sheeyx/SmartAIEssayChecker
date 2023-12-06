using Xeptions;

namespace SmartAIEssayChecker.Models.Feedbacks.Exceptions;

public class InvalidFeedbackException : Xeption
{
    public InvalidFeedbackException()
        : base(message: "Feedback is invalid.")
    { }
}