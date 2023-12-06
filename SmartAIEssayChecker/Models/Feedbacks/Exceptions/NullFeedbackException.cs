using Xeptions;

namespace SmartAIEssayChecker.Models.Feedbacks.Exceptions;

public class NullFeedbackException : Xeption
{
    public NullFeedbackException()
        : base(message: "Feedback is null.")
    { }
}